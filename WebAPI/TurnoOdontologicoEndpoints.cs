using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class TurnoOdontologicoEndpoints
    {
        public static void MapTurnoOdontologicoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/turnos")
                .WithTags("Turnos")
                .RequireAuthorization();

            group.MapGet("/", async (
                DateTime? fecha,
                DateTime? fechaDesde,
                DateTime? fechaHasta,
                int? odontologoId,
                int? pacienteId,
                int? especialidadId,
                string? estadoTurno,
                ClaimsPrincipal user,
                ITurnoOdontologicoService service) =>
            {
                // Un paciente solo puede consultar sus propios turnos
                if (!user.EsPersonal())
                {
                    pacienteId = user.PacienteId();
                    if (pacienteId == null) return Results.Forbid();
                }

                if (fecha.HasValue || fechaDesde.HasValue || fechaHasta.HasValue || odontologoId.HasValue || pacienteId.HasValue || especialidadId.HasValue || !string.IsNullOrWhiteSpace(estadoTurno))
                {
                    var criteria = new TurnoCriteriaDTO
                    {
                        Fecha = fecha,
                        FechaDesde = fechaDesde,
                        FechaHasta = fechaHasta,
                        OdontologoId = odontologoId,
                        PacienteId = pacienteId,
                        EspecialidadId = especialidadId,
                        EstadoTurno = estadoTurno
                    };
                    var filtered = await service.GetByCriteriaAsync(criteria);
                    return Results.Ok(filtered);
                }

                var list = await service.GetAllAsync();
                return Results.Ok(list);
            });

            group.MapGet("/hoy", async (DateTime? fecha, ITurnoOdontologicoService service) =>
            {
                var list = await service.GetTurnosDelDiaAsync(fecha);
                return Results.Ok(list);
            }).RequireAuthorization("StaffOnly");

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, ITurnoOdontologicoService service) =>
            {
                var turno = await service.GetAsync(id);
                if (turno == null) return Results.NotFound();
                return user.PuedeAccederAPaciente(turno.PacienteId) ? Results.Ok(turno) : Results.Forbid();
            });

            group.MapPost("/reservar", async (TurnoOdontologicoDTO dto, ClaimsPrincipal user, ITurnoOdontologicoService service) =>
            {
                if (!user.PuedeAccederAPaciente(dto.PacienteId))
                    return Results.Forbid();

                var created = await service.ReservarTurnoAsync(dto);
                return Results.Created($"/api/turnos/{created.Id}", created);
            });

            group.MapPut("/{id:int}", async (int id, TurnoOdontologicoDTO dto, ITurnoOdontologicoService service) =>
            {
                dto.Id = id;
                var updated = await service.UpdateAsync(dto);
                return updated ? Results.Ok(dto) : Results.NotFound();
            }).RequireAuthorization("AdminOrRecepcionista");

            group.MapDelete("/{id:int}", async (int id, ITurnoOdontologicoService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            }).RequireAuthorization("AdminOnly");

            group.MapPost("/{id:int}/confirmar-presencia", async (int id, ITurnoOdontologicoService service) =>
            {
                var ok = await service.ConfirmarPresenciaAsync(id);
                return ok ? Results.Ok(new { message = "Presencia confirmada con éxito." }) : Results.NotFound();
            }).RequireAuthorization("StaffOnly");

            group.MapPost("/{id:int}/registrar-ausencia", async (int id, RegistrarAusenciaRequest request, ITurnoOdontologicoService service) =>
            {
                var ok = await service.RegistrarAusenciaAsync(id, request.Motivo, request.MontoMulta);
                return ok ? Results.Ok(new { message = "Ausencia registrada y multa generada con inhabilitación del paciente." }) : Results.NotFound();
            }).RequireAuthorization("StaffOnly");

            group.MapPost("/{id:int}/cancelar", async (int id, CancelarTurnoRequest request, ClaimsPrincipal user, ITurnoOdontologicoService service) =>
            {
                var turno = await service.GetAsync(id);
                if (turno == null) return Results.NotFound();
                if (!user.PuedeAccederAPaciente(turno.PacienteId)) return Results.Forbid();

                var ok = await service.CancelarTurnoAsync(id, request.Motivo);
                return ok ? Results.Ok(new { message = "Turno cancelado." }) : Results.NotFound();
            });

            group.MapPost("/{id:int}/atender", async (int id, ITurnoOdontologicoService service) =>
            {
                var ok = await service.AtenderTurnoAsync(id);
                return ok ? Results.Ok(new { message = "Turno marcado como atendido." }) : Results.NotFound();
            }).RequireAuthorization("AdminOrOdontologo");
        }
    }

    public record RegistrarAusenciaRequest(string Motivo, decimal MontoMulta = 3500m);
    public record CancelarTurnoRequest(string Motivo);
}
