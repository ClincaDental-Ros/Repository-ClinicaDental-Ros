using API.Clients;
using DTOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class EspecialidadListaControl : UserControl
    {
        private readonly EspecialidadApiClient _apiClient = new();
        private List<EspecialidadDTO> _especialidades = new();

        public EspecialidadListaControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarEspecialidades();
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

        private void GridEspecialidades_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ModificarSeleccionado();
        }

        public async Task CargarEspecialidades()
        {
            _especialidades = await _apiClient.GetAllAsync();
            gridEspecialidades.DataSource = null;
            gridEspecialidades.DataSource = _especialidades;

            pnlStats.Controls.Clear();
            pnlStats.Controls.Add(UITheme.CreateStatCard("Especialidades", _especialidades.Count.ToString(), "Habilitadas en clínica", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Cobertura", "100%", "Integral ambulatoria", UITheme.Success));

            lblEstado.Text = $"Catálogo: {_especialidades.Count} especialidad(es) registradas.";
        }

        private void AbrirDetalle(EspecialidadDTO? dto)
        {
            var form = new EspecialidadDetalleForm(dto);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarEspecialidades();
            }
        }

        private void ModificarSeleccionado()
        {
            if (gridEspecialidades.SelectedRows.Count == 0) return;
            var item = (EspecialidadDTO)gridEspecialidades.SelectedRows[0].DataBoundItem;
            AbrirDetalle(item);
        }

        private async Task EliminarSeleccionado()
        {
            if (gridEspecialidades.SelectedRows.Count == 0) return;
            var item = (EspecialidadDTO)gridEspecialidades.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Eliminar especialidad '{item.Nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(item.Id);
                    await CargarEspecialidades();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show(FindForm(), $"No se pudo eliminar la especialidad.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
