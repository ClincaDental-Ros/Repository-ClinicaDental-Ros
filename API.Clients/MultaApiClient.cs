using DTOs;

namespace API.Clients
{
    public class MultaApiClient : BaseApiClient
    {
        public MultaApiClient() : base()
        {
        }

        public MultaApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<MultaDTO>> GetAllAsync(int? pacienteId = null, bool? soloImpagas = null)
        {
            var query = new List<string>();
            if (pacienteId.HasValue) query.Add($"pacienteId={pacienteId.Value}");
            if (soloImpagas.HasValue) query.Add($"soloImpagas={soloImpagas.Value}");
            var qs = query.Count > 0 ? "?" + string.Join("&", query) : "";

            var list = await GetAsync<List<MultaDTO>>($"/api/multas{qs}");
            return list ?? new List<MultaDTO>();
        }

        public async Task<MultaDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<MultaDTO>($"/api/multas/{id}");
        }

        public async Task<MultaDTO?> CrearAsync(MultaDTO dto)
        {
            return await PostAsync<MultaDTO, MultaDTO>("/api/multas", dto);
        }

        public async Task<bool> PagarAsync(int id)
        {
            return await PostAsync($"/api/multas/{id}/pagar", new { });
        }
    }
}
