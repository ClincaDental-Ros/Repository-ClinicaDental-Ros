using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class FacturaEndpoints
    {
        public static void MapFacturaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/facturas")
                .WithTags("Facturación y Caja")
                .RequireAuthorization();

            group.MapGet("/", async (int? pacienteId, ClaimsPrincipal user, IFacturaService service) =>
            {
                // Un paciente solo ve sus propias facturas
                if (!user.EsPersonal())
                {
                    pacienteId = user.PacienteId();
                    if (pacienteId == null) return Results.Forbid();
                }

                if (pacienteId.HasValue && pacienteId.Value > 0)
                {
                    var list = await service.GetByPacienteIdAsync(pacienteId.Value);
                    return Results.Ok(list);
                }
                var all = await service.GetAllAsync();
                return Results.Ok(all);
            });

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IFacturaService service) =>
            {
                var f = await service.GetAsync(id);
                if (f == null) return Results.NotFound();
                return user.PuedeAccederAPaciente(f.PacienteId) ? Results.Ok(f) : Results.Forbid();
            });

            group.MapGet("/turno/{turnoId:int}", async (int turnoId, IFacturaService service) =>
            {
                var f = await service.GetByTurnoIdAsync(turnoId);
                return f == null ? Results.NotFound() : Results.Ok(f);
            }).RequireAuthorization("StaffOnly");

            // Maestro/Detalle: los montos y precios los calcula el servidor; se ignoran los que mande el cliente.
            group.MapPost("/crear", async (FacturaDTO dto, IFacturaService service) =>
            {
                var created = await service.CrearFacturaAsync(dto);
                return Results.Created($"/api/facturas/{created.Id}", created);
            }).RequireAuthorization("AdminOrRecepcionista");

            group.MapPut("/{id:int}", async (int id, FacturaDTO dto, IFacturaService service) =>
            {
                dto.Id = id;
                var updated = await service.ActualizarFacturaAsync(dto);
                return updated ? Results.Ok(await service.GetAsync(id)) : Results.NotFound();
            }).RequireAuthorization("AdminOrRecepcionista");

            group.MapDelete("/{id:int}", async (int id, IFacturaService service) =>
            {
                var deleted = await service.EliminarFacturaAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            }).RequireAuthorization("AdminOrRecepcionista");

            group.MapPost("/{id:int}/pagar", async (int id, RegistrarPagoRequest request, IFacturaService service) =>
            {
                var ok = await service.RegistrarPagoAsync(id, request.MetodoPago);
                return ok ? Results.Ok(new { message = "Pago registrado y comprobante emitido." }) : Results.NotFound();
            }).RequireAuthorization("AdminOrRecepcionista");
        }
    }

    public record RegistrarPagoRequest(string MetodoPago);
}
