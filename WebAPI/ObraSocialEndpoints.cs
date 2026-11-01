using Application.Services;

namespace WebAPI
{
    public static class ObraSocialEndpoints
    {
        public static void MapObraSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/obras-sociales")
                .WithTags("Obras sociales")
                .RequireAuthorization();

            group.MapGet("/", async (IObraSocialService service) => Results.Ok(await service.GetAllAsync()));
        }
    }
}
