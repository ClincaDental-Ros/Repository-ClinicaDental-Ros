using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class OdontologoListaControl : UserControl
    {
        private readonly OdontologoApiClient _apiClient = new();
        private readonly EspecialidadApiClient _espClient = new();
        private List<OdontologoDTO> _odontologos = new();

        public OdontologoListaControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarFiltroEspecialidades();
            await CargarOdontologos();
        }

        private async void CbFiltroEspecialidad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarOdontologos();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarOdontologos();
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            AbrirDetalle(null);
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            ModificarSeleccionado();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
        }

        private void GridOdontologos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ModificarSeleccionado();
        }

        private async Task CargarFiltroEspecialidades()
        {
            try
            {
                var list = await _espClient.GetAllAsync();
                var items = new List<EspecialidadDTO> { new EspecialidadDTO { Id = 0, Nombre = "Todas las especialidades" } };
                items.AddRange(list);

                cbFiltroEspecialidad.DataSource = items;
                cbFiltroEspecialidad.DisplayMember = "Nombre";
                cbFiltroEspecialidad.ValueMember = "Id";
                cbFiltroEspecialidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"No se pudieron cargar las especialidades: {ex.Message}";
            }
        }

        public async Task CargarOdontologos()
        {
            try
            {
                lblEstado.Text = "Cargando profesionales...";
                int? espId = (cbFiltroEspecialidad.SelectedValue is int id && id > 0) ? id : null;
                _odontologos = await _apiClient.GetAllAsync(espId);
                gridOdontologos.DataSource = null;
                gridOdontologos.DataSource = _odontologos;

                ActualizarTarjetasMetricas();

                lblEstado.Text = $"Cuerpo médico activo: {_odontologos.Count} profesional(es) en nómina.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
            }
        }

        private void ActualizarTarjetasMetricas()
        {
            pnlStats.Controls.Clear();

            int total = _odontologos.Count;
            int especialidadesDistintas = _odontologos.Select(o => o.EspecialidadId).Distinct().Count();

            pnlStats.Controls.Add(UITheme.CreateStatCard("Odontólogos", total.ToString(), "Profesionales activos", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Especialidades", especialidadesDistintas.ToString(), "Áreas cubiertas", UITheme.Accent));
        }

        private void AbrirDetalle(OdontologoDTO? odontologo)
        {
            var form = new OdontologoDetalleForm(odontologo);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarOdontologos();
            }
        }

        private void ModificarSeleccionado()
        {
            if (gridOdontologos.SelectedRows.Count == 0) return;
            var o = (OdontologoDTO)gridOdontologos.SelectedRows[0].DataBoundItem;
            AbrirDetalle(o);
        }

        private async Task EliminarSeleccionado()
        {
            if (gridOdontologos.SelectedRows.Count == 0) return;
            var o = (OdontologoDTO)gridOdontologos.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Desea dar de baja al profesional Dr/a. {o.Apellido}, {o.Nombre}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(o.Id);
                    await CargarOdontologos();
                }
                catch (HttpRequestException ex)
                {
                    // Por ejemplo, si otros datos todavía lo usan: se informa sin cerrar la aplicación.
                    MessageBox.Show(FindForm(), $"No se pudo eliminar el profesional.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
