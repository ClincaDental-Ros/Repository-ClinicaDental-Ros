using Domain.Model;

namespace Data
{
    public interface IHistoriaClinicaRepository
    {
        Task<HistoriaClinica?> GetByPacienteIdAsync(int pacienteId);
        Task<HistoriaClinica> AddAsync(HistoriaClinica historiaClinica);
        Task<bool> UpdateAsync(HistoriaClinica historiaClinica);
    }
}
