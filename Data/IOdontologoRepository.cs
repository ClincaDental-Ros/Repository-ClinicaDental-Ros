using Domain.Model;

namespace Data
{
    public interface IOdontologoRepository
    {
        Task<Odontologo?> GetAsync(int id);
        Task<IEnumerable<Odontologo>> GetAllAsync();
        Task<IEnumerable<Odontologo>> GetByEspecialidadAsync(int especialidadId);
        Task<Odontologo> AddAsync(Odontologo odontologo);
        Task<bool> UpdateAsync(Odontologo odontologo);
        Task<bool> DeleteAsync(int id);
        Task<bool> MatriculaExistsAsync(int matricula, int? excludeId = null);
    }
}
