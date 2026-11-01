using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class InsumoListaControl : UserControl
    {
        private readonly InsumoApiClient _apiClient = new();
        private List<InsumoDTO> _insumos = new();

        public InsumoListaControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarInsumos();
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

        private void GridInsumos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ModificarSeleccionado();
        }

        private void GridInsumos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridInsumos.Columns[e.ColumnIndex].Name == "Precio" && e.Value is decimal p)
            {
                e.Value = p.ToString("C2");
            }
            else if (gridInsumos.Columns[e.ColumnIndex].Name == "Stock" && e.Value is int st)
            {
                if (st <= 10 && e.CellStyle != null)
                {
                    e.Value = $"{st} ⚠️ (Crítico)";
                    e.CellStyle.ForeColor = UITheme.Danger;
                    e.CellStyle.Font = UITheme.RegularBold;
                }
                else if (e.CellStyle != null)
                {
                    e.Value = $"{st} u.";
                    e.CellStyle.ForeColor = UITheme.Success;
                }
            }
        }

        public async Task CargarInsumos()
        {
            _insumos = await _apiClient.GetAllAsync();
            gridInsumos.DataSource = null;
            gridInsumos.DataSource = _insumos;

            ActualizarTarjetasMetricas();

            lblEstado.Text = $"Inventario: {_insumos.Count} tipo(s) de insumos. Stock crítico: {_insumos.Count(i => i.Stock <= 10)}.";
        }

        private void ActualizarTarjetasMetricas()
        {
            pnlStats.Controls.Clear();

            int total = _insumos.Count;
            int stockTotal = _insumos.Sum(i => i.Stock);
            int criticos = _insumos.Count(i => i.Stock <= 10);
            decimal valorInventario = _insumos.Sum(i => i.Precio * i.Stock);

            pnlStats.Controls.Add(UITheme.CreateStatCard("Insumos Registrados", total.ToString(), "Materiales distintos", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Stock Total", $"{stockTotal} u.", "Unidades físicas", UITheme.Success));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Stock Crítico", $"{criticos} ítems", "Menor o igual a 10 u.", criticos > 0 ? UITheme.Danger : UITheme.Secondary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Valorizado", valorInventario.ToString("C0"), "Valor en almacén", UITheme.Accent));
        }

        private void AbrirDetalle(InsumoDTO? dto)
        {
            var form = new InsumoDetalleForm(dto);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarInsumos();
            }
        }

        private void ModificarSeleccionado()
        {
            if (gridInsumos.SelectedRows.Count == 0) return;
            var item = (InsumoDTO)gridInsumos.SelectedRows[0].DataBoundItem;
            AbrirDetalle(item);
        }

        private async Task EliminarSeleccionado()
        {
            if (gridInsumos.SelectedRows.Count == 0) return;
            var item = (InsumoDTO)gridInsumos.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Eliminar el insumo '{item.Nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteAsync(item.Id);
                    await CargarInsumos();
                }
                catch (HttpRequestException ex)
                {
                    // Por ejemplo, si otros datos todavía lo usan: se informa sin cerrar la aplicación.
                    MessageBox.Show(FindForm(), $"No se pudo eliminar el insumo.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
