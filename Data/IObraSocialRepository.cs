using Domain.Model;

namespace Data
{
    public interface IObraSocialRepository
    {
        Task<ObraSocial?> GetAsync(int id);
        Task<IEnumerable<ObraSocial>> GetAllAsync();
        Task<ObraSocial> AddAsync(ObraSocial obraSocial);
        Task<bool> UpdateAsync(ObraSocial obraSocial);
    }
}
