using API.Clients;
using DTOs;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FacturaDetalleForm : Form
    {
        private readonly FacturaApiClient _apiClient = new();
        private readonly FacturaDTO _factura = null!;

        public FacturaDetalleForm()
        {
            InitializeComponent();
            cbMetodoPago.SelectedIndex = 0;
        }

        public FacturaDetalleForm(FacturaDTO factura) : this()
        {
            _factura = factura;
            CargarDatos();
        }

        private void CargarDatos()
        {
            this.Text = $"Comprobante de Facturación / Liquidación #{_factura.Id:D6}";
            lblTitle.Text = $"🧾 Liquidación Fiscal N° {1000 + _factura.Id:D6}";
            lblFec.Text = $"Fecha de Emisión: {_factura.FechaEmision:dd/MM/yyyy HH:mm}";
            lblPaciente.Text = $"👤 Paciente: {_factura.PacienteNombre}";
            lblOS.Text = $"🛡️ Obra Social / Prepaga: {_factura.ObraSocialNombre}";
            lblSubtotal.Text = $"Subtotal Honorarios + Insumos: {_factura.Subtotal:C2}";
            lblDescuento.Text = $"Descuento Cobertura Obra Social: -{_factura.DescuentoObraSocial:C2}";
            lblTotalPaciente.Text = $"TOTAL A COBRAR PACIENTE: {_factura.MontoAPagarPaciente:C2}";

            // Igual que en la web: primero la línea de honorarios y después los insumos.
            var lineas = new List<ItemFacturaDTO>
            {
                new() { InsumoNombre = "Honorarios profesionales", CantidadInsumo = 1, PrecioUnitario = _factura.Honorarios }
            };
            lineas.AddRange(_factura.Items);
            gridItems.DataSource = lineas;

            if (_factura.EstadoPago)
            {
                btnCobrar.Enabled = false;
                btnCobrar.Text = "✅ Factura Pagada";
                cbMetodoPago.Enabled = false;
            }
        }

        private async void BtnCobrar_Click(object? sender, EventArgs e)
        {
            await RegistrarCobro();
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private async Task RegistrarCobro()
        {
            btnCobrar.Enabled = false;
            try
            {
                var metodo = cbMetodoPago.SelectedItem?.ToString() ?? "Efectivo";
                await _apiClient.PagarAsync(_factura.Id, metodo);

                MessageBox.Show(this, $"Cobro por {_factura.MontoAPagarPaciente:C2} registrado con éxito.\nMedio: {metodo}\n\nComprobante emitido correctamente.", "Clínica Odontológica - Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al registrar el cobro: {ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCobrar.Enabled = true;
            }
        }
    }
}
