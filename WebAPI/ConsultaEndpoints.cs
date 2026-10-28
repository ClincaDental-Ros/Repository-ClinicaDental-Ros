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

            group.MapGet("/", async (int? pacienteId, ClaimsPrincipal user, IConsultaService service) =>
              {
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

      group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IConsultaService service) =>
      {
        var item = await service.GetAsync(id);
        if (item == null) return Results.NotFound();
        return user.PuedeAccederAPaciente(item.PacienteId) ? Results.Ok(item) : Results.Forbid();
      });

      group.MapGet("/turno/{turnoId:int}", async (int turnoId, IConsultaService service) =>
            {
                var item = await service.GetByTurnoIdAsync(turnoId);
                return item == null ? Results.NotFound() : Results.Ok(item);
            });

            group.MapPost("/registrar", async (ConsultaDTO dto, IConsultaService service) =>
            {
                var created = await service.RegistrarConsultaAsync(dto);
                return Results.Created($"/api/consultas/{created.Id}", created);
            }).RequireAuthorization("AdminOrOdontologo");

      group.MapPost("/{id:int}/valorar", async (int id, ValoracionRequest request, ClaimsPrincipal user, IConsultaService service) =>
      {
        var consulta = await service.GetAsync(id);
        if (consulta == null) return Results.NotFound();
        if (!user.PuedeAccederAPaciente(consulta.PacienteId)) return Results.Forbid();
        var ok = await service.ValorarAtencionAsync(id, request.Estrellas, request.Comentario);
        return ok ? Results.Ok(new { message = "Valoración registrada con éxito." }) : Results.NotFound();
      });
    }
    }

    public record ValoracionRequest(int Estrellas, string Comentario);
}
