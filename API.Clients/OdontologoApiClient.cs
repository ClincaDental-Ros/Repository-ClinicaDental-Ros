using DTOs;

namespace API.Clients
{
    public class OdontologoApiClient : BaseApiClient
    {
        public OdontologoApiClient() : base()
        {
        }

        public OdontologoApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<OdontologoDTO>> GetAllAsync(int? especialidadId = null)
        {
            var url = especialidadId.HasValue && especialidadId.Value > 0
                ? $"/api/odontologos?especialidadId={especialidadId.Value}"
                : "/api/odontologos";

            var list = await GetAsync<List<OdontologoDTO>>(url);
            return list ?? new List<OdontologoDTO>();
        }

        public async Task<OdontologoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<OdontologoDTO>($"/api/odontologos/{id}");
        }

        public async Task<OdontologoDTO?> CreateAsync(OdontologoDTO dto)
        {
            return await PostAsync<OdontologoDTO, OdontologoDTO>("/api/odontologos", dto);
        }

        public async Task<OdontologoDTO?> UpdateAsync(OdontologoDTO dto)
        {
            return await PutAsync<OdontologoDTO, OdontologoDTO>($"/api/odontologos/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/odontologos/{id}");
        }
    }
}
