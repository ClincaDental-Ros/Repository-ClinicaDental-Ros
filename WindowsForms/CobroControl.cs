using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class CobroControl : UserControl
    {
        private readonly FacturaApiClient _apiClient = new();
        private List<FacturaDTO> _facturas = new();

        public CobroControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private void GridFacturas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridFacturas.Columns[e.ColumnIndex].Name == "Fecha" && e.RowIndex >= 0 && e.RowIndex < _facturas.Count)
            {
                e.Value = _facturas[e.RowIndex].FechaEmision.ToString("dd/MM/yyyy HH:mm");
            }
            else if (gridFacturas.Columns[e.ColumnIndex].Name == "Total" && e.Value is decimal tot)
            {
                e.Value = tot.ToString("C2");
            }
            else if (gridFacturas.Columns[e.ColumnIndex].Name == "DescuentoOS" && e.Value is decimal desc)
            {
                e.Value = $"-{desc:C2}";
                if (e.CellStyle != null) e.CellStyle.ForeColor = UITheme.Success;
            }
            else if (gridFacturas.Columns[e.ColumnIndex].Name == "TotalPaciente" && e.Value is decimal totP)
            {
                e.Value = totP.ToString("C2");
                if (e.CellStyle != null) e.CellStyle.Font = UITheme.RegularBold;
            }
            else if (gridFacturas.Columns[e.ColumnIndex].Name == "Estado" && e.RowIndex >= 0 && e.RowIndex < _facturas.Count)
            {
                var f = _facturas[e.RowIndex];
                e.Value = f.EstadoPago ? "✅ PAGADO" : "⏳ PENDIENTE";
                if (e.CellStyle != null)
                {
                    e.CellStyle.ForeColor = f.EstadoPago ? UITheme.Success : UITheme.Warning;
                    e.CellStyle.Font = UITheme.RegularBold;
                }
            }
        }

        private void GridFacturas_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            AbrirFacturaSeleccionada();
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarFacturas();
        }

        private async void BtnActualizar_Click(object? sender, EventArgs e)
        {
            await CargarFacturas();
        }

        private void BtnCobrar_Click(object? sender, EventArgs e)
        {
            AbrirFacturaSeleccionada();
        }

        private void BtnNueva_Click(object? sender, EventArgs e)
        {
            AbrirEdicion(null);
        }

        private void BtnModificar_Click(object? sender, EventArgs e)
        {
            ModificarSeleccionada();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionadaAsync();
        }

        public async Task CargarFacturas()
        {
            try
            {
                lblEstado.Text = "Cargando facturas...";
                _facturas = await _apiClient.GetAllAsync();
                gridFacturas.DataSource = null;
                gridFacturas.DataSource = _facturas;

                ActualizarTarjetasMetricas();

                lblEstado.Text = $"Total facturas: {_facturas.Count}. Pendientes de cobro en caja: {_facturas.Count(f => !f.EstadoPago)}.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
            }
        }

        private void ActualizarTarjetasMetricas()
        {
            pnlStats.Controls.Clear();

            decimal totalFacturado = _facturas.Sum(f => f.Total);
            decimal totalCobradoPaciente = _facturas.Where(f => f.EstadoPago).Sum(f => f.MontoAPagarPaciente);
            decimal totalLiquidadoOS = _facturas.Sum(f => f.DescuentoObraSocial);
            int pendientes = _facturas.Count(f => !f.EstadoPago);

            pnlStats.Controls.Add(UITheme.CreateStatCard("Total Facturado", totalFacturado.ToString("C0"), "Consultas + Insumos", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Cobrado en Caja", totalCobradoPaciente.ToString("C0"), "Efectivo y Tarjetas", UITheme.Success));
            pnlStats.Controls.Add(UITheme.CreateStatCard("A Liquidar O.S.", totalLiquidadoOS.ToString("C0"), "Obras Sociales", UITheme.Accent));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Pendientes de Cobro", pendientes.ToString(), "Órdenes en espera", pendientes > 0 ? UITheme.Warning : UITheme.Secondary));
        }

        private FacturaDTO? ObtenerSeleccionada()
        {
            if (gridFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show(FindForm(), "Seleccione una factura de la grilla.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return (FacturaDTO)gridFacturas.SelectedRows[0].DataBoundItem;
        }

        private void AbrirFacturaSeleccionada()
        {
            var f = ObtenerSeleccionada();
            if (f == null) return;

            using var form = new FacturaDetalleForm(f);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarFacturas();
            }
        }

        private void AbrirEdicion(FacturaDTO? factura)
        {
            using var form = new FacturaEdicionForm(factura);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarFacturas();
            }
        }

        private void ModificarSeleccionada()
        {
            var f = ObtenerSeleccionada();
            if (f == null) return;

            if (f.EstadoPago)
            {
                MessageBox.Show(FindForm(), "La factura ya fue pagada y no puede modificarse.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirEdicion(f);
        }

        private async Task EliminarSeleccionadaAsync()
        {
            var f = ObtenerSeleccionada();
            if (f == null) return;

            if (f.EstadoPago)
            {
                MessageBox.Show(FindForm(), "La factura ya fue pagada y no puede eliminarse.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(FindForm(), $"¿Eliminar la factura N° {f.Id} de {f.PacienteNombre}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                await _apiClient.EliminarAsync(f.Id);
                await CargarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), $"No se pudo eliminar la factura: {ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
