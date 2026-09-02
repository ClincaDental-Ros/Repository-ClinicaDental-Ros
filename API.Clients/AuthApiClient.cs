using DTOs;
using System.Net.Http.Json;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PostAsJsonAsync("/api/auth/login", request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
              
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error de conexión con el servidor ({response.StatusCode})");
            }

            return await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
        }

        public async Task<UsuarioDTO?> GetMeAsync()
        {
            return await GetAsync<UsuarioDTO>("/api/auth/me");
        }
    }
}
