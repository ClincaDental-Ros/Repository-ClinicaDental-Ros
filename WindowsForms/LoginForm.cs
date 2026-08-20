using API.Auth.WindowsForms;
using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsForms
{
    public class LoginForm : Form
    {
        private readonly AuthApiClient _authClient = new();
        private readonly WindowsFormsAuthService _authService;

        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Label lblError = null!;
        private ComboBox cbPerfilesPrueba = null!;

        public LoginForm(WindowsFormsAuthService authService)
        {
            _authService = authService;
            InitializeComponent();
            BuildUI();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(460, 580);
            Name = "LoginForm";
            ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = "Clínica Odontológica - Acceso al Sistema";
            this.Size = new Size(470, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlCard = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(415, 520),
                BackColor = UITheme.CardBackground,
                Padding = new Padding(30, 25, 30, 25)
            };

            pnlCard.Paint += (s, e) =>
            {
                using var pen = new Pen(UITheme.BorderColor, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
            };

            int y = 15;

            // Logo y Encabezado Limpio (Estilo Frontend.MVC Login.cshtml)
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

            // Inputs
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
                Text = "admin"
            };
            pnlCard.Controls.Add(txtUsername);
            y += 35;

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
                Width = 355,
                Font = UITheme.RegularFont,
                UseSystemPasswordChar = true,
                Text = "admin123"
            };
            pnlCard.Controls.Add(txtPassword);
            y += 35;

            // Selector de Modo Prueba Rápida
            var pnlPilot = new Panel
            {
                Location = new Point(30, y),
                Size = new Size(355, 65),
                BackColor = Color.FromArgb(248, 250, 252)
            };

            pnlPilot.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(203, 213, 225), 1) { DashStyle = DashStyle.Dash };
                e.Graphics.DrawRectangle(pen, 0, 0, pnlPilot.Width - 1, pnlPilot.Height - 1);
            };

            var lblPilotTitle = new Label
            {
                Text = "MODO PRUEBA RÁPIDA / PERFIL:",
                Font = UITheme.SmallBold,
                ForeColor = UITheme.Primary,
                Location = new Point(10, 6),
                AutoSize = true
            };

            cbPerfilesPrueba = new ComboBox
            {
                Location = new Point(10, 28),
                Width = 335,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = UITheme.SmallFont
            };
            cbPerfilesPrueba.Items.AddRange(new object[] {
                "1. Administrador (admin / admin123)",
                "2. Recepcionista (recepcion / recepcion123)",
                "3. Odontólogo - Dr. Gómez (doctor1 / doc123)",
                "4. Odontólogo - Dra. Rossi (doctor2 / doc123)",
                "5. Paciente - Juan Pérez (paciente1 / paciente123)"
            });
            cbPerfilesPrueba.SelectedIndex = 0;
            cbPerfilesPrueba.SelectedIndexChanged += CbPerfilesPrueba_SelectedIndexChanged;

            pnlPilot.Controls.Add(lblPilotTitle);
            pnlPilot.Controls.Add(cbPerfilesPrueba);
            pnlCard.Controls.Add(pnlPilot);
            y += 75;

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

        private void CbPerfilesPrueba_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (cbPerfilesPrueba.SelectedIndex)
            {
                case 0: txtUsername.Text = "admin"; txtPassword.Text = "admin123"; break;
                case 1: txtUsername.Text = "recepcion"; txtPassword.Text = "recepcion123"; break;
                case 2: txtUsername.Text = "doctor1"; txtPassword.Text = "doc123"; break;
                case 3: txtUsername.Text = "doctor2"; txtPassword.Text = "doc123"; break;
                case 4: txtUsername.Text = "paciente1"; txtPassword.Text = "paciente123"; break;
            }
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            await RealizarLogin();
        }

        private async Task RealizarLogin()
        {
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
                    lblError.Text = "Usuario o contraseña inválidos.";
                }
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
