using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ConsultaEndpoints
    {
        public static void MapConsultaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/consultas")
                .WithTags("Consultas Clínicas")
                .RequireAuthorization();

            // Mismo control que en facturas: el personal ve todas; un paciente solo las suyas,
            // tomando su id del token. Si pide las de otro paciente, 403.
            group.MapGet("/", async (int? pacienteId, ClaimsPrincipal user, IConsultaService service) =>
            {
                if (!user.EsPersonal())
                {
                    var propio = user.PacienteId();
                    if (propio == null) return Results.Forbid();
                    if (pacienteId.HasValue && pacienteId.Value != propio.Value) return Results.Forbid();
                    pacienteId = propio;
                }

                if (pacienteId.HasValue && pacienteId.Value > 0)
                    return Results.Ok(await service.GetByPacienteIdAsync(pacienteId.Value));

                return Results.Ok(await service.GetAllAsync());
            });

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IConsultaService service) =>
            {
                var consulta = await service.GetAsync(id);
                if (consulta == null) return Results.NotFound();
                return user.PuedeAccederAPaciente(consulta.PacienteId) ? Results.Ok(consulta) : Results.Forbid();
            });

            group.MapGet("/turno/{turnoId:int}", async (int turnoId, ClaimsPrincipal user, IConsultaService service) =>
            {
                var consulta = await service.GetByTurnoIdAsync(turnoId);
                if (consulta == null) return Results.NotFound();
                return user.PuedeAccederAPaciente(consulta.PacienteId) ? Results.Ok(consulta) : Results.Forbid();
            });

            group.MapPost("/registrar", async (ConsultaDTO dto, IConsultaService service) =>
            {
                var created = await service.RegistrarConsultaAsync(dto);
                return Results.Created($"/api/consultas/{created.Id}", created);
            }).RequireAuthorization("AdminOrOdontologo");

            // Solo el paciente atendido puede valorar su propia atención.
            group.MapPost("/{id:int}/valorar", async (int id, ValoracionRequest request, ClaimsPrincipal user, IConsultaService service) =>
            {
                var consulta = await service.GetAsync(id);
                if (consulta == null) return Results.NotFound();
                if (user.PacienteId() != consulta.PacienteId) return Results.Forbid();

                var ok = await service.ValorarAtencionAsync(id, request.Estrellas, request.Comentario);
                return ok ? Results.Ok(new { message = "Valoración registrada con éxito." }) : Results.NotFound();
            });
        }
    }

    public record ValoracionRequest(int Estrellas, string Comentario);
}
