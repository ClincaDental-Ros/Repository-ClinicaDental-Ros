using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class EspecialidadDetalleForm : Form
    {
        private readonly EspecialidadApiClient _apiClient = new();
        private readonly EspecialidadDTO? _especialidadExistente;

        private TextBox txtNombre = null!;
        private TextBox txtDescripcion = null!;
        private Button btnGuardar = null!;
        private Button btnCancelar = null!;
        private Label lblError = null!;

        public EspecialidadDetalleForm(EspecialidadDTO? especialidad = null)
        {
            _especialidadExistente = especialidad;
            InitializeComponent();
            BuildUI();
            if (_especialidadExistente != null)
            {
                txtNombre.Text = _especialidadExistente.Nombre;
                txtDescripcion.Text = _especialidadExistente.Descripcion;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(500, 340);
            this.Name = "EspecialidadDetalleForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = _especialidadExistente == null ? "Nueva Especialidad Odontológica" : "Modificar Especialidad";
            this.Size = new Size(500, 340);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            var lblHeader = new Label
            {
                Text = _especialidadExistente == null ? "🏷️ Registrar Especialidad" : "Editar Especialidad",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 20),
                AutoSize = true
            };
            this.Controls.Add(lblHeader);

            var lblNom = new Label { Text = "Nombre *:", Location = new Point(25, 75), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtNombre = new TextBox { Location = new Point(130, 72), Width = 310 };

            var lblDesc = new Label { Text = "Descripción:", Location = new Point(25, 120), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtDescripcion = new TextBox { Location = new Point(130, 117), Width = 310, Height = 65, Multiline = true };

            lblError = new Label { Text = "", ForeColor = UITheme.Danger, Font = UITheme.SmallFont, Location = new Point(25, 195), Size = new Size(415, 25) };

            var pnlActions = new Panel { Location = new Point(130, 230), Size = new Size(310, 45) };
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
            this.Controls.Add(lblError);
            this.Controls.Add(pnlActions);
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblError.Text = "El nombre de la especialidad es obligatorio.";
                return;
            }

            try
            {
                var dto = new EspecialidadDTO
                {
                    Id = _especialidadExistente?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                if (_especialidadExistente == null)
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

    public class EspecialidadListaControl : UserControl
    {
        private readonly EspecialidadApiClient _apiClient = new();
        private DataGridView gridEspecialidades = null!;
        private FlowLayoutPanel pnlStats = null!;
        private Label lblEstado = null!;
        private List<EspecialidadDTO> _especialidades = new();

        public EspecialidadListaControl()
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
            this.Name = "EspecialidadListaControl";
            this.Size = new Size(1000, 650);
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = UITheme.Background;
            this.Font = UITheme.RegularFont;

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 70, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.CardBackground };
            var lblTitle = new Label { Text = "Especialidades Odontológicas", Font = UITheme.HeaderFont, ForeColor = UITheme.Primary, Location = new Point(25, 12), AutoSize = true };
            var lblSubtitle = new Label { Text = "Catálogo de tratamientos, áreas de atención médica y coberturas", Font = UITheme.SmallFont, ForeColor = UITheme.TextSecondary, Location = new Point(27, 40), AutoSize = true };
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
            var btnNuevo = new Button { Text = "+ Nueva Especialidad", Location = new Point(25, 13), Size = new Size(190, 36) };
            UITheme.StyleSuccessButton(btnNuevo);
            btnNuevo.Click += (s, e) => AbrirDetalle(null);

            var btnEditar = new Button { Text = "✏️ Modificar", Location = new Point(225, 13), Size = new Size(130, 36) };
            UITheme.StyleSecondaryButton(btnEditar);
            btnEditar.Click += (s, e) => ModificarSeleccionado();

            var btnEliminar = new Button { Text = "🗑️ Eliminar", Location = new Point(365, 13), Size = new Size(120, 36) };
            UITheme.StyleDangerButton(btnEliminar);
            btnEliminar.Click += BtnEliminar_Click;

            pnlBar.Controls.Add(btnNuevo);
            pnlBar.Controls.Add(btnEditar);
            pnlBar.Controls.Add(btnEliminar);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.Background };
            gridEspecialidades = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridEspecialidades);
            gridEspecialidades.AutoGenerateColumns = false;

            gridEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, DataPropertyName = "Id" });
            gridEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Especialidad Médica", Width = 260, DataPropertyName = "Nombre" });
            gridEspecialidades.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "Descripción del Alcance Clínico", DataPropertyName = "Descripcion" });
            gridEspecialidades.CellDoubleClick += (s, e) => ModificarSeleccionado();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando especialidades...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridEspecialidades);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlBar);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarEspecialidades();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
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
            if (form.ShowDialog() == DialogResult.OK)
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
                await _apiClient.DeleteAsync(item.Id);
                await CargarEspecialidades();
            }
        }
    }
}
