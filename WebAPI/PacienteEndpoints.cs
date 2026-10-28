using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PacienteEndpoints
    {
        public static void MapPacienteEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/pacientes")
                .WithTags("Pacientes")
                .RequireAuthorization();

            group.MapGet("/", async (string? texto, bool? soloHabilitados, IPacienteService service) =>
            {
                if (!string.IsNullOrWhiteSpace(texto) || soloHabilitados.HasValue)
                {
                    var criteria = new PacienteCriteriaDTO(texto, soloHabilitados);
                    var result = await service.GetByCriteriaAsync(criteria);
                    return Results.Ok(result);
                }
                var list = await service.GetAllAsync();
                return Results.Ok(list);
            }).RequireAuthorization("StaffOnly");

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IPacienteService service) =>
            {
                if (!user.PuedeAccederAPaciente(id))
                    return Results.Forbid();

                var paciente = await service.GetAsync(id);
                return paciente == null ? Results.NotFound() : Results.Ok(paciente);
            });

            group.MapPost("/", async (PacienteDTO dto, IPacienteService service) =>
            {
                var created = await service.AddAsync(dto);
                return Results.Created($"/api/pacientes/{created.Id}", created);
            }).RequireAuthorization("AdminOrRecepcionista");



            group.MapPut("/{id:int}", async (int id, PacienteDTO dto, ClaimsPrincipal user, IPacienteService service) =>
            {
                var esAdminORecepcion = user.IsInRole("Admin") || user.IsInRole("Recepcionista");
                if (!esAdminORecepcion && user.PacienteId() != id)
                    return Results.Forbid();

                dto.Id = id;
                if (!esAdminORecepcion)
                {
                    var actual = await service.GetAsync(id);
                    if (actual == null) return Results.NotFound();
                    dto.EstadoHabilitado = actual.EstadoHabilitado;
                }

                var updated = await service.UpdateAsync(dto);
                return updated ? Results.Ok(dto) : Results.NotFound();
            });


      group.MapDelete("/{id:int}", async (int id, IPacienteService service) =>
      {
        try
        {
          var deleted = await service.DeleteAsync(id);
          return deleted ? Results.NoContent() : Results.NotFound();
        }
        catch (InvalidOperationException ex)
        {
          return Results.BadRequest(new { error = ex.Message });
        }
      }).RequireAuthorization("AdminOnly");


      group.MapPatch("/{id:int}/habilitar", async (int id, bool habilitar, IPacienteService service) =>
            {
                var ok = await service.ToggleHabilitacionAsync(id, habilitar);
                return ok ? Results.Ok() : Results.NotFound();
            }).RequireAuthorization("AdminOrRecepcionista");
        }
    }
}
