using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Pantalla de inicio de sesión. Los controles y sus propiedades están en LoginForm.Designer.cs
    /// (se editan con el Diseñador de Windows Forms); acá queda solo la lógica.
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly WindowsFormsAuthService _authService = null!;
        private readonly AuthApiClient _authClient = null!;

        // Constructor sin parámetros: lo usa el Diseñador de Visual Studio para mostrar el formulario.
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(WindowsFormsAuthService authService) : this()
        {
            _authService = authService;
            _authClient = new AuthApiClient();
        }

        // Borde gris de la tarjeta blanca
        private void PnlCard_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(UITheme.BorderColor, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
        }

        // Muestra u oculta la contraseña
        private void BtnPassword_Click(object? sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnPassword.Text = txtPassword.UseSystemPasswordChar ? UITheme.IconoVer : UITheme.IconoOcultar;
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            await RealizarLogin();
        }

        private async Task RealizarLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Ingresá tu usuario y contraseña.";
                return;
            }

            lblError.Text = "";
            btnLogin.Enabled = false;
            btnLogin.Text = "Autenticando...";

            try
            {
                var request = new LoginRequestDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };

                var response = await _authClient.LoginAsync(request);
                if (response != null && !string.IsNullOrWhiteSpace(response.Token))
                {
                    _authService.SetSession(response);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Usuario no existente o contraseña incorrecta.";
                }
            }
            catch (HttpRequestException)
            {
                lblError.Text = "Error de conexión con el servidor o la base de datos.";
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error de conexión: {ex.Message}";
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }
    }
}
