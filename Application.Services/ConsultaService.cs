using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface IConsultaService
    {
        Task<ConsultaDTO?> GetAsync(int id);
        Task<ConsultaDTO?> GetByTurnoIdAsync(int turnoId);
        Task<IEnumerable<ConsultaDTO>> GetAllAsync();
        Task<IEnumerable<ConsultaDTO>> GetByPacienteIdAsync(int pacienteId);
        Task<ConsultaDTO> RegistrarConsultaAsync(ConsultaDTO dto);
        Task<bool> ValorarAtencionAsync(int id, int estrellas, string comentario);
    }

    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly ITurnoRepository _turnoRepository;
        private readonly IInsumoRepository _insumoRepository;
        private readonly IFacturaRepository _facturaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ITransactionManager _transactionManager;

        public ConsultaService(
            IConsultaRepository consultaRepository,
            ITurnoRepository turnoRepository,
            IInsumoRepository insumoRepository,
            IFacturaRepository facturaRepository,
            IPacienteRepository pacienteRepository,
            ITransactionManager transactionManager)
        {
            _consultaRepository = consultaRepository;
            _turnoRepository = turnoRepository;
            _insumoRepository = insumoRepository;
            _facturaRepository = facturaRepository;
            _pacienteRepository = pacienteRepository;
            _transactionManager = transactionManager;
        }

        public async Task<ConsultaDTO?> GetAsync(int id)
        {
            var c = await _consultaRepository.GetAsync(id);
            return c == null ? null : MapToDTO(c);
        }

        public async Task<ConsultaDTO?> GetByTurnoIdAsync(int turnoId)
        {
            var c = await _consultaRepository.GetByTurnoIdAsync(turnoId);
            return c == null ? null : MapToDTO(c);
        }

        public async Task<IEnumerable<ConsultaDTO>> GetAllAsync()
        {
            var list = await _consultaRepository.GetAllAsync();
            return list.Select(MapToDTO).ToList();
        }

        public async Task<IEnumerable<ConsultaDTO>> GetByPacienteIdAsync(int pacienteId)
        {
            var list = await _consultaRepository.GetByPacienteIdAsync(pacienteId);
            return list.Select(MapToDTO).ToList();
        }

        /// <summary>
        /// Registra la atención: marca el turno como atendido, guarda la consulta, descuenta el stock
        /// de los insumos usados y emite la factura. Todo en una sola transacción.
        /// </summary>
        public async Task<ConsultaDTO> RegistrarConsultaAsync(ConsultaDTO dto)
        {
            var turno = await _turnoRepository.GetAsync(dto.TurnoId)
                ?? throw new InvalidOperationException("El turno asociado no existe.");

            if (await _consultaRepository.GetByTurnoIdAsync(dto.TurnoId) != null)
                throw new InvalidOperationException("El turno ya tiene una atención registrada.");

            var consulta = new Consulta(
                0,
                dto.TurnoId,
                dto.Diagnostico,
                dto.Tratamiento,
                dto.Observaciones,
                dto.AnestesiaLocal,
                dto.Radiografias,
                dto.Valoracion,
                dto.CalificacionEstrellas
            );

            await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                turno.Atender();
                await _turnoRepository.UpdateAsync(turno);
                await _consultaRepository.AddAsync(consulta);

                var facturaItems = new List<ItemFactura>();
                foreach (var itemDto in dto.InsumosUtilizados ?? new List<ItemFacturaDTO>())
                {
                    if (itemDto.InsumoId <= 0 || itemDto.CantidadInsumo <= 0)
                        continue;

                    var insumo = await _insumoRepository.GetAsync(itemDto.InsumoId)
                        ?? throw new InvalidOperationException($"El insumo #{itemDto.InsumoId} no existe.");

                    if (!await _insumoRepository.DescontarStockAsync(insumo.Id, itemDto.CantidadInsumo))
                        throw new InvalidOperationException($"Stock insuficiente de \"{insumo.Nombre}\" (disponible: {insumo.Stock}).");

                    facturaItems.Add(new ItemFactura(0, 0, insumo.Id, itemDto.CantidadInsumo, insumo.Precio));
                }

                var paciente = await _pacienteRepository.GetAsync(turno.PacienteId);
                var factura = new Factura(
                    0,
                    turno.Id,
                    turno.PacienteId,
                    $"Atención Odontológica - {dto.Tratamiento} (Diag: {dto.Diagnostico})",
                    0m, 0m, 0m, 0m,
                    false,
                    "Pendiente de Pago"
                );
                factura.SetItems(facturaItems);
                factura.CalcularMontos(FacturaService.CalcularHonorarios(turno), paciente?.ObraSocial?.PorcentajeCobertura ?? 0m);

                await _facturaRepository.AddAsync(factura);
                return true;
            });

            dto.Id = consulta.Id;
            return dto;
        }

        public async Task<bool> ValorarAtencionAsync(int id, int estrellas, string comentario)
        {
            var consulta = await _consultaRepository.GetAsync(id);
            if (consulta == null) return false;

            consulta.SetCalificacion(Math.Clamp(estrellas, 1, 5));
            consulta.SetValoracion(comentario);
            return await _consultaRepository.UpdateAsync(consulta);
        }

        private static ConsultaDTO MapToDTO(Consulta c)
        {
            return new ConsultaDTO
            {
                Id = c.Id,
                TurnoId = c.TurnoId,
                PacienteId = c.Turno?.PacienteId ?? 0,
                PacienteNombre = c.Turno?.Paciente != null ? $"{c.Turno.Paciente.Apellido}, {c.Turno.Paciente.Nombre}" : "Paciente",
                OdontologoNombre = c.Turno?.Odontologo != null ? $"Dr/a. {c.Turno.Odontologo.Apellido}, {c.Turno.Odontologo.Nombre}" : "Odontólogo",
                Diagnostico = c.Diagnostico,
                Tratamiento = c.Tratamiento,
                Observaciones = c.Observaciones,
                AnestesiaLocal = c.AnestesiaLocal,
                Radiografias = c.Radiografias,
                Valoracion = c.Valoracion,
                CalificacionEstrellas = c.CalificacionEstrellas,
                Fecha = c.Fecha
            };
        }
    }
}
