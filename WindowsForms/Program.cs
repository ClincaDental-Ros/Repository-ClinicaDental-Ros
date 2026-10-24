using API.Auth.WindowsForms;
using API.Clients;
using System.Text.Json;

namespace WindowsForms
{
    internal static class Program
    {
        private const string ApiUrlPorDefecto = "http://localhost:5263";

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Current = authService;

            BaseApiClient.BaseUrl = LeerUrlApi();

            BaseApiClient.OnUnauthorized += () =>
            {
                authService.ClearSession();
                MessageBox.Show("Su sesión ha expirado o no tiene permisos para la acción solicitada. Por favor, vuelva a iniciar sesión.", "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            while (true)
            {
                using var loginForm = new LoginForm(authService);
                var loginResult = loginForm.ShowDialog();

                if (loginResult != DialogResult.OK)
                {
                    break;
                }

                using var homeForm = new HomeForm(authService);
                var homeResult = homeForm.ShowDialog();

                if (homeResult != DialogResult.Retry)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Lee ApiSettings:BaseUrl de appsettings.json (junto al ejecutable), igual que Blazor.Server.
        /// Si el archivo no existe o no tiene la clave, usa la URL local por defecto.
        /// </summary>
        private static string LeerUrlApi()
        {
            var ruta = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            if (!File.Exists(ruta))
                return ApiUrlPorDefecto;

            try
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(ruta));
                if (doc.RootElement.TryGetProperty("ApiSettings", out var api) &&
                    api.TryGetProperty("BaseUrl", out var url) &&
                    !string.IsNullOrWhiteSpace(url.GetString()))
                {
                    return url.GetString()!;
                }
            }
            catch (JsonException)
            {
                MessageBox.Show($"El archivo {ruta} no es un JSON válido. Se usará {ApiUrlPorDefecto}.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ApiUrlPorDefecto;
        }
    }
}
