namespace API.Clients
{
    public interface IAuthService
    {
        string? GetToken();
        bool IsAuthenticated();
        string? GetRol();
        string? GetUsername();
        string? GetNombreCompleto();
        int? GetUserId();
        int? GetEntidadId();
        void ClearSession();
    }
}
