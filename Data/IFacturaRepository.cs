using Domain.Model;

namespace Data
{
    public interface IFacturaRepository
    {
        Task<Factura?> GetAsync(int id);
        Task<Factura?> GetByTurnoIdAsync(int turnoId);
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<IEnumerable<Factura>> GetByPacienteIdAsync(int pacienteId);
        Task<IEnumerable<Factura>> GetByRangoFechasAsync(DateTime fechaDesde, DateTime fechaHasta);
        Task<Factura> AddAsync(Factura factura);
        Task<bool> UpdateAsync(Factura factura);
        Task<bool> UpdateConItemsAsync(Factura datos);
        Task<bool> DeleteAsync(int id);
    }
}
