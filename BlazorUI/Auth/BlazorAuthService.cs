using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Clients;
using DTOs;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorUI.Auth
{
    public class BlazorAuthService : IAuthService
    {
        private const string STORAGE_KEY = "DentalClinic_Session";
        private readonly ProtectedLocalStorage _localStorage;
        private readonly CustomAuthStateProvider _authStateProvider;

        private string? _token;
        private string? _username;
        private string? _rol;
        private string? _nombreCompleto;
        private int? _userId;
        private int? _entidadId;
        private DateTime? _expiration;

        public event Action<bool>? OnAuthenticationStateChanged;

        public BlazorAuthService(
            ProtectedLocalStorage localStorage,
            CustomAuthStateProvider authStateProvider)
        {
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task InitializeAsync()
        {
            try
            {
                var result = await _localStorage.GetAsync<LoginResponseDTO>(STORAGE_KEY);
                if (result.Success && result.Value != null)
                {
                    SetSessionInternal(result.Value, notify: false);
                    if (!IsAuthenticated())
                    {
                        await ClearSessionAsync();
                    }
                }
            }
            catch
            {
                ClearSessionInternal();
            }
        }

        public void SetSession(LoginResponseDTO response)
        {
            SetSessionInternal(response, notify: true);
            _ = _localStorage.SetAsync(STORAGE_KEY, response);
        }

        private void SetSessionInternal(LoginResponseDTO response, bool notify)
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
                if (!string.IsNullOrEmpty(response.Token) && handler.CanReadToken(response.Token))
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
                // Ignorar lectura opcional
            }

            if (notify)
            {
                _authStateProvider.NotifyUserAuthentication(this);
                OnAuthenticationStateChanged?.Invoke(true);
            }
        }

        public void ClearSession()
        {
            _ = ClearSessionAsync();
        }

        public async Task ClearSessionAsync()
        {
            ClearSessionInternal();
            try
            {
                await _localStorage.DeleteAsync(STORAGE_KEY);
            }
            catch
            {
                // Ignorar si el circuito se cerró
            }

            _authStateProvider.NotifyUserLogout();
            OnAuthenticationStateChanged?.Invoke(false);
        }

        private void ClearSessionInternal()
        {
            _token = null;
            _username = null;
            _rol = null;
            _nombreCompleto = null;
            _userId = null;
            _entidadId = null;
            _expiration = null;
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

        public bool IsInRole(params string[] roles)
        {
            if (string.IsNullOrEmpty(_rol)) return false;
            return roles.Contains(_rol, StringComparer.OrdinalIgnoreCase);
        }
    }
}