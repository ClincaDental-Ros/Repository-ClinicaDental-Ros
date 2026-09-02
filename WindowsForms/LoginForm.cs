using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class LoginForm : Form
    {
        private readonly WindowsFormsAuthService _authService;
        private readonly AuthApiClient _authClient;

        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnPassword = null!;
        private Button btnLogin = null!;
        private Label lblError = null!;

        public LoginForm(WindowsFormsAuthService authService)
        {
            _authService = authService;
            _authClient = new AuthApiClient();

            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Clínica Odontológica - Acceso al Sistema";
            this.Size = new Size(465, 460);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 244, 248);

            var pnlCard = new Panel
            {
                Size = new Size(415, 390),
                Location = new Point(20, 15),
                BackColor = Color.White
            };

            pnlCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
            };

            int y = 20;

            
            var lblLogo = new Label
            {
                Text = "🦷",
                Font = new Font("Segoe UI", 26F),
                Location = new Point(0, y),
                Size = new Size(415, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblLogo);
            y += 48;

            var lblTitle = new Label
            {
                Text = "Clínica Odontológica",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = UITheme.Primary,
                Location = new Point(0, y),
                Size = new Size(415, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblTitle);
            y += 30;

            var lblSub = new Label
            {
                Text = "Gestión Odontológica Profesional • Sede Rosario",
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary,
                Location = new Point(0, y),
                Size = new Size(415, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblSub);
            y += 35;

            
            var lblUser = new Label
            {
                Text = "Usuario / Número de Documento:",
                Font = UITheme.RegularBold,
                ForeColor = UITheme.TextPrimary,
                Location = new Point(30, y),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblUser);
            y += 22;

            txtUsername = new TextBox
            {
                Location = new Point(30, y),
                Width = 355,
                Font = UITheme.RegularFont,
                Text = ""
            };
            pnlCard.Controls.Add(txtUsername);
            y += 35;

            // Contraseña
            var lblPass = new Label
            {
                Text = "Contraseña:",
                Font = UITheme.RegularBold,
                ForeColor = UITheme.TextPrimary,
                Location = new Point(30, y),
                AutoSize = true
            };
            pnlCard.Controls.Add(lblPass);
            y += 22;

            txtPassword = new TextBox
            {
                Location = new Point(30, y),
                Width = 315,
                Font = UITheme.RegularFont,
                UseSystemPasswordChar = true,
                Text = ""
            };

            btnPassword = new Button
            {
                Text = "👁",
                Location = new Point(350, y - 1),
                Size = new Size(35, 27),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = UITheme.Primary
            };
            btnPassword.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnPassword.Click += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
                btnPassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🙈";
            };

            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(btnPassword);
            y += 40;

            lblError = new Label
            {
                Text = "",
                ForeColor = UITheme.Danger,
                Font = UITheme.SmallFont,
                Location = new Point(30, y),
                Size = new Size(355, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblError);
            y += 24;

            btnLogin = new Button
            {
                Text = "Iniciar Sesión",
                Location = new Point(30, y),
                Size = new Size(355, 42)
            };
            UITheme.StylePrimaryButton(btnLogin);
            btnLogin.Click += BtnLogin_Click;
            pnlCard.Controls.Add(btnLogin);
            y += 50;

            var lblFoot = new Label
            {
                Text = "© 2026 Clínica Odontológica Rosario • Todos los derechos reservados",
                Font = new Font("Segoe UI", 7.5F, FontStyle.Regular),
                ForeColor = UITheme.TextSecondary,
                Location = new Point(0, y),
                Size = new Size(415, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlCard.Controls.Add(lblFoot);

            this.AcceptButton = btnLogin;
            this.Controls.Add(pnlCard);
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
