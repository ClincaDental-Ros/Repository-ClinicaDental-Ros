using Domain.Model;

namespace Data
{
    public interface IInsumoRepository
    {
        Task<Insumo?> GetAsync(int id);
        Task<IEnumerable<Insumo>> GetAllAsync();
        Task<Insumo> AddAsync(Insumo insumo);
        Task<bool> UpdateAsync(Insumo insumo);
        Task<bool> DeleteAsync(int id);
        Task<bool> DescontarStockAsync(int insumoId, int cantidad);
    }
}
