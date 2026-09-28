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
      
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

           
            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Current = authService;

          
            BaseApiClient.BaseUrl = "http://localhost:5263";

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
    }
}
