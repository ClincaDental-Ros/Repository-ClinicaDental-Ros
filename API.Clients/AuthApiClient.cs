using DTOs;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            return await PostAsync<LoginRequestDTO, LoginResponseDTO>("/api/auth/login", request);
        }

        public async Task<UsuarioDTO?> GetMeAsync()
        {
            return await GetAsync<UsuarioDTO>("/api/auth/me");
        }
    }
}
