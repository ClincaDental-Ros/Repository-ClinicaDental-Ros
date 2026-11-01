using DTOs;

namespace API.Clients
{
    public class InsumoApiClient : BaseApiClient
    {
        public InsumoApiClient() : base()
        {
        }

        public InsumoApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<InsumoDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<InsumoDTO>>("/api/insumos");
            return list ?? new List<InsumoDTO>();
        }

        public async Task<InsumoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<InsumoDTO>($"/api/insumos/{id}");
        }

        public async Task<InsumoDTO?> CreateAsync(InsumoDTO dto)
        {
            return await PostAsync<InsumoDTO, InsumoDTO>("/api/insumos", dto);
        }

        public async Task<InsumoDTO?> UpdateAsync(InsumoDTO dto)
        {
            return await PutAsync<InsumoDTO, InsumoDTO>($"/api/insumos/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/insumos/{id}");
        }
    }
}
