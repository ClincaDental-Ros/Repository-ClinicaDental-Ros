using Domain.Model;

namespace Data
{
    public interface IEspecialidadRepository
    {
        Task<Especialidad?> GetAsync(int id);
        Task<IEnumerable<Especialidad>> GetAllAsync();
        Task<Especialidad> AddAsync(Especialidad especialidad);
        Task<bool> UpdateAsync(Especialidad especialidad);
        Task<bool> DeleteAsync(int id);
    }
}
