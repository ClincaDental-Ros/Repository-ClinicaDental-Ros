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
        private MenuStrip menuMain = null!;
        private StatusStrip statusStrip = null!;
        private ToolStripStatusLabel lblStatusUsuario = null!;
        private ToolStripStatusLabel lblStatusApi = null!;
        private ToolStripStatusLabel lblStatusVentanas = null!;

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
            this.ClientSize = new Size(1300, 850);
            this.Name = "HomeForm";
            this.IsMdiContainer = true;
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = "Clínica Odontológica - Sistema MDI de Gestión Integral";
            this.Size = new Size(1300, 850);
            this.MinimumSize = new Size(1080, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;
            this.IsMdiContainer = true;

            // Personalizar el fondo del MdiClient container
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(241, 245, 249);
                }
            }

            BuildMenuStrip();
            BuildStatusStrip();

            this.MainMenuStrip = menuMain;
            this.Controls.Add(statusStrip);
            this.Controls.Add(menuMain);
        }

        private void BuildMenuStrip()
        {
            menuMain = new MenuStrip
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                Padding = new Padding(6, 4, 6, 4)
            };

            var rol = _authService.GetRol() ?? "Admin";

            // 1. Menú Archivo / Maestros
            var menuMaestros = new ToolStripMenuItem("📁 Maestros") { ForeColor = Color.White };

            var itemPacientes = new ToolStripMenuItem("👥 Pacientes", null, (s, e) => AbrirModuloMdi("👥 Gestión de Pacientes", () => new PacienteListaControl()));
            var itemOdontologos = new ToolStripMenuItem("🩺 Odontólogos", null, (s, e) => AbrirModuloMdi("🩺 Odontólogos", () => new OdontologoListaControl()));
            var itemEspecialidades = new ToolStripMenuItem("🏷️ Especialidades", null, (s, e) => AbrirModuloMdi("🏷️ Especialidades", () => new EspecialidadListaControl()));
            var itemInsumos = new ToolStripMenuItem("📦 Insumos y Stock", null, (s, e) => AbrirModuloMdi("📦 Insumos y Stock", () => new InsumoListaControl()));

            var itemConfig = new ToolStripMenuItem("⚙️ Configuración de Perfil", null, (s, e) => AbrirModuloMdi("⚙️ Configuración", () => new ConfiguracionControl(_authService, ActualizarStatusStrip)));
            var itemLogout = new ToolStripMenuItem("🚪 Cerrar Sesión", null, (s, e) => CerrarSesion());
            var itemSalir = new ToolStripMenuItem("❌ Salir", null, (s, e) => Application.Exit());

            menuMaestros.DropDownItems.Add(itemPacientes);
            menuMaestros.DropDownItems.Add(itemOdontologos);
            menuMaestros.DropDownItems.Add(itemEspecialidades);
            menuMaestros.DropDownItems.Add(itemInsumos);
            menuMaestros.DropDownItems.Add(new ToolStripSeparator());
            menuMaestros.DropDownItems.Add(itemConfig);
            menuMaestros.DropDownItems.Add(new ToolStripSeparator());
            menuMaestros.DropDownItems.Add(itemLogout);
            menuMaestros.DropDownItems.Add(itemSalir);

            // 2. Menú Gestión Clínica
            var menuClinica = new ToolStripMenuItem("🏥 Gestión Clínica") { ForeColor = Color.White };

            var itemTurnos = new ToolStripMenuItem("📅 Gestión de Turnos", null, (s, e) => AbrirModuloMdi("📅 Gestión de Turnos", () => new TurnoListaControl()));
            var itemAdmision = new ToolStripMenuItem("🛎️ Recepción / Sala de Espera", null, (s, e) => AbrirModuloMdi("🛎️ Recepción / Admisión", () => new AdmisionControl()));
            var itemAtencion = new ToolStripMenuItem("💉 Consola Médica", null, (s, e) => AbrirModuloMdi("💉 Consola Médica", () => new AtencionClinicaControl()));

            menuClinica.DropDownItems.Add(itemTurnos);
            menuClinica.DropDownItems.Add(itemAdmision);
            menuClinica.DropDownItems.Add(itemAtencion);

            // 3. Menú Caja y Facturación
            var menuCaja = new ToolStripMenuItem("💳 Caja y Facturación") { ForeColor = Color.White };
            var itemCobro = new ToolStripMenuItem("🧾 Cobro, Caja y Liquidación", null, (s, e) => AbrirModuloMdi("💳 Cobro y Caja", () => new CobroControl()));
            menuCaja.DropDownItems.Add(itemCobro);

            // 4. Menú Reportes
            var menuReportes = new ToolStripMenuItem("📊 Reportes") { ForeColor = Color.White };
            var itemMetricas = new ToolStripMenuItem("📈 Reportes y Métricas", null, (s, e) => AbrirModuloMdi("📊 Reportes y Métricas", () => new ReportesControl()));
            menuReportes.DropDownItems.Add(itemMetricas);

            // 5. Menú Mi Portal (Paciente)
            var menuPortal = new ToolStripMenuItem("👤 Portal Paciente") { ForeColor = Color.White };
            var itemPortalHome = new ToolStripMenuItem("🏠 Mi Portal del Paciente", null, (s, e) => AbrirPortalPacienteTab(0));
            var itemPortalTurnos = new ToolStripMenuItem("📅 Mis Turnos y Citas", null, (s, e) => AbrirPortalPacienteTab(1));
            var itemPortalHistoria = new ToolStripMenuItem("📋 Mi Historial Clínico", null, (s, e) => AbrirPortalPacienteTab(2));
            var itemPortalPagos = new ToolStripMenuItem("💳 Mis Pagos y Deudas", null, (s, e) => AbrirPortalPacienteTab(3));

            menuPortal.DropDownItems.Add(itemPortalHome);
            menuPortal.DropDownItems.Add(itemPortalTurnos);
            menuPortal.DropDownItems.Add(itemPortalHistoria);
            menuPortal.DropDownItems.Add(itemPortalPagos);

            // 6. Menú Ventanas (Organización MDI)
            var menuVentanas = new ToolStripMenuItem("🪟 Ventanas") { ForeColor = Color.White };
            var itemCascada = new ToolStripMenuItem("📐 Organizar en Cascada", null, (s, e) => this.LayoutMdi(MdiLayout.Cascade));
            var itemTileHoriz = new ToolStripMenuItem("📑 Mosaico Horizontal", null, (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal));
            var itemTileVert = new ToolStripMenuItem("📄 Mosaico Vertical", null, (s, e) => this.LayoutMdi(MdiLayout.TileVertical));
            var itemOrganizar = new ToolStripMenuItem("🗃️ Organizar Iconos", null, (s, e) => this.LayoutMdi(MdiLayout.ArrangeIcons));
            var itemCerrarTodas = new ToolStripMenuItem("🗑️ Cerrar Todas las Ventanas", null, (s, e) => CerrarTodasLasVentanas());

            menuVentanas.DropDownItems.Add(itemCascada);
            menuVentanas.DropDownItems.Add(itemTileHoriz);
            menuVentanas.DropDownItems.Add(itemTileVert);
            menuVentanas.DropDownItems.Add(itemOrganizar);
            menuVentanas.DropDownItems.Add(new ToolStripSeparator());
            menuVentanas.DropDownItems.Add(itemCerrarTodas);

            // Aplicar visibilidad y permisos según Rol
            if (rol == "Paciente")
            {
                itemOdontologos.Enabled = false;
                itemEspecialidades.Enabled = false;
                itemInsumos.Enabled = false;
                menuClinica.Enabled = false;
                menuCaja.Enabled = false;
                menuReportes.Enabled = false;
            }
            else if (rol == "Odontologo")
            {
                itemEspecialidades.Enabled = false;
                itemCobro.Enabled = false;
                menuPortal.Visible = false;
            }
            else if (rol == "Recepcionista")
            {
                itemAtencion.Enabled = false;
                itemMetricas.Enabled = false;
                menuPortal.Visible = false;
            }
            else // Admin
            {
                menuPortal.Visible = true;
            }

            menuMain.Items.Add(menuMaestros);
            menuMain.Items.Add(menuClinica);
            menuMain.Items.Add(menuCaja);
            menuMain.Items.Add(menuReportes);
            if (rol == "Paciente" || rol == "Admin")
            {
                menuMain.Items.Add(menuPortal);
            }
            menuMain.Items.Add(menuVentanas);

            // Estilar elementos desplegables con colores agradables
            foreach (ToolStripMenuItem item in menuMain.Items)
            {
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;
            }
        }

        private void BuildStatusStrip()
        {
            statusStrip = new StatusStrip
            {
                BackColor = Color.FromArgb(30, 41, 59),
                ForeColor = Color.White,
                Font = UITheme.SmallFont
            };

            lblStatusUsuario = new ToolStripStatusLabel
            {
                ForeColor = Color.White,
                Font = UITheme.RegularBold
            };

            lblStatusApi = new ToolStripStatusLabel
            {
                Text = "🟢 Conectado a API (localhost:5263)",
                ForeColor = Color.FromArgb(52, 211, 153),
                Margin = new Padding(20, 0, 0, 0)
            };

            lblStatusVentanas = new ToolStripStatusLabel
            {
                Text = "🪟 Ventanas abiertas: 0",
                ForeColor = Color.FromArgb(148, 163, 184),
                Spring = true,
                TextAlign = ContentAlignment.MiddleRight
            };

            statusStrip.Items.Add(lblStatusUsuario);
            statusStrip.Items.Add(lblStatusApi);
            statusStrip.Items.Add(lblStatusVentanas);

            ActualizarStatusStrip();
        }

        private void ActualizarStatusStrip()
        {
            var nombre = _authService.GetNombreCompleto() ?? _authService.GetUsername() ?? "Usuario";
            var rol = _authService.GetRol() ?? "Admin";
            lblStatusUsuario.Text = $"👤 Sesión: {nombre} [{rol.ToUpper()}]";
            lblStatusVentanas.Text = $"🪟 Ventanas abiertas: {this.MdiChildren.Length}";
        }

        private void OnFormShown(object? sender, EventArgs e)
        {
            // Abrir automáticamente el módulo por defecto según el rol en ventana MDI
            var rol = _authService.GetRol();
            if (rol == "Paciente")
            {
                AbrirPortalPacienteTab(0);
            }
            else if (rol == "Odontologo")
            {
                AbrirModuloMdi("💉 Consola Médica", () => new AtencionClinicaControl());
            }
            else if (rol == "Recepcionista")
            {
                AbrirModuloMdi("🛎️ Recepción / Admisión", () => new AdmisionControl());
            }
            else // Admin
            {
                AbrirModuloMdi("📅 Gestión de Turnos", () => new TurnoListaControl());
                AbrirModuloMdi("👥 Gestión de Pacientes", () => new PacienteListaControl());
                this.LayoutMdi(MdiLayout.TileVertical);
            }
            ActualizarStatusStrip();
        }

        public void AbrirModuloMdi<T>(string titulo, Func<T> factory) where T : UserControl
        {
            // Si la ventana MDI ya existe, activarla y traer al frente
            foreach (Form child in this.MdiChildren)
            {
                if (child.Text == titulo || child.Controls.OfType<T>().Any())
                {
                    child.Activate();
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            var control = factory();
            control.Dock = DockStyle.Fill;

            var mdiChild = new Form
            {
                Text = titulo,
                MdiParent = this,
                Size = new Size(1020, 660),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = UITheme.Background,
                Font = UITheme.RegularFont,
                ShowIcon = false
            };

            mdiChild.FormClosed += (s, e) => ActualizarStatusStrip();
            mdiChild.Controls.Add(control);
            mdiChild.Show();
            ActualizarStatusStrip();
        }

        private void AbrirPortalPacienteTab(int tabIndex)
        {
            foreach (Form child in this.MdiChildren)
            {
                var portal = child.Controls.OfType<PacientePortalControl>().FirstOrDefault();
                if (portal != null)
                {
                    child.Activate();
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    portal.SeleccionarPestaña(tabIndex);
                    return;
                }
            }

            var newPortal = new PacientePortalControl(_authService);
            newPortal.Dock = DockStyle.Fill;

            var mdiChild = new Form
            {
                Text = "🏠 Portal del Paciente",
                MdiParent = this,
                Size = new Size(1020, 660),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = UITheme.Background,
                Font = UITheme.RegularFont,
                ShowIcon = false
            };

            mdiChild.FormClosed += (s, e) => ActualizarStatusStrip();
            mdiChild.Controls.Add(newPortal);
            mdiChild.Show();
            newPortal.SeleccionarPestaña(tabIndex);
            ActualizarStatusStrip();
        }

        private void CerrarTodasLasVentanas()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            ActualizarStatusStrip();
        }

        private void CerrarSesion()
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
        }
    }
}
