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

          
            EnsureWebApiServerRunning();

           
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
        private static void EnsureWebApiServerRunning()
        {
            try
            {
                using var client = new HttpClient { Timeout = TimeSpan.FromMilliseconds(600) };
                var res = client.GetAsync("http://localhost:5263/swagger/v1/swagger.json").GetAwaiter().GetResult();
                if (res.IsSuccessStatusCode)
                {
                    return; 
                }
            }
            catch
            {
               
            }

            try
            {
              
                _ = Task.Run(() => WebAPI.WebApiServer.StartAsync(new string[] { "--urls", "http://localhost:5263" }));

              
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
                
            }
        }
    }
}
