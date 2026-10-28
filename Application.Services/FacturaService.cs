using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public interface IFacturaService
    {
        Task<FacturaDTO?> GetAsync(int id);
        Task<FacturaDTO?> GetByTurnoIdAsync(int turnoId);
        Task<IEnumerable<FacturaDTO>> GetAllAsync();
        Task<IEnumerable<FacturaDTO>> GetByPacienteIdAsync(int pacienteId);
        Task<FacturaDTO> CrearFacturaAsync(FacturaDTO dto);
        Task<bool> ActualizarFacturaAsync(FacturaDTO dto);
        Task<bool> EliminarFacturaAsync(int id);
        Task<bool> RegistrarPagoAsync(int id, string metodoPago);
    }

    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ITurnoRepository _turnoRepository;
        private readonly IInsumoRepository _insumoRepository;

        public FacturaService(
            IFacturaRepository facturaRepository,
            IPacienteRepository pacienteRepository,
            ITurnoRepository turnoRepository,
            IInsumoRepository insumoRepository)
        {
            _facturaRepository = facturaRepository;
            _pacienteRepository = pacienteRepository;
            _turnoRepository = turnoRepository;
            _insumoRepository = insumoRepository;
        }

        public static decimal CalcularHonorarios(TurnoOdontologico? turno) =>
            turno == null ? 0m : (turno.MontoEstimado > 0 ? turno.MontoEstimado : 12000m);

        public async Task<FacturaDTO?> GetAsync(int id)
        {
            var f = await _facturaRepository.GetAsync(id);
            return f == null ? null : MapToDTO(f);
        }

        public async Task<FacturaDTO?> GetByTurnoIdAsync(int turnoId)
        {
            var f = await _facturaRepository.GetByTurnoIdAsync(turnoId);
            return f == null ? null : MapToDTO(f);
        }

        public async Task<IEnumerable<FacturaDTO>> GetAllAsync()
        {
            var list = await _facturaRepository.GetAllAsync();
            return list.Select(MapToDTO).ToList();
        }

        public async Task<IEnumerable<FacturaDTO>> GetByPacienteIdAsync(int pacienteId)
        {
            var list = await _facturaRepository.GetByPacienteIdAsync(pacienteId);
            return list.Select(MapToDTO).ToList();
        }


        public async Task<FacturaDTO> CrearFacturaAsync(FacturaDTO dto)
        {
            var factura = await ConstruirFacturaAsync(0, dto);
            await _facturaRepository.AddAsync(factura);

            var creada = await _facturaRepository.GetAsync(factura.Id);
            return MapToDTO(creada ?? factura);
        }

        public async Task<bool> ActualizarFacturaAsync(FacturaDTO dto)
        {
            var existente = await _facturaRepository.GetAsync(dto.Id);
            if (existente == null) return false;
            existente.ValidarEditable();

            var datos = await ConstruirFacturaAsync(dto.Id, dto);
            return await _facturaRepository.UpdateConItemsAsync(datos);
        }

        public async Task<bool> EliminarFacturaAsync(int id)
        {
            var existente = await _facturaRepository.GetAsync(id);
            if (existente == null) return false;
            existente.ValidarEditable();

            return await _facturaRepository.DeleteAsync(id);
        }

        private async Task<Factura> ConstruirFacturaAsync(int id, FacturaDTO dto)
        {
            var paciente = await _pacienteRepository.GetAsync(dto.PacienteId)
                ?? throw new InvalidOperationException("El paciente seleccionado no existe.");

            TurnoOdontologico? turno = null;
            if (dto.TurnoId.HasValue && dto.TurnoId.Value > 0)
            {
                turno = await _turnoRepository.GetAsync(dto.TurnoId.Value)
                    ?? throw new InvalidOperationException("El turno seleccionado no existe.");

                if (turno.PacienteId != dto.PacienteId)
                    throw new InvalidOperationException("El turno seleccionado no corresponde al paciente.");

                var facturaDelTurno = await _facturaRepository.GetByTurnoIdAsync(turno.Id);
                if (facturaDelTurno != null && facturaDelTurno.Id != id)
                    throw new InvalidOperationException($"El turno ya tiene la factura N° {facturaDelTurno.Id}.");
            }

            var items = new List<ItemFactura>();
            foreach (var itemDto in dto.Items ?? new List<ItemFacturaDTO>())
            {
                var insumo = await _insumoRepository.GetAsync(itemDto.InsumoId)
                    ?? throw new InvalidOperationException($"El insumo #{itemDto.InsumoId} no existe.");
                items.Add(new ItemFactura(0, 0, insumo.Id, itemDto.CantidadInsumo, insumo.Precio));
            }

            if (turno == null && items.Count == 0)
                throw new InvalidOperationException("La factura debe estar asociada a un turno o tener al menos un ítem.");

            var descripcion = string.IsNullOrWhiteSpace(dto.Descripcion)
                ? (turno != null ? $"Atención Odontológica - Turno N° {turno.Id}" : "Venta de insumos")
                : dto.Descripcion.Trim();

            var factura = new Factura(id, turno?.Id, paciente.Id, descripcion, 0m, 0m, 0m, 0m, false, "Pendiente de Pago");
            factura.SetItems(items);
            factura.CalcularMontos(CalcularHonorarios(turno), paciente.ObraSocial?.PorcentajeCobertura ?? 0m);
            return factura;
        }

        public async Task<bool> RegistrarPagoAsync(int id, string metodoPago)
        {
            var factura = await _facturaRepository.GetAsync(id);
            if (factura == null) return false;

            factura.ValidarEditable();
            factura.SetEstadoPago(true);
            factura.SetMetodoPago(string.IsNullOrWhiteSpace(metodoPago) ? "Efectivo" : metodoPago);

            return await _facturaRepository.UpdateAsync(factura);
        }

        private static FacturaDTO MapToDTO(Factura f)
        {
            return new FacturaDTO
            {
                Id = f.Id,
                TurnoId = f.TurnoId,
                PacienteId = f.PacienteId,
                PacienteNombre = f.Paciente != null ? $"{f.Paciente.Apellido}, {f.Paciente.Nombre}" : $"Paciente #{f.PacienteId}",
                ObraSocialNombre = f.Paciente?.ObraSocial != null ? $"{f.Paciente.ObraSocial.Nombre} ({f.Paciente.ObraSocial.Plan})" : "Particular",
                Descripcion = f.Descripcion,
                Subtotal = f.Subtotal,
                DescuentoObraSocial = f.DescuentoObraSocial,
                Total = f.Total,
                MontoAPagarPaciente = f.MontoAPagarPaciente,
                EstadoPago = f.EstadoPago,
                MetodoPago = f.MetodoPago,
                FechaEmision = f.FechaEmision,
                Honorarios = f.Subtotal - (f.Items?.Sum(i => i.Subtotal) ?? 0m),
                Items = f.Items?.Select(i => new ItemFacturaDTO
                {
                    Id = i.Id,
                    FacturaId = i.FacturaId,
                    InsumoId = i.InsumoId,
                    InsumoNombre = i.Insumo?.Nombre ?? $"Insumo #{i.InsumoId}",
                    CantidadInsumo = i.CantidadInsumo,
                    PrecioUnitario = i.PrecioUnitario
                }).ToList() ?? new List<ItemFacturaDTO>()
            };
        }
    }
}
