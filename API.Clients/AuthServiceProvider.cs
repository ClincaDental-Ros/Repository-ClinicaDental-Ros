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

    public static class AuthServiceProvider
    {
        private static IAuthService? _current;

        public static IAuthService Current
        {
            get => _current ?? throw new InvalidOperationException("AuthService no ha sido inicializado en la aplicación.");
            set => _current = value;
        }

        public static bool IsInitialized => _current != null;
    }
}
