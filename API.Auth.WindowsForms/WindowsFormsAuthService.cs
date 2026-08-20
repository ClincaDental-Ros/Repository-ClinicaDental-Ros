using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Clients;
using DTOs;

namespace API.Auth.WindowsForms
{
    public class WindowsFormsAuthService : IAuthService
    {
        private string? _token;
        private string? _username;
        private string? _rol;
        private string? _nombreCompleto;
        private int? _userId;
        private int? _entidadId;
        private DateTime? _expiration;

        public event Action<bool>? OnAuthenticationStateChanged;

        public void SetSession(LoginResponseDTO response)
        {
            _token = response.Token;
            _username = response.Username;
            _rol = response.Rol;
            _nombreCompleto = response.NombreCompleto;
            _userId = response.UserId;
            _entidadId = response.EntidadId;
            _expiration = response.Expiration;

            try
            {
                var handler = new JwtSecurityTokenHandler();
                if (handler.CanReadToken(response.Token))
                {
                    var jwt = handler.ReadJwtToken(response.Token);
                    var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role")?.Value;
                    if (!string.IsNullOrEmpty(roleClaim)) _rol = roleClaim;

                    var nameClaim = jwt.Claims.FirstOrDefault(c => c.Type == "NombreCompleto")?.Value;
                    if (!string.IsNullOrEmpty(nameClaim)) _nombreCompleto = nameClaim;

                    var idClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "nameid")?.Value;
                    if (!string.IsNullOrEmpty(idClaim) && int.TryParse(idClaim, out var parsedId)) _userId = parsedId;

                    var entidadClaim = jwt.Claims.FirstOrDefault(c => c.Type == "EntidadId")?.Value;
                    if (!string.IsNullOrEmpty(entidadClaim) && int.TryParse(entidadClaim, out var parsedEntidad)) _entidadId = parsedEntidad;
                }
            }
            catch
            {
                // Si falla el parseo de claims, conservamos los datos entregados por la respuesta del login
            }

            OnAuthenticationStateChanged?.Invoke(true);
        }

        public void ClearSession()
        {
            _token = null;
            _username = null;
            _rol = null;
            _nombreCompleto = null;
            _userId = null;
            _entidadId = null;
            _expiration = null;

            OnAuthenticationStateChanged?.Invoke(false);
        }

        public string? GetToken() => _token;

        public bool IsAuthenticated()
        {
            if (string.IsNullOrWhiteSpace(_token))
                return false;

            if (_expiration.HasValue && DateTime.UtcNow > _expiration.Value)
            {
                ClearSession();
                return false;
            }

            return true;
        }

        public string? GetRol() => _rol;
        public string? GetUsername() => _username;
        public string? GetNombreCompleto() => _nombreCompleto;
        public int? GetUserId() => _userId;
        public int? GetEntidadId() => _entidadId;
    }
}
