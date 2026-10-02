using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorUI.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private static readonly AuthenticationState AnonymousState =
            new(new ClaimsPrincipal(new ClaimsIdentity()));

        private AuthenticationState _currentState = AnonymousState;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(_currentState);
        }

        public void NotifyUserAuthentication(BlazorAuthService authService)
        {
            if (!authService.IsAuthenticated())
            {
                NotifyUserLogout();
                return;
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, authService.GetUsername() ?? string.Empty),
                new(ClaimTypes.Role, authService.GetRol() ?? string.Empty),
                new("NombreCompleto", authService.GetNombreCompleto() ?? string.Empty)
            };

            if (authService.GetUserId().HasValue)
                claims.Add(new Claim(ClaimTypes.NameIdentifier, authService.GetUserId()!.Value.ToString()));

            if (authService.GetEntidadId().HasValue)
                claims.Add(new Claim("EntidadId", authService.GetEntidadId()!.Value.ToString()));

            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            _currentState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(_currentState));
        }

        public void NotifyUserLogout()
        {
            _currentState = AnonymousState;
            NotifyAuthenticationStateChanged(Task.FromResult(AnonymousState));
        }
    }
}