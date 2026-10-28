using DTOs;

namespace API.Clients
{
    public class ObraSocialApiClient : BaseApiClient
    {
        public ObraSocialApiClient() : base()
        {
        }

        public ObraSocialApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<ObraSocialDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<ObraSocialDTO>>("/api/obras-sociales");
            return list ?? new List<ObraSocialDTO>();
        }
    }
}
