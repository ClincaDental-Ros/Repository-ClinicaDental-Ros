using DTOs;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        public async Task<(bool Exito, string Mensaje)> CambiarPasswordAsync(int userId, string passActual, string passNueva)
        {
            try
            {
                var client = await GetConfiguredClientAsync();
                var req = new CambiarPasswordRequestDTO
                {
                    UserId = userId,
                    PasswordActual = passActual,
                    PasswordNueva = passNueva
                };
                var resp = await client.PostAsJsonAsync("/api/auth/change-password", req);
                if (resp.IsSuccessStatusCode)
                {
                    return (true, "Contraseña actualizada exitosamente.");
                }

                return (false, "La contraseña actual es incorrecta.");
            }
            catch (Exception ex)
            {
                return (false, $"Error al cambiar contraseña: {ex.Message}");
            }
        }
    }
}
