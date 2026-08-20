using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class InsumoDetalleForm : Form
    {
        private readonly InsumoApiClient _apiClient = new();
        private readonly InsumoDTO? _insumoExistente;

        private TextBox txtNombre = null!;
        private TextBox txtDescripcion = null!;
        private TextBox txtPrecio = null!;
        private TextBox txtStock = null!;
        private Button btnGuardar = null!;
        private Button btnCancelar = null!;
        private Label lblError = null!;

        public InsumoDetalleForm(InsumoDTO? insumo = null)
        {
            _insumoExistente = insumo;
            InitializeComponent();
            BuildUI();
            if (_insumoExistente != null)
            {
                txtNombre.Text = _insumoExistente.Nombre;
                txtDescripcion.Text = _insumoExistente.Descripcion;
                txtPrecio.Text = _insumoExistente.Precio.ToString("F2");
                txtStock.Text = _insumoExistente.Stock.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(500, 420);
            this.Name = "InsumoDetalleForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = _insumoExistente == null ? "Nuevo Insumo / Material Odontológico" : "Modificar Insumo";
            this.Size = new Size(500, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            var lblHeader = new Label
            {
                Text = _insumoExistente == null ? "📦 Registrar Insumo" : "Editar Insumo",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 20),
                AutoSize = true
            };
            this.Controls.Add(lblHeader);

            var lblNom = new Label { Text = "Nombre *:", Location = new Point(25, 75), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtNombre = new TextBox { Location = new Point(130, 72), Width = 310 };

            var lblDesc = new Label { Text = "Descripción:", Location = new Point(25, 115), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtDescripcion = new TextBox { Location = new Point(130, 112), Width = 310, Height = 55, Multiline = true };

            var lblPrecio = new Label { Text = "Precio Unit. ($) *:", Location = new Point(25, 180), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtPrecio = new TextBox { Location = new Point(130, 177), Width = 150, Text = "0.00" };

            var lblStock = new Label { Text = "Stock Inicial *:", Location = new Point(25, 220), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtStock = new TextBox { Location = new Point(130, 217), Width = 150, Text = "10" };

            lblError = new Label { Text = "", ForeColor = UITheme.Danger, Font = UITheme.SmallFont, Location = new Point(25, 260), Size = new Size(415, 25) };

            var pnlActions = new Panel { Location = new Point(130, 295), Size = new Size(310, 45) };
            btnGuardar = new Button { Text = "💾 Guardar", Location = new Point(0, 0), Size = new Size(150, 38) };
            UITheme.StylePrimaryButton(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(160, 0), Size = new Size(140, 38) };
            UITheme.StyleSecondaryButton(btnCancelar);
            btnCancelar.Click += (s, e) => this.Close();

            pnlActions.Controls.Add(btnGuardar);
            pnlActions.Controls.Add(btnCancelar);

            this.Controls.Add(lblNom);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblDesc);
            this.Controls.Add(txtDescripcion);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(txtPrecio);
            this.Controls.Add(lblStock);
            this.Controls.Add(txtStock);
            this.Controls.Add(lblError);
            this.Controls.Add(pnlActions);
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblError.Text = "El nombre del insumo es obligatorio.";
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out var precio) || precio < 0)
            {
                lblError.Text = "El precio debe ser un número válido mayor o igual a 0.";
                return;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out var stock) || stock < 0)
            {
                lblError.Text = "El stock debe ser un número entero no negativo.";
                return;
            }

            try
            {
                var dto = new InsumoDTO
                {
                    Id = _insumoExistente?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = precio,
                    Stock = stock
                };

                if (_insumoExistente == null)
                    await _apiClient.CreateAsync(dto);
                else
                    await _apiClient.UpdateAsync(dto);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    public class InsumoListaControl : UserControl
    {
        private readonly InsumoApiClient _apiClient = new();
        private DataGridView gridInsumos = null!;
        private FlowLayoutPanel pnlStats = null!;
        private Label lblEstado = null!;
        private List<InsumoDTO> _insumos = new();

        public InsumoListaControl()
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
            this.Name = "InsumoListaControl";
            this.Size = new Size(1000, 650);
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 70, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.CardBackground };
            var lblTitle = new Label { Text = "Control de Insumos, Materiales y Stock Clínico", Font = UITheme.HeaderFont, ForeColor = UITheme.Primary, Location = new Point(25, 12), AutoSize = true };
            var lblSubtitle = new Label { Text = "Inventario odontológico, costos unitarios y control de stock crítico", Font = UITheme.SmallFont, ForeColor = UITheme.TextSecondary, Location = new Point(27, 40), AutoSize = true };
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
            var btnNuevo = new Button { Text = "+ Nuevo Insumo", Location = new Point(25, 13), Size = new Size(170, 36) };
            UITheme.StyleSuccessButton(btnNuevo);
            btnNuevo.Click += (s, e) => AbrirDetalle(null);

            var btnEditar = new Button { Text = "✏️ Modificar", Location = new Point(205, 13), Size = new Size(130, 36) };
            UITheme.StyleSecondaryButton(btnEditar);
            btnEditar.Click += (s, e) => ModificarSeleccionado();

            var btnEliminar = new Button { Text = "🗑️ Eliminar", Location = new Point(345, 13), Size = new Size(120, 36) };
            UITheme.StyleDangerButton(btnEliminar);
            btnEliminar.Click += BtnEliminar_Click;

            pnlBar.Controls.Add(btnNuevo);
            pnlBar.Controls.Add(btnEditar);
            pnlBar.Controls.Add(btnEliminar);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.Background };
            gridInsumos = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridInsumos);
            gridInsumos.AutoGenerateColumns = false;

            gridInsumos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, DataPropertyName = "Id" });
            gridInsumos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Insumo / Material", Width = 260, DataPropertyName = "Nombre" });
            gridInsumos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción", Width = 280, DataPropertyName = "Descripcion" });
            gridInsumos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio Unitario ($)", Width = 160, DataPropertyName = "Precio" });
            gridInsumos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock Disponible", Width = 150, DataPropertyName = "Stock" });
            gridInsumos.CellDoubleClick += (s, e) => ModificarSeleccionado();

            gridInsumos.CellFormatting += (s, e) =>
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
            };

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando inventario...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridInsumos);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlBar);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarInsumos();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
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
            if (form.ShowDialog() == DialogResult.OK)
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
                await _apiClient.DeleteAsync(item.Id);
                await CargarInsumos();
            }
        }
    }
}
