using API.Auth.WindowsForms;
using API.Clients;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class HomeForm : Form
    {
        private readonly WindowsFormsAuthService _authService;

        private Panel pnlSidebar = null!;
        private Panel pnlContent = null!;
        private Button? _activeNavButton;
        private Label lblAvatar = null!;
        private Label lblUserName = null!;

        // Controles de módulos
        private PacienteListaControl? _pacienteControl;
        private OdontologoListaControl? _odontologoControl;
        private EspecialidadListaControl? _especialidadControl;
        private InsumoListaControl? _insumoControl;
        private TurnoListaControl? _turnoControl;
        private AdmisionControl? _admisionControl;
        private AtencionClinicaControl? _atencionControl;
        private CobroControl? _cobroControl;
        private ReportesControl? _reportesControl;
        private PacientePortalControl? _portalPacienteControl;
        private ConfiguracionControl? _configuracionControl;

        public HomeForm(WindowsFormsAuthService authService)
        {
            _authService = authService;
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                BuildUI();
                this.Shown += OnFormShown;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1300, 800);
            this.Name = "HomeForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = "Clínica Odontológica - Sistema Integral de Gestión";
            this.Size = new Size(1300, 800);
            this.MinimumSize = new Size(1080, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 260,
                BackColor = UITheme.DarkSidebar,
                Padding = new Padding(0)
            };

            // Logo y Branding Institucional
            var pnlLogo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.FromArgb(10, 15, 30),
                Padding = new Padding(20, 15, 20, 10)
            };

            var lblLogo = new Label
            {
                Text = "🦷 Clínica Odontológica",
                Font = new Font("Segoe UI", 13.5F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 16)
            };

            var lblVer = new Label
            {
                Text = "Sede Rosario • Gestión Profesional",
                Font = UITheme.SmallFont,
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                Location = new Point(18, 48)
            };

            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Controls.Add(lblVer);

            // Sección de Perfil del Usuario Activo
            var pnlUser = new Panel
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.FromArgb(24, 32, 47),
                Padding = new Padding(15, 12, 15, 12)
            };

            var nombre = _authService.GetNombreCompleto() ?? _authService.GetUsername() ?? "Usuario";
            var rol = _authService.GetRol() ?? "Admin";
            var iniciales = nombre.Length > 0 ? nombre[0].ToString().ToUpper() : "U";

            lblAvatar = new Label
            {
                Text = iniciales,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = UITheme.Primary,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(42, 42),
                Location = new Point(15, 16)
            };

            lblUserName = new Label
            {
                Text = nombre,
                Font = UITheme.RegularBold,
                ForeColor = Color.White,
                Location = new Point(65, 14),
                Size = new Size(180, 20),
                AutoEllipsis = true
            };

            var lblUserRol = new Label
            {
                Text = $"ROL: {rol.ToUpper()}  •  ID: #10042",
                Font = UITheme.SmallFont,
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(66, 35),
                Size = new Size(180, 16)
            };

            var lblStatus = new Label
            {
                Text = "● HABILITADO",
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 211, 153),
                Location = new Point(66, 52),
                AutoSize = true
            };

            pnlUser.Controls.Add(lblAvatar);
            pnlUser.Controls.Add(lblUserName);
            pnlUser.Controls.Add(lblUserRol);
            pnlUser.Controls.Add(lblStatus);

            var pnlNav = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, 10, 0, 10)
            };

            Button CrearNavBtn(string text, Action onClick)
            {
                var btn = new Button
                {
                    Text = "  " + text,
                    Dock = DockStyle.Top,
                    Height = 48,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.FromArgb(226, 232, 240),
                    Font = UITheme.RegularBold,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(18, 0, 0, 0),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.MouseEnter += (s, e) => { if (btn != _activeNavButton) btn.BackColor = UITheme.DarkSidebarHover; };
                btn.MouseLeave += (s, e) => { if (btn != _activeNavButton) btn.BackColor = UITheme.DarkSidebar; };
                btn.Click += (s, e) =>
                {
                    SetActiveNavButton(btn);
                    onClick();
                };
                return btn;
            }

            // Construir navegación diferenciada por Rol
            if (rol == "Paciente")
            {
                var btnConfig = CrearNavBtn("⚙️ Mi Configuración", () => CargarModulo(ref _configuracionControl, () => new ConfiguracionControl(_authService, ActualizarPerfilEnSidebar)));
                var btnSeguro = CrearNavBtn("🛡️ Mi Obra Social", () =>
                {
                    CargarModulo(ref _portalPacienteControl, () => new PacientePortalControl(_authService));
                    _portalPacienteControl?.SeleccionarPestaña(4);
                });
                var btnPagos = CrearNavBtn("💳 Pagos y Deudas", () =>
                {
                    CargarModulo(ref _portalPacienteControl, () => new PacientePortalControl(_authService));
                    _portalPacienteControl?.SeleccionarPestaña(3);
                });
                var btnHistoria = CrearNavBtn("📋 Mi Historial Clínico", () =>
                {
                    CargarModulo(ref _portalPacienteControl, () => new PacientePortalControl(_authService));
                    _portalPacienteControl?.SeleccionarPestaña(2);
                });
                var btnMisTurnos = CrearNavBtn("📅 Mis Turnos y Citas", () =>
                {
                    CargarModulo(ref _portalPacienteControl, () => new PacientePortalControl(_authService));
                    _portalPacienteControl?.SeleccionarPestaña(1);
                });
                var btnPortal = CrearNavBtn("🏠 Mi Portal del Paciente", () =>
                {
                    CargarModulo(ref _portalPacienteControl, () => new PacientePortalControl(_authService));
                    _portalPacienteControl?.SeleccionarPestaña(0);
                });

                pnlNav.Controls.Add(btnConfig);
                pnlNav.Controls.Add(btnSeguro);
                pnlNav.Controls.Add(btnPagos);
                pnlNav.Controls.Add(btnHistoria);
                pnlNav.Controls.Add(btnMisTurnos);
                pnlNav.Controls.Add(btnPortal);
            }
            else if (rol == "Odontologo")
            {
                var btnConfig = CrearNavBtn("⚙️ Configuración", () => CargarModulo(ref _configuracionControl, () => new ConfiguracionControl(_authService, ActualizarPerfilEnSidebar)));
                var btnInsumos = CrearNavBtn("📦 Insumos Clínicos", () => CargarModulo(ref _insumoControl, () => new InsumoListaControl()));
                var btnReportes = CrearNavBtn("📋 Historias Clínicas", () => CargarModulo(ref _reportesControl, () => new ReportesControl()));
                var btnPacientes = CrearNavBtn("👥 Fichas de Pacientes", () => CargarModulo(ref _pacienteControl, () => new PacienteListaControl()));
                var btnTurnos = CrearNavBtn("📅 Turnos del Día", () => CargarModulo(ref _admisionControl, () => new AdmisionControl()));
                var btnAtencion = CrearNavBtn("💉 Consola Médica", () => CargarModulo(ref _atencionControl, () => new AtencionClinicaControl()));

                pnlNav.Controls.Add(btnConfig);
                pnlNav.Controls.Add(btnInsumos);
                pnlNav.Controls.Add(btnReportes);
                pnlNav.Controls.Add(btnPacientes);
                pnlNav.Controls.Add(btnTurnos);
                pnlNav.Controls.Add(btnAtencion);
            }
            else if (rol == "Recepcionista")
            {
                var btnConfig = CrearNavBtn("⚙️ Configuración", () => CargarModulo(ref _configuracionControl, () => new ConfiguracionControl(_authService, ActualizarPerfilEnSidebar)));
                var btnCobro = CrearNavBtn("💳 Cobro y Caja", () => CargarModulo(ref _cobroControl, () => new CobroControl()));
                var btnPacientes = CrearNavBtn("👥 Pacientes", () => CargarModulo(ref _pacienteControl, () => new PacienteListaControl()));
                var btnTurnos = CrearNavBtn("📅 Gestión de Turnos", () => CargarModulo(ref _turnoControl, () => new TurnoListaControl()));
                var btnAdmision = CrearNavBtn("🛎️ Recepción / Sala Espera", () => CargarModulo(ref _admisionControl, () => new AdmisionControl()));

                pnlNav.Controls.Add(btnConfig);
                pnlNav.Controls.Add(btnCobro);
                pnlNav.Controls.Add(btnPacientes);
                pnlNav.Controls.Add(btnTurnos);
                pnlNav.Controls.Add(btnAdmision);
            }
            else // Administrador
            {
                var btnConfig = CrearNavBtn("⚙️ Configuración", () => CargarModulo(ref _configuracionControl, () => new ConfiguracionControl(_authService, ActualizarPerfilEnSidebar)));
                var btnReportes = CrearNavBtn("📊 Reportes y Métricas", () => CargarModulo(ref _reportesControl, () => new ReportesControl()));
                var btnCobro = CrearNavBtn("💳 Cobro y Caja", () => CargarModulo(ref _cobroControl, () => new CobroControl()));
                var btnAtencion = CrearNavBtn("💉 Consola Médica", () => CargarModulo(ref _atencionControl, () => new AtencionClinicaControl()));
                var btnAdmision = CrearNavBtn("🛎️ Recepción / Admisión", () => CargarModulo(ref _admisionControl, () => new AdmisionControl()));
                var btnTurnos = CrearNavBtn("📅 Gestión de Turnos", () => CargarModulo(ref _turnoControl, () => new TurnoListaControl()));
                var btnInsumos = CrearNavBtn("📦 Insumos y Stock", () => CargarModulo(ref _insumoControl, () => new InsumoListaControl()));
                var btnEspecialidades = CrearNavBtn("🏷️ Especialidades", () => CargarModulo(ref _especialidadControl, () => new EspecialidadListaControl()));
                var btnOdontologos = CrearNavBtn("🩺 Odontólogos", () => CargarModulo(ref _odontologoControl, () => new OdontologoListaControl()));
                var btnPacientes = CrearNavBtn("👥 Pacientes", () => CargarModulo(ref _pacienteControl, () => new PacienteListaControl()));

                pnlNav.Controls.Add(btnConfig);
                pnlNav.Controls.Add(btnReportes);
                pnlNav.Controls.Add(btnCobro);
                pnlNav.Controls.Add(btnAtencion);
                pnlNav.Controls.Add(btnAdmision);
                pnlNav.Controls.Add(btnTurnos);
                pnlNav.Controls.Add(btnInsumos);
                pnlNav.Controls.Add(btnEspecialidades);
                pnlNav.Controls.Add(btnOdontologos);
                pnlNav.Controls.Add(btnPacientes);
            }

            var pnlLogout = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 65,
                Padding = new Padding(15, 12, 15, 12)
            };

            var btnLogout = new Button
            {
                Text = "🚪 Cerrar Sesión",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.FromArgb(248, 113, 113),
                Font = UITheme.RegularBold,
                Cursor = Cursors.Hand
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) =>
            {
                var result = MessageBox.Show(
                    "¿Está seguro de que desea cerrar sesión?",
                    "Confirmar Cierre de Sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    _authService.ClearSession();
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                }
            };
            pnlLogout.Controls.Add(btnLogout);

            pnlSidebar.Controls.Add(pnlNav);
            pnlSidebar.Controls.Add(pnlLogout);
            pnlSidebar.Controls.Add(pnlUser);
            pnlSidebar.Controls.Add(pnlLogo);

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UITheme.Background
            };

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlSidebar);
        }

        private void ActualizarPerfilEnSidebar()
        {
            var nombre = _authService.GetNombreCompleto() ?? _authService.GetUsername() ?? "Usuario";
            lblUserName.Text = nombre;
            lblAvatar.Text = nombre.Length > 0 ? nombre[0].ToString().ToUpper() : "U";
        }

        private void OnFormShown(object? sender, EventArgs e)
        {
            // Cargar automáticamente la vista por defecto según el rol del usuario
            var rol = _authService.GetRol();
            var navButtons = pnlSidebar.Controls.OfType<Panel>().SelectMany(p => p.Controls.OfType<Button>()).Where(b => b.Text.Trim() != "🚪 Cerrar Sesión").ToList();

            Button? defaultButton = null;
            if (rol == "Paciente")
            {
                defaultButton = navButtons.FirstOrDefault(b => b.Text.Contains("Portal"));
            }
            else if (rol == "Odontologo")
            {
                defaultButton = navButtons.FirstOrDefault(b => b.Text.Contains("Consola"));
            }
            else if (rol == "Recepcionista")
            {
                defaultButton = navButtons.FirstOrDefault(b => b.Text.Contains("Recepción"));
            }

            defaultButton ??= navButtons.FirstOrDefault();
            if (defaultButton != null)
            {
                defaultButton.PerformClick();
            }
        }

        private void SetActiveNavButton(Button btn)
        {
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = UITheme.DarkSidebar;
                _activeNavButton.ForeColor = Color.FromArgb(226, 232, 240);
            }

            _activeNavButton = btn;
            _activeNavButton.BackColor = UITheme.DarkSidebarActive;
            _activeNavButton.ForeColor = Color.White;
        }

        private void CargarModulo<T>(ref T? controlField, Func<T> factory) where T : UserControl
        {
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();

            controlField ??= factory();
            controlField.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(controlField);

            pnlContent.ResumeLayout(true);
        }
    }
}
