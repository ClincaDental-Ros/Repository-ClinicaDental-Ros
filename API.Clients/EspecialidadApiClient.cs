using DTOs;

namespace API.Clients
{
    public class EspecialidadApiClient : BaseApiClient
    {
        public EspecialidadApiClient() : base()
        {
        }

        public EspecialidadApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<EspecialidadDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<EspecialidadDTO>>("/api/especialidades");
            return list ?? new List<EspecialidadDTO>();
        }

        public async Task<EspecialidadDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<EspecialidadDTO>($"/api/especialidades/{id}");
        }

        public async Task<EspecialidadDTO?> CreateAsync(EspecialidadDTO dto)
        {
            return await PostAsync<EspecialidadDTO, EspecialidadDTO>("/api/especialidades", dto);
        }

        public async Task<EspecialidadDTO?> UpdateAsync(EspecialidadDTO dto)
        {
            return await PutAsync<EspecialidadDTO, EspecialidadDTO>($"/api/especialidades/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/especialidades/{id}");
        }
    }
}
