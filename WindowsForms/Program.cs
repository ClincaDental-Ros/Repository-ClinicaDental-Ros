using API.Auth.WindowsForms;
using API.Clients;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Inicializar el Servicio de Autenticación WinForms
            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Current = authService;

            // 2. Configurar la URL Base de la WebAPI (por defecto localhost:5263)
            BaseApiClient.BaseUrl = "http://localhost:5263";

            // 3. Garantizar que el servidor WebAPI esté ejecutándose
            EnsureWebApiServerRunning();

            // 4. Manejo ante token expirado o 401 Unauthorized
            BaseApiClient.OnUnauthorized += () =>
            {
                authService.ClearSession();
                MessageBox.Show("Su sesión ha expirado o no tiene permisos para la acción solicitada. Por favor, vuelva a iniciar sesión.", "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            // 5. Bucle principal de inicio de sesión y Home Dashboard
            while (true)
            {
                using var loginForm = new LoginForm(authService);
                var loginResult = loginForm.ShowDialog();

                if (loginResult != DialogResult.OK)
                {
                    // El usuario cerró la ventana de login sin autenticarse
                    break;
                }

                using var homeForm = new HomeForm(authService);
                var homeResult = homeForm.ShowDialog();

                if (homeResult != DialogResult.Retry)
                {
                    // El usuario cerró la aplicación
                    break;
                }
            }
        }

        private static void EnsureWebApiServerRunning()
        {
            try
            {
                using var client = new HttpClient { Timeout = TimeSpan.FromMilliseconds(600) };
                var res = client.GetAsync("http://localhost:5263/swagger/v1/swagger.json").GetAwaiter().GetResult();
                if (res.IsSuccessStatusCode)
                {
                    return; // WebAPI ya está corriendo en segundo plano o externamente
                }
            }
            catch
            {
                // WebAPI no está escuchando aún
            }

            try
            {
                // Iniciar el servidor WebAPI en segundo plano de manera instantánea
                _ = Task.Run(() => WebAPI.WebApiServer.StartAsync(new string[] { "--urls", "http://localhost:5263" }));

                // Esperar a que el servidor WebAPI inicialice
                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(300);
                    try
                    {
                        using var c = new HttpClient { Timeout = TimeSpan.FromMilliseconds(400) };
                        var r = c.GetAsync("http://localhost:5263/swagger/v1/swagger.json").GetAwaiter().GetResult();
                        if (r.IsSuccessStatusCode) break;
                    }
                    catch { }
                }
            }
            catch
            {
                // Si ocurre cualquier excepción, el cliente HTTP mostrará el detalle
            }
        }
    }
}
