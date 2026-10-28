using System.Security.Claims;
using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class OdontologoEndpoints
    {
        public static void MapOdontologoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/odontologos")
                .WithTags("Odontólogos")
                .RequireAuthorization();

            group.MapGet("/", async (int? especialidadId, ClaimsPrincipal user, IOdontologoService service) =>
            {
                var list = especialidadId.HasValue && especialidadId.Value > 0
                    ? await service.GetByEspecialidadAsync(especialidadId.Value)
                    : await service.GetAllAsync();
                return Results.Ok(list.Select(o => ParaUsuario(o, user)));
            });

            group.MapGet("/{id:int}", async (int id, ClaimsPrincipal user, IOdontologoService service) =>
            {
                var o = await service.GetAsync(id);
                return o == null ? Results.NotFound() : Results.Ok(ParaUsuario(o, user));
            });

            group.MapPost("/", async (OdontologoDTO dto, IOdontologoService service) =>
            {
                var created = await service.AddAsync(dto);
                return Results.Created($"/api/odontologos/{created.Id}", created);
            }).RequireAuthorization("AdminOnly");

            group.MapPut("/{id:int}", async (int id, OdontologoDTO dto, IOdontologoService service) =>
            {
                dto.Id = id;
                var updated = await service.UpdateAsync(dto);
                return updated ? Results.Ok(dto) : Results.NotFound();
            }).RequireAuthorization("AdminOnly");

            group.MapDelete("/{id:int}", async (int id, IOdontologoService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            }).RequireAuthorization("AdminOnly");
        }

        /// <summary>
        /// Un paciente solo necesita saber quién lo atiende: no recibe el DNI ni el domicilio del profesional.
        /// </summary>
        private static OdontologoDTO ParaUsuario(OdontologoDTO o, ClaimsPrincipal user)
        {
            if (user.EsPersonal()) return o;

            return new OdontologoDTO
            {
                Id = o.Id,
                NumMatricula = o.NumMatricula,
                Nombre = o.Nombre,
                Apellido = o.Apellido,
                Mail = o.Mail,
                Telefono = o.Telefono,
                EspecialidadId = o.EspecialidadId,
                EspecialidadNombre = o.EspecialidadNombre
            };
        }
    }
}
