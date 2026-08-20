using Domain.Model;

namespace Data
{
    public interface IPacienteRepository
    {
        Task<Paciente?> GetAsync(int id);
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<IEnumerable<Paciente>> GetByCriteriaAsync(PacienteCriteria criteria);
        Task<Paciente> AddAsync(Paciente paciente);
        Task<bool> UpdateAsync(Paciente paciente);
        Task<bool> DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);
        Task<bool> DniExistsAsync(int dni, int? excludeId = null);
    }
}
