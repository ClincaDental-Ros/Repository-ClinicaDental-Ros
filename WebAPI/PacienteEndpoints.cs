using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PacienteEndpoints
    {
        public static void MapPacienteEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/pacientes").WithTags("Pacientes");

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
            });

            group.MapGet("/{id:int}", async (int id, IPacienteService service) =>
            {
                var paciente = await service.GetAsync(id);
                return paciente == null ? Results.NotFound() : Results.Ok(paciente);
            });

            group.MapPost("/", async (PacienteDTO dto, IPacienteService service) =>
            {
                try
                {
                    var created = await service.AddAsync(dto);
                    return Results.Created($"/api/pacientes/{created.Id}", created);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = ex.Message });
                }
            });

            group.MapPut("/{id:int}", async (int id, PacienteDTO dto, IPacienteService service) =>
            {
                dto.Id = id;
                try
                {
                    var updated = await service.UpdateAsync(dto);
                    return updated ? Results.Ok(dto) : Results.NotFound();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = ex.Message });
                }
            });

            group.MapDelete("/{id:int}", async (int id, IPacienteService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

            group.MapPatch("/{id:int}/habilitar", async (int id, bool habilitar, IPacienteService service) =>
            {
                var ok = await service.ToggleHabilitacionAsync(id, habilitar);
                return ok ? Results.Ok() : Results.NotFound();
            });
        }
    }
}
