using System.Security.Claims;
using Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI
{
    public static class ReportesEndpoints
    {
        public static void MapReportesEndpoints(this IEndpointRouteBuilder app)
        {
            // Grupo base: sin política. Cada subgrupo/endpoint define la suya.
            var group = app.MapGroup("/api/reportes")
                .WithTags("Reportes y Estadísticas");

            // ---------- Reportes del personal (mismo comportamiento que antes) ----------
            var staff = group.MapGroup("")
                .RequireAuthorization("StaffOnly");

            staff.MapGet("/turnos-dia", async (DateTime? fecha, IReportesService service) =>
            {
                var targetFecha = fecha ?? DateTime.Today;
                var rep = await service.GetReporteTurnosDiaAsync(targetFecha);
                return Results.Ok(rep);
            });

            staff.MapGet("/ausentismo", async (DateTime? fechaDesde, DateTime? fechaHasta, IReportesService service) =>
            {
                var fDesde = fechaDesde ?? DateTime.Today.AddDays(-30);
                var fHasta = fechaHasta ?? DateTime.Today;
                var rep = await service.GetReporteAusentismoAsync(fDesde, fHasta);
                return Results.Ok(rep);
            });

            staff.MapGet("/facturacion", async (DateTime? fechaDesde, DateTime? fechaHasta, IReportesService service) =>
            {
                var fDesde = fechaDesde ?? DateTime.Today.AddDays(-30);
                var fHasta = fechaHasta ?? DateTime.Today;
                var rep = await service.GetReporteFacturacionAsync(fDesde, fHasta);
                return Results.Ok(rep);
            }).RequireAuthorization("AdminOrRecepcionista");

            // ---------- Historia clínica: personal o el propio paciente ----------
            group.MapGet("/historia-clinica/{pacienteId:int}", async (
                int pacienteId,
                ClaimsPrincipal user,
                IAuthorizationService authorization,
                IReportesService service) =>
            {
                // El personal sigue pudiendo ver cualquier historia (misma política de siempre)
                var esStaff = (await authorization.AuthorizeAsync(user, "StaffOnly")).Succeeded;

                if (!esStaff)
                {
                    // Un paciente solo puede ver SU historia: el id pedido debe coincidir con el del token
                    var esPaciente = user.IsInRole("Paciente");
                    var entidadIdClaim = user.FindFirst("EntidadId")?.Value;
                    var esSuHistoria = int.TryParse(entidadIdClaim, out var entidadId) && entidadId == pacienteId;

                    if (!esPaciente || !esSuHistoria)
                        return Results.Forbid();
                }

                var rep = await service.GetHistoriaClinicaPacienteAsync(pacienteId);
                return rep == null ? Results.NotFound() : Results.Ok(rep);
            }).RequireAuthorization(); // cualquier usuario autenticado entra al endpoint; el control fino lo hace el código de arriba
        }
    }
}