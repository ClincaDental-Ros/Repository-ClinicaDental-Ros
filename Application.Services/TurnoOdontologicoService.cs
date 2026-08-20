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

        public TurnoOdontologicoService(
            ITurnoRepository turnoRepository,
            IPacienteRepository pacienteRepository,
            IMultaRepository multaRepository)
        {
            _turnoRepository = turnoRepository;
            _pacienteRepository = pacienteRepository;
            _multaRepository = multaRepository;
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
            var criteria = new TurnoCriteria
            {
                Fecha = criteriaDTO.Fecha,
                FechaDesde = criteriaDTO.FechaDesde,
                FechaHasta = criteriaDTO.FechaHasta,
                OdontologoId = criteriaDTO.OdontologoId,
                PacienteId = criteriaDTO.PacienteId,
                EspecialidadId = criteriaDTO.EspecialidadId,
                EstadoTurno = criteriaDTO.EstadoTurno
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
            // 1. Validar existencia del paciente
            var paciente = await _pacienteRepository.GetAsync(dto.PacienteId);
            if (paciente == null)
            {
                throw new InvalidOperationException("El paciente especificado no existe.");
            }

            // 2. Validar inhabilitación por deuda / multas impagas
            if (!paciente.EstadoHabilitado)
            {
                throw new InvalidOperationException($"El paciente {paciente.Apellido}, {paciente.Nombre} se encuentra INHABILITADO para solicitar turnos debido a deudas o multas pendientes.");
            }

            var multasImpagas = await _multaRepository.GetImpagasByPacienteIdAsync(dto.PacienteId);
            if (multasImpagas.Any())
            {
                throw new InvalidOperationException($"El paciente tiene {multasImpagas.Count()} multa(s) impaga(s). Debe regularizar su situación antes de reservar.");
            }

            // 3. Validar que el paciente no tenga ya un turno reservado el mismo día
            if (await _turnoRepository.PacienteTieneTurnoEnFechaAsync(dto.PacienteId, dto.Fecha))
            {
                throw new InvalidOperationException($"El paciente ya posee un turno registrado para la fecha {dto.Fecha:dd/MM/yyyy}.");
            }

            // 4. Validar disponibilidad del odontólogo
            if (await _turnoRepository.TurnoExistsAsync(dto.Fecha, dto.HorarioTurno, dto.OdontologoId))
            {
                throw new InvalidOperationException($"El odontólogo seleccionado ya tiene un turno agendado para el {dto.Fecha:dd/MM/yyyy} a las {dto.HorarioTurno}.");
            }

            var estado = TurnoOdontologico.EstadoTurnoEnum.Pendiente;
            if (!string.IsNullOrWhiteSpace(dto.EstadoTurno) && Enum.TryParse<TurnoOdontologico.EstadoTurnoEnum>(dto.EstadoTurno, true, out var parsedEstado))
            {
                estado = parsedEstado;
            }

            var turno = new TurnoOdontologico(
                0,
                dto.Fecha,
                dto.HorarioTurno,
                estado,
                dto.MotivoCancelacion,
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

            if (await _turnoRepository.TurnoExistsAsync(dto.Fecha, dto.HorarioTurno, dto.OdontologoId, dto.Id))
            {
                throw new InvalidOperationException($"El horario {dto.HorarioTurno} en la fecha {dto.Fecha:dd/MM/yyyy} ya se encuentra ocupado.");
            }

            Enum.TryParse<TurnoOdontologico.EstadoTurnoEnum>(dto.EstadoTurno, true, out var estado);

            turno.Fecha = dto.Fecha;
            turno.HorarioTurno = dto.HorarioTurno;
            turno.EstadoTurno = estado;
            turno.MotivoCancelacion = dto.MotivoCancelacion;
            turno.PacienteId = dto.PacienteId;
            turno.OdontologoId = dto.OdontologoId;
            turno.EspecialidadId = dto.EspecialidadId;
            turno.MontoEstimado = dto.MontoEstimado;

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

            turno.EstadoTurno = TurnoOdontologico.EstadoTurnoEnum.Presente;
            return await _turnoRepository.UpdateAsync(turno);
        }

        public async Task<bool> RegistrarAusenciaAsync(int id, string motivo, decimal montoMulta = 3500m)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.EstadoTurno = TurnoOdontologico.EstadoTurnoEnum.NoAsistido;
            turno.MotivoCancelacion = string.IsNullOrWhiteSpace(motivo) ? "Ausencia registrada en recepción" : motivo;
            await _turnoRepository.UpdateAsync(turno);

            // Generar multa automática
            var multa = new Multa(0, turno.PacienteId, montoMulta, false, null, $"Inasistencia a turno del {turno.Fecha:dd/MM/yyyy}: {motivo}");
            await _multaRepository.AddAsync(multa);

            // Inhabilitar al paciente de inmediato
            var paciente = await _pacienteRepository.GetAsync(turno.PacienteId);
            if (paciente != null)
            {
                paciente.EstadoHabilitado = false;
                await _pacienteRepository.UpdateAsync(paciente);
            }

            return true;
        }

        public async Task<bool> CancelarTurnoAsync(int id, string motivo)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.EstadoTurno = TurnoOdontologico.EstadoTurnoEnum.Cancelado;
            turno.MotivoCancelacion = motivo;
            return await _turnoRepository.UpdateAsync(turno);
        }

        public async Task<bool> AtenderTurnoAsync(int id)
        {
            var turno = await _turnoRepository.GetAsync(id);
            if (turno == null) return false;

            turno.EstadoTurno = TurnoOdontologico.EstadoTurnoEnum.Atendido;
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