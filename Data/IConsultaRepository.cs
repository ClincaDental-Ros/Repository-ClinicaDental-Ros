using Domain.Model;

namespace Data
{
    public interface IConsultaRepository
    {
        Task<Consulta?> GetAsync(int id);
        Task<Consulta?> GetByTurnoIdAsync(int turnoId);
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<IEnumerable<Consulta>> GetByPacienteIdAsync(int pacienteId);
        Task<Consulta> AddAsync(Consulta consulta);
        Task<bool> UpdateAsync(Consulta consulta);
    }
}
