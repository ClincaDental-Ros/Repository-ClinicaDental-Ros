using Domain.Model;

namespace Data
{
    public interface IMultaRepository
    {
        Task<Multa?> GetAsync(int id);
        Task<IEnumerable<Multa>> GetAllAsync();
        Task<IEnumerable<Multa>> GetByPacienteIdAsync(int pacienteId);
        Task<IEnumerable<Multa>> GetImpagasByPacienteIdAsync(int pacienteId);
        Task<IEnumerable<Multa>> GetByRangoFechasAsync(DateTime fechaDesde, DateTime fechaHasta);
        Task<Multa> AddAsync(Multa multa);
        Task<bool> PagarMultaAsync(int id);
    }
}
