using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
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
                    // Por ejemplo, si otros datos todavía lo usan: se informa sin cerrar la aplicación.
                    MessageBox.Show(FindForm(), $"No se pudo eliminar la especialidad.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
