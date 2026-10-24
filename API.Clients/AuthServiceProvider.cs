namespace API.Clients
{
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
