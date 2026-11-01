using API.Auth.WindowsForms;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class HomeForm : Form
    {
        private readonly WindowsFormsAuthService _authService = null!;

        // Constructor sin parámetros para el Diseñador de Visual Studio
        public HomeForm()
        {
            InitializeComponent();
            PersonalizarFondoMdi();
        }

        public HomeForm(WindowsFormsAuthService authService) : this()
        {
            _authService = authService;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                AplicarPermisosPorRol();
            }
        }

        private void PersonalizarFondoMdi()
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(241, 245, 249);
                }
            }
        }

        private void AplicarPermisosPorRol()
        {
            var rol = _authService?.GetRol() ?? "Admin";

            if (rol == "Paciente")
            {
                itemPacientes.Enabled = false;
                itemOdontologos.Enabled = false;
                itemEspecialidades.Enabled = false;
                itemInsumos.Enabled = false;
                menuClinica.Enabled = false;
                menuCaja.Enabled = false;
                menuReportes.Enabled = false;
                menuPortal.Visible = true;
            }
            else if (rol == "Odontologo")
            {
                itemEspecialidades.Enabled = false;
                itemCobro.Enabled = false;
                menuReportes.Enabled = false;
            }
            else if (rol == "Recepcionista")
            {
                itemAtencion.Enabled = false;
            }
        }

        private void ItemPacientes_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("👥 Gestión de Pacientes", () => new PacienteListaControl());

        private void ItemOdontologos_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("🩺 Odontólogos", () => new OdontologoListaControl());

        private void ItemEspecialidades_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("🏷️ Especialidades", () => new EspecialidadListaControl());

        private void ItemInsumos_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("📦 Insumos y Stock", () => new InsumoListaControl());

        private void ItemConfig_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("⚙️ Configuración", () => new ConfiguracionControl(_authService));

        private void ItemLogout_Click(object? sender, EventArgs e) => CerrarSesion();

        private void ItemSalir_Click(object? sender, EventArgs e) => Application.Exit();

        private void ItemTurnos_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("📅 Gestión de Turnos", () => new TurnoListaControl());

        private void ItemAdmision_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("🛎️ Recepción / Admisión", () => new AdmisionControl());

        private void ItemAtencion_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("💉 Consola Médica", () => new AtencionClinicaControl());

        private void ItemCobro_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("💳 Cobro y Caja", () => new CobroControl());

        private void ItemMetricas_Click(object? sender, EventArgs e) =>
            AbrirModuloMdi("📊 Reportes y Métricas", () => new ReportesControl());

        private void ItemPortalHome_Click(object? sender, EventArgs e) => AbrirPortalPacienteTab(0);
        private void ItemPortalTurnos_Click(object? sender, EventArgs e) => AbrirPortalPacienteTab(1);
        private void ItemPortalHistoria_Click(object? sender, EventArgs e) => AbrirPortalPacienteTab(2);
        private void ItemPortalPagos_Click(object? sender, EventArgs e) => AbrirPortalPacienteTab(3);

        public void AbrirModuloMdi<T>(string titulo, Func<T> factory) where T : UserControl
        {
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
            MostrarVentanaMdi(titulo, control);
        }

        private Form MostrarVentanaMdi(string titulo, UserControl control)
        {
            control.Dock = DockStyle.Fill;

            var mdiChild = new Form
            {
                Text = titulo,
                MdiParent = this,
                Size = new Size(1020, 660),
                StartPosition = FormStartPosition.Manual,
                BackColor = UITheme.Background,
                Font = UITheme.RegularFont,
                ShowIcon = false
            };

            var area = this.ClientSize;
            int alturaBarras = menuMain.Height;
            mdiChild.Location = new Point(
                Math.Max(0, (area.Width - mdiChild.Width) / 2),
                Math.Max(0, (area.Height - alturaBarras - mdiChild.Height) / 2));

            mdiChild.Controls.Add(control);
            mdiChild.Show();
            return mdiChild;
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
            MostrarVentanaMdi("🏠 Portal del Paciente", newPortal);
            newPortal.SeleccionarPestaña(tabIndex);
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
