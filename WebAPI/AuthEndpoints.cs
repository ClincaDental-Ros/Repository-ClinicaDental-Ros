using Application.Services;
using DTOs;
using System.Security.Claims;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/auth").WithTags("Autenticación");

            group.MapPost("/login", async (LoginRequestDTO request, IAuthService authService) =>
            {
                var response = await authService.LoginAsync(request);
                if (response == null)
                    return Results.Unauthorized();

                return Results.Ok(response);
            }).AllowAnonymous();

            group.MapPost("/refresh", async (RefreshTokenRequestDTO request, IAuthService authService) =>
            {
                var response = await authService.RefreshTokenAsync(request.Token);
                if (response == null)
                    return Results.Unauthorized();

                return Results.Ok(response);
            }).AllowAnonymous();

            group.MapGet("/me", async (ClaimsPrincipal user, IAuthService authService) =>
            {
                var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(idClaim) || !int.TryParse(idClaim, out var userId))
                    return Results.Unauthorized();

                var usuario = await authService.GetUsuarioActualAsync(userId);
                return usuario == null ? Results.NotFound() : Results.Ok(usuario);
            }).RequireAuthorization();

            group.MapPost("/change-password", async (CambiarPasswordRequestDTO req, ClaimsPrincipal user, IAuthService authService) =>
            {
                // El usuario solo puede cambiar su propia contraseña
                var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(idClaim) || !int.TryParse(idClaim, out var authenticatedUserId))
                    return Results.Unauthorized();

                // Solo Admin puede cambiar la contraseña de otro usuario
                var rol = user.FindFirst(ClaimTypes.Role)?.Value;
                if (req.UserId != authenticatedUserId && rol != "Admin")
                    return Results.Forbid();

                var ok = await authService.CambiarPasswordAsync(req.UserId, req.PasswordActual, req.PasswordNueva);
                if (!ok)
                    return Results.BadRequest(new { mensaje = "La contraseña actual es incorrecta o no se pudo actualizar." });

                return Results.Ok(new { mensaje = "Contraseña actualizada exitosamente." });
            }).RequireAuthorization();
        }
    }
}
