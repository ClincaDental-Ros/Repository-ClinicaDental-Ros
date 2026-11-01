using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class MultaEndpoints
    {
        public static void MapMultaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/multas")
                .WithTags("Multas y Sanciones")
                .RequireAuthorization();

            group.MapGet("/", async (int? pacienteId, bool? soloImpagas, ClaimsPrincipal user, IMultaService service) =>
            {
                // Un paciente solo ve sus propias multas
                if (!user.EsPersonal())
                {
                    pacienteId = user.PacienteId();
                    if (pacienteId == null) return Results.Forbid();
                }

                if (pacienteId.HasValue && pacienteId.Value > 0)
                {
                    if (soloImpagas.HasValue && soloImpagas.Value)
                    {
                        var impagas = await service.GetImpagasByPacienteIdAsync(pacienteId.Value);
                        return Results.Ok(impagas);
                    }
                    var list = await service.GetByPacienteIdAsync(pacienteId.Value);
                    return Results.Ok(list);
                }

                var all = await service.GetAllAsync();
                return Results.Ok(all);
            });

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IMultaService service) =>
            {
                var multa = await service.GetAsync(id);
                if (multa == null) return Results.NotFound();
                return user.PuedeAccederAPaciente(multa.PacienteId) ? Results.Ok(multa) : Results.Forbid();
            });

            group.MapPost("/", async (MultaDTO dto, IMultaService service) =>
            {
                var created = await service.CrearMultaAsync(dto);
                return Results.Created($"/api/multas/{created.Id}", created);
            }).RequireAuthorization("StaffOnly");

            // Paga la recepción o el propio paciente desde su portal
            group.MapPost("/{id:int}/pagar", async (int id, ClaimsPrincipal user, IMultaService service) =>
            {
                var multa = await service.GetAsync(id);
                if (multa == null) return Results.NotFound();

                var puedePagar = user.IsInRole("Admin") || user.IsInRole("Recepcionista") || user.PacienteId() == multa.PacienteId;
                if (!puedePagar) return Results.Forbid();

                await service.PagarMultaAsync(id);
                return Results.Ok(new { message = "Multa saldada y paciente rehabilitado si no registra más deudas." });
            });
        }
    }
}
