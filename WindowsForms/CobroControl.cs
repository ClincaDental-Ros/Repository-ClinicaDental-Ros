using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class FacturaDetalleForm : Form
    {
        private readonly FacturaApiClient _apiClient = new();
        private readonly FacturaDTO _factura;

        private Label lblPaciente = null!;
        private Label lblOS = null!;
        private Label lblSubtotal = null!;
        private Label lblDescuento = null!;
        private Label lblTotalPaciente = null!;
        private ComboBox cbMetodoPago = null!;
        private DataGridView gridItems = null!;
        private Button btnCobrar = null!;
        private Button btnCerrar = null!;

        public FacturaDetalleForm(FacturaDTO factura)
        {
            _factura = factura;
            InitializeComponent();
            BuildUI();
            CargarDatos();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(650, 650);
            this.Name = "FacturaDetalleForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = $"Comprobante de Facturación / Liquidación #{_factura.Id:D6}";
            this.Size = new Size(650, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 140, Padding = new Padding(25, 20, 25, 15), BackColor = UITheme.Primary };

            var lblTitle = new Label { Text = $"🧾 Liquidación Fiscal N° {1000 + _factura.Id:D6}", Font = UITheme.LargeTitleFont, ForeColor = Color.White, Location = new Point(25, 15), AutoSize = true };
            lblPaciente = new Label { Text = "Paciente: ...", Font = UITheme.RegularBold, ForeColor = UITheme.PrimaryLight, Location = new Point(25, 50), AutoSize = true };
            lblOS = new Label { Text = "Cobertura Médica: ...", Font = UITheme.RegularFont, ForeColor = Color.FromArgb(220, 235, 255), Location = new Point(25, 75), AutoSize = true };
            var lblFec = new Label { Text = $"Fecha de Emisión: {_factura.FechaEmision:dd/MM/yyyy HH:mm}", Font = UITheme.SmallFont, ForeColor = Color.FromArgb(180, 210, 240), Location = new Point(25, 100), AutoSize = true };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblPaciente);
            pnlTop.Controls.Add(lblOS);
            pnlTop.Controls.Add(lblFec);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.Background };
            var lblDetalle = new Label { Text = "Detalle de Honorarios Profesionales e Insumos Consumidos:", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Dock = DockStyle.Top, Height = 30 };

            gridItems = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridItems);
            gridItems.AutoGenerateColumns = false;

            gridItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Concepto", HeaderText = "Insumo / Concepto Prestacional", Width = 300, DataPropertyName = "InsumoNombre" });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cant.", Width = 80, DataPropertyName = "CantidadInsumo" });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "P. Unitario", Width = 110, DataPropertyName = "PrecioUnitario" });
            gridItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal ($)", Width = 110, DataPropertyName = "Subtotal" });

            pnlGrid.Controls.Add(gridItems);
            pnlGrid.Controls.Add(lblDetalle);

            var pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 210, Padding = new Padding(25, 15, 25, 15), BackColor = Color.FromArgb(245, 248, 252) };

            lblSubtotal = new Label { Text = "Subtotal Honorarios + Insumos: $0.00", Font = UITheme.RegularFont, ForeColor = UITheme.TextPrimary, Location = new Point(25, 12), AutoSize = true };
            lblDescuento = new Label { Text = "Descuento Cobertura Obra Social: -$0.00", Font = UITheme.RegularBold, ForeColor = UITheme.Success, Location = new Point(25, 38), AutoSize = true };
            lblTotalPaciente = new Label { Text = "TOTAL A COBRAR PACIENTE: $0.00", Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = UITheme.Primary, Location = new Point(25, 68), AutoSize = true };

            var lblMetodo = new Label { Text = "Medio de Pago:", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(25, 112), AutoSize = true };
            cbMetodoPago = new ComboBox { Location = new Point(145, 108), Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
            cbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de Débito", "Tarjeta de Crédito", "Transferencia Bancaria / QR" });
            cbMetodoPago.SelectedIndex = 0;

            btnCobrar = new Button { Text = "💳 Registrar Cobro en Caja", Location = new Point(25, 150), Size = new Size(220, 42) };
            UITheme.StyleSuccessButton(btnCobrar);
            btnCobrar.Click += BtnCobrar_Click;

            btnCerrar = new Button { Text = "Cerrar", Location = new Point(255, 150), Size = new Size(130, 42) };
            UITheme.StyleSecondaryButton(btnCerrar);
            btnCerrar.Click += (s, e) => this.Close();

            pnlBottom.Controls.Add(lblSubtotal);
            pnlBottom.Controls.Add(lblDescuento);
            pnlBottom.Controls.Add(lblTotalPaciente);
            pnlBottom.Controls.Add(lblMetodo);
            pnlBottom.Controls.Add(cbMetodoPago);
            pnlBottom.Controls.Add(btnCobrar);
            pnlBottom.Controls.Add(btnCerrar);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlTop);
        }

        private void CargarDatos()
        {
            lblPaciente.Text = $"👤 Paciente: {_factura.PacienteNombre}";
            lblOS.Text = $"🛡️ Obra Social / Prepaga: {_factura.ObraSocialNombre}";
            lblSubtotal.Text = $"Subtotal Honorarios + Insumos: {_factura.Subtotal:C2}";
            lblDescuento.Text = $"Descuento Cobertura Obra Social: -{_factura.DescuentoObraSocial:C2}";
            lblTotalPaciente.Text = $"TOTAL A COBRAR PACIENTE: {_factura.MontoAPagarPaciente:C2}";

            gridItems.DataSource = _factura.Items;

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

        private async Task RegistrarCobro()
        {
            btnCobrar.Enabled = false;
            try
            {
                var metodo = cbMetodoPago.SelectedItem?.ToString() ?? "Efectivo";
                await _apiClient.PagarAsync(_factura.Id, metodo);

                MessageBox.Show($"Cobro por {_factura.MontoAPagarPaciente:C2} registrado con éxito.\nMedio: {metodo}\n\nComprobante emitido correctamente.", "Clínica Odontológica - Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cobro: {ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCobrar.Enabled = true;
            }
        }
    }

    public class CobroControl : UserControl
    {
        private readonly FacturaApiClient _apiClient = new();
        private DataGridView gridFacturas = null!;
        private FlowLayoutPanel pnlStats = null!;
        private Button btnCobrar = null!;
        private Button btnActualizar = null!;
        private Label lblEstado = null!;
        private List<FacturaDTO> _facturas = new();

        public CobroControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                BuildUI();
                this.Load += OnControlLoad;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "CobroControl";
            this.Size = new Size(1000, 650);
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.CardBackground
            };

            var lblTitle = new Label
            {
                Text = "Módulo de Cobro, Caja y Liquidación a Obras Sociales",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Emisión de comprobantes, liquidación de coseguros, descuentos de obras sociales y pagos recibidos",
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary,
                Location = new Point(27, 40),
                AutoSize = true
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSubtitle);

            pnlStats = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 95,
                Padding = new Padding(25, 10, 25, 5),
                BackColor = UITheme.Background,
                WrapContents = false,
                AutoScroll = true
            };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };

            btnActualizar = new Button { Text = "🔄 Actualizar Lista", Location = new Point(25, 13), Size = new Size(150, 36) };
            UITheme.StylePrimaryButton(btnActualizar);
            btnActualizar.Click += BtnActualizar_Click;

            btnCobrar = new Button { Text = "🧾 Abrir Detalle y Cobrar", Location = new Point(185, 13), Size = new Size(210, 36) };
            UITheme.StyleSuccessButton(btnCobrar);
            btnCobrar.Click += (s, e) => AbrirFacturaSeleccionada();

            pnlBar.Controls.Add(btnActualizar);
            pnlBar.Controls.Add(btnCobrar);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.Background };
            gridFacturas = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridFacturas);
            ConfigurarColumnas();
            gridFacturas.CellDoubleClick += (s, e) => AbrirFacturaSeleccionada();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando facturas...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridFacturas);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlBar);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private void ConfigurarColumnas()
        {
            gridFacturas.Columns.Clear();
            gridFacturas.AutoGenerateColumns = false;

            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Factura N°", Width = 90, DataPropertyName = "Id" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha Emisión", Width = 130, DataPropertyName = "FechaEmision" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente", Width = 200, DataPropertyName = "PacienteNombre" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObraSocial", HeaderText = "Obra Social", Width = 160, DataPropertyName = "ObraSocialNombre" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total Prestación", Width = 130, DataPropertyName = "Total" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DescuentoOS", HeaderText = "Desc. Obra Social", Width = 140, DataPropertyName = "DescuentoObraSocial" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalPaciente", HeaderText = "A Pagar Paciente", Width = 140, DataPropertyName = "MontoAPagarPaciente" });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado Cobro", Width = 130 });
            gridFacturas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Metodo", HeaderText = "Medio de Pago", Width = 160, DataPropertyName = "MetodoPago" });

            gridFacturas.CellFormatting += (s, e) =>
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
            };
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarFacturas();
        }

        private async void BtnActualizar_Click(object? sender, EventArgs e)
        {
            await CargarFacturas();
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

        private void AbrirFacturaSeleccionada()
        {
            if (gridFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una factura de la grilla.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var f = (FacturaDTO)gridFacturas.SelectedRows[0].DataBoundItem;
            var form = new FacturaDetalleForm(f);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarFacturas();
            }
        }
    }
}
