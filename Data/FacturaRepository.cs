using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly TurnoMolarDbContext _context;

        public FacturaRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<Factura?> GetAsync(int id)
        {
            return await _context.Facturas
                .Include(f => f.Paciente)
                    .ThenInclude(p => p!.ObraSocial)
                .Include(f => f.Turno)
                .Include(f => f.Items)
                    .ThenInclude(i => i.Insumo)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Factura?> GetByTurnoIdAsync(int turnoId)
        {
            return await _context.Facturas
                .Include(f => f.Paciente)
                    .ThenInclude(p => p!.ObraSocial)
                .Include(f => f.Turno)
                .Include(f => f.Items)
                    .ThenInclude(i => i.Insumo)
                .FirstOrDefaultAsync(f => f.TurnoId == turnoId);
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Facturas
                .Include(f => f.Paciente)
                    .ThenInclude(p => p!.ObraSocial)
                .Include(f => f.Turno)
                .Include(f => f.Items)
                    .ThenInclude(i => i.Insumo)
                .OrderByDescending(f => f.FechaEmision)
                .ToListAsync();
        }

        public async Task<IEnumerable<Factura>> GetByPacienteIdAsync(int pacienteId)
        {
            return await _context.Facturas
                .Include(f => f.Paciente)
                    .ThenInclude(p => p!.ObraSocial)
                .Include(f => f.Items)
                    .ThenInclude(i => i.Insumo)
                .Where(f => f.PacienteId == pacienteId)
                .OrderByDescending(f => f.FechaEmision)
                .ToListAsync();
        }

        public async Task<IEnumerable<Factura>> GetByRangoFechasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dDesde = fechaDesde.Date;
            var dHasta = fechaHasta.Date.AddDays(1).AddTicks(-1);

            return await _context.Facturas
                .Include(f => f.Paciente)
                    .ThenInclude(p => p!.ObraSocial)
                .Include(f => f.Items)
                    .ThenInclude(i => i.Insumo)
                .Where(f => f.FechaEmision >= dDesde && f.FechaEmision <= dHasta)
                .OrderByDescending(f => f.FechaEmision)
                .ToListAsync();
        }

        public async Task<Factura> AddAsync(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task<bool> UpdateAsync(Factura factura)
        {
            var existing = await _context.Facturas.FindAsync(factura.Id);
            if (existing == null)
                return false;

            existing.SetDescripcion(factura.Descripcion);
            existing.SetMontos(factura.Subtotal, factura.DescuentoObraSocial, factura.Total, factura.MontoAPagarPaciente);
            existing.SetEstadoPago(factura.EstadoPago);
            existing.SetMetodoPago(factura.MetodoPago);

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>Actualiza la cabecera y reemplaza el detalle (ítems) de la factura.</summary>
        public async Task<bool> UpdateConItemsAsync(Factura datos)
        {
            var existing = await _context.Facturas
                .Include(f => f.Items)
                .FirstOrDefaultAsync(f => f.Id == datos.Id);
            if (existing == null)
                return false;

            existing.SetPacienteId(datos.PacienteId);
            existing.SetTurnoId(datos.TurnoId);
            existing.SetDescripcion(datos.Descripcion);
            existing.SetMetodoPago(datos.MetodoPago);
            existing.SetMontos(datos.Subtotal, datos.DescuentoObraSocial, datos.Total, datos.MontoAPagarPaciente);

            _context.ItemsFactura.RemoveRange(existing.Items);
            existing.SetItems(datos.Items
                .Select(i => new ItemFactura(0, existing.Id, i.InsumoId, i.CantidadInsumo, i.PrecioUnitario))
                .ToList());

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
                return false;

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
