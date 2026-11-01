using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface ITurnoOdontologicoService
    {
        Task<TurnoOdontologicoDTO?> GetAsync(int id);
        Task<IEnumerable<TurnoOdontologicoDTO>> GetAllAsync();
        Task<IEnumerable<TurnoOdontologicoDTO>> GetByCriteriaAsync(TurnoCriteriaDTO criteriaDTO);
        Task<IEnumerable<TurnoOdontologicoDTO>> GetTurnosDelDiaAsync(DateTime? fecha = null);
        Task<TurnoOdontologicoDTO> ReservarTurnoAsync(TurnoOdontologicoDTO dto);
        Task<bool> UpdateAsync(TurnoOdontologicoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ConfirmarPresenciaAsync(int id);
        Task<bool> RegistrarAusenciaAsync(int id, string motivo, decimal montoMulta = 3500m);
        Task<bool> CancelarTurnoAsync(int id, string motivo);
        Task<bool> AtenderTurnoAsync(int id);
    }

    public class TurnoOdontologicoService : ITurnoOdontologicoService
    {
        private readonly ITurnoRepository _turnoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMultaRepository _multaRepository;
        private readonly ITransactionManager _transactionManager;

        public TurnoOdontologicoService(
            ITurnoRepository turnoRepository,
            IPacienteRepository pacienteRepository,
            IMultaRepository multaRepository,
            ITransactionManager transactionManager)
        {
            _turnoRepository = turnoRepository;
            _pacienteRepository = pacienteRepository;
            _multaRepository = multaRepository;
            _transactionManager = transactionManager;
        }

        /// <summary>Convierte el texto del estado; uno inexistente (o un número) es un error de la solicitud.</summary>
        public static TurnoOdontologico.EstadoTurnoEnum ParsearEstado(string estado)
        {
            if (!int.TryParse(estado, out _) &&
                Enum.TryParse<TurnoOdontologico.EstadoTurnoEnum>(estado.Trim(), true, out var parsed) &&
                Enum.IsDefined(parsed))
            {
                return parsed;
            }

            var validos = string.Join(", ", Enum.GetNames<TurnoOdontologico.EstadoTurnoEnum>());
            throw new ArgumentException($"El estado de turno '{estado}' no existe. Valores válidos: {validos}.");
        }

        private static void ValidarFechaFutura(DateTime fecha, TimeOnly horario)
        {
            var inicio = fecha.Date.Add(horario.ToTimeSpan());
            if (inicio < DateTime.Now)
                throw new ArgumentException($"No se puede agendar un turno en una fecha u hora pasada ({inicio:dd/MM/yyyy HH:mm}).");
        }

        public async Task<TurnoOdontologicoDTO?> GetAsync(int id)
        {
            var turno = await _turnoRepository.GetAsync(id);
            return turno == null ? null : MapToDTO(turno);
        }

        public async Task<IEnumerable<TurnoOdontologicoDTO>> GetAllAsync()
        {
            var turnos = await _turnoRepository.GetAllAsync();
            return turnos.Select(MapToDTO).ToList();
        }

        public async Task<IEnumerable<TurnoOdontologicoDTO>> GetByCriteriaAsync(TurnoCriteriaDTO criteriaDTO)
        {
            if (criteriaDTO.FechaDesde.HasValue && criteriaDTO.FechaHasta.HasValue &&
                criteriaDTO.FechaDesde.Value.Date > criteriaDTO.FechaHasta.Value.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }

            string? estado = null;
            if (!string.IsNullOrWhiteSpace(criteriaDTO.EstadoTurno))
                estado = ParsearEstado(criteriaDTO.EstadoTurno).ToString();

            var criteria = new TurnoCriteria
            {
                Fecha = criteriaDTO.Fecha,
                FechaDesde = criteriaDTO.FechaDesde,
                FechaHasta = criteriaDTO.FechaHasta,
                OdontologoId = criteriaDTO.OdontologoId,
                PacienteId = criteriaDTO.PacienteId,
                EspecialidadId = criteriaDTO.EspecialidadId,
                EstadoTurno = estado
            };

            var turnos = await _turnoRepository.GetByCriteriaAsync(criteria);
            return turnos.Select(MapToDTO).ToList();
        }

        public async Task<IEnumerable<TurnoOdontologicoDTO>> GetTurnosDelDiaAsync(DateTime? fecha = null)
        {
            var targetFecha = fecha ?? DateTime.Today;
            var turnos = await _turnoRepository.GetByFechaAsync(targetFecha);
            return turnos.Select(MapToDTO).ToList();
        }

        public async Task<TurnoOdontologicoDTO> ReservarTurnoAsync(TurnoOdontologicoDTO dto)
        {
            ValidarFechaFutura(dto.Fecha, dto.HorarioTurno);

            var paciente = await _pacienteRepository.GetAsync(dto.PacienteId);
            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente especificado no existe.");
            }

            if (!paciente.EstadoHabilitado)
            {
                throw new InvalidOperationException($"El paciente {paciente.Apellido}, {paciente.Nombre} se encuentra INHABILITADO para solicitar turnos debido a deudas o multas pendientes.");
            }

            var multasImpagas = await _multaRepository.GetImpagasByPacienteIdAsync(dto.PacienteId);
            if (multasImpagas.Any())
            {
                throw new InvalidOperationException($"El paciente tiene {multasImpagas.Count()} multa(s) impaga(s). Debe regularizar su situación antes de reservar.");
            }

            if (await _turnoRepository.PacienteTieneTurnoEnFechaAsync(dto.PacienteId, dto.Fecha))
            {
                throw new InvalidOperationException($"El paciente ya posee un turno registrado para la fecha {dto.Fecha:dd/MM/yyyy}.");
            }

            if (await _turnoRepository.TurnoExistsAsync(dto.Fecha, dto.HorarioTurno, dto.OdontologoId))
            {
                throw new InvalidOperationException($"El odontólogo seleccionado ya tiene un turno agendado para el {dto.Fecha:dd/MM/yyyy} a las {dto.HorarioTurno}.");
            }

            // Un turno nuevo siempre nace pendiente; el estado solo cambia con las acciones de recepción y atención.
            var turno = new TurnoOdontologico(
                0,
                dto.Fecha,
                dto.HorarioTurno,
                TurnoOdontologico.EstadoTurnoEnum.Pendiente,
                null,
                dto.PacienteId,
                dto.OdontologoId,
                dto.EspecialidadId,
                dto.MontoEstimado > 0 ? dto.MontoEstimado : 12000m
            );

            await _turnoRepository.AddAsync(turno);

            var turnoCompleto = await _turnoRepository.GetAsync(turno.Id);
            return MapToDTO(turnoCompleto ?? turno);
        }

        public async Task<bool> UpdateAsync(TurnoOdontologicoDTO dto)
        {
            var turno = await _turnoRepository.GetAsync(dto.Id);
            if (turno == null) return false;

            // Reprogramar: solo turnos pendientes y nunca hacia el pasado.
            turno.ValidarReprogramable();
            ValidarFechaFutura(dto.Fecha, dto.HorarioTurno);

            if (await _turnoRepository.TurnoExistsAsync(dto.Fecha, dto.HorarioTurno, dto.OdontologoId, dto.Id))
            {
                throw new InvalidOperationException($"El horario {dto.HorarioTurno} en la fecha {dto.Fecha:dd/MM/yyyy} ya se encuentra ocupado.");
            }

            if (await _turnoRepository.PacienteTieneTurnoEnFechaAsync(dto.PacienteId, dto.Fecha, dto.Id))
            {
                throw new InvalidOperationException($"El paciente ya posee otro turno para la fecha {dto.Fecha:dd/MM/yyyy}.");
            }

            turno.SetFecha(dto.Fecha);
            turno.SetHorarioTurno(dto.HorarioTurno);
            turno.SetPacienteId(dto.PacienteId);
            turno.SetOdontologoId(dto.OdontologoId);
            turno.SetEspecialidadId(dto.EspecialidadId);
            if (dto.MontoEstimado > 0)
                turno.SetMontoEstimado(dto.MontoEstimado);

            // Si además se pide un cambio de estado, pasa por las mismas reglas de transición.
            if (!string.IsNullOrWhiteSpace(dto.EstadoTurno))
            {
                var estado = ParsearEstado(dto.EstadoTurno);
                if (estado == TurnoOdontologico.EstadoTurnoEnum.Cancelado)
                    turno.Cancelar(dto.MotivoCancelacion ?? "");
                else if (estado != turno.EstadoTurno)
                    turno.SetEstado(estado);
            }

            return await _turnoRepository.UpdateAsync(turno);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _turnoRepository.DeleteAsync(id);
        }

        public async Task<bool> ConfirmarPresenciaAsync(int id)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.ConfirmarPresencia();
            return await _turnoRepository.UpdateAsync(turno);
        }

        public async Task<bool> RegistrarAusenciaAsync(int id, string motivo, decimal montoMulta = 3500m)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            // Ausencia, multa e inhabilitación del paciente van juntas: si falla una, no queda ninguna.
            return await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                turno.RegistrarAusencia(motivo);
                await _turnoRepository.UpdateAsync(turno);

                var multa = new Multa(0, turno.PacienteId, montoMulta, false, null, $"Inasistencia a turno del {turno.Fecha:dd/MM/yyyy}: {motivo}");
                await _multaRepository.AddAsync(multa);

                var paciente = await _pacienteRepository.GetAsync(turno.PacienteId);
                if (paciente != null)
                {
                    paciente.SetEstadoHabilitado(false);
                    await _pacienteRepository.UpdateAsync(paciente);
                }

                return true;
            });
        }

        public async Task<bool> CancelarTurnoAsync(int id, string motivo)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.Cancelar(motivo);
            return await _turnoRepository.UpdateAsync(turno);
        }

        public async Task<bool> AtenderTurnoAsync(int id)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.Atender();
            return await _turnoRepository.UpdateAsync(turno);
        }

        private static TurnoOdontologicoDTO MapToDTO(TurnoOdontologico t)
        {
            return new TurnoOdontologicoDTO
            {
                Id = t.Id,
                Fecha = t.Fecha,
                HorarioTurno = t.HorarioTurno,
                EstadoTurno = t.EstadoTurno.ToString(),
                MotivoCancelacion = t.MotivoCancelacion,
                PacienteId = t.PacienteId,
                PacienteNombre = t.Paciente != null ? $"{t.Paciente.Apellido}, {t.Paciente.Nombre} (DNI: {t.Paciente.Dni})" : $"Paciente #{t.PacienteId}",
                OdontologoId = t.OdontologoId,
                OdontologoNombre = t.Odontologo != null ? $"Dr/a. {t.Odontologo.Apellido}, {t.Odontologo.Nombre}" : $"Odontólogo #{t.OdontologoId}",
                EspecialidadId = t.EspecialidadId,
                EspecialidadNombre = t.Especialidad != null ? t.Especialidad.Nombre : "Odontología General",
                MontoEstimado = t.MontoEstimado
            };
        }
    }
}
