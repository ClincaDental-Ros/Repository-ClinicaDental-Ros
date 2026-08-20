using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class PacienteListaControl : UserControl
    {
        private readonly PacienteApiClient _apiClient = new();

        private TextBox txtBuscar = null!;
        private CheckBox chkSoloHabilitados = null!;
        private Button btnBuscar = null!;
        private Button btnNuevo = null!;
        private Button btnEditar = null!;
        private Button btnEliminar = null!;
        private Button btnToggleEstado = null!;
        private DataGridView gridPacientes = null!;
        private Label lblEstado = null!;
        private FlowLayoutPanel pnlStats = null!;
        private List<PacienteDTO> _pacientes = new();

        public PacienteListaControl()
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
            this.Name = "PacienteListaControl";
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
                Text = "Gestión de Pacientes y Fichas Médicas",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Padrón general, control de habilitaciones, obras sociales y antecedentes clínicos",
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

            var pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 65,
                Padding = new Padding(25, 12, 25, 12),
                BackColor = UITheme.CardBackground
            };

            var lblSearch = new Label { Text = "Buscar:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            txtBuscar = new TextBox { Location = new Point(85, 17), Width = 280, PlaceholderText = "Nombre, Apellido, DNI o Email..." };
            txtBuscar.KeyDown += TxtBuscar_KeyDown;

            chkSoloHabilitados = new CheckBox { Text = "Solo Habilitados", Location = new Point(380, 19), AutoSize = true, Font = UITheme.RegularFont };
            chkSoloHabilitados.CheckedChanged += ChkSoloHabilitados_CheckedChanged;

            btnBuscar = new Button { Text = "🔍 Buscar", Location = new Point(515, 13), Size = new Size(110, 36) };
            UITheme.StylePrimaryButton(btnBuscar);
            btnBuscar.Click += BtnBuscar_Click;

            btnNuevo = new Button { Text = "+ Nuevo Paciente", Location = new Point(640, 13), Size = new Size(160, 36) };
            UITheme.StyleSuccessButton(btnNuevo);
            btnNuevo.Click += (s, e) => AbrirDetalle(null);

            btnEditar = new Button { Text = "✏️ Modificar", Location = new Point(810, 13), Size = new Size(120, 36) };
            UITheme.StyleSecondaryButton(btnEditar);
            btnEditar.Click += (s, e) => ModificarSeleccionado();

            btnToggleEstado = new Button { Text = "🔒 Cambiar Estado", Location = new Point(940, 13), Size = new Size(140, 36) };
            UITheme.StyleSecondaryButton(btnToggleEstado);
            btnToggleEstado.Click += BtnToggleEstado_Click;

            btnEliminar = new Button { Text = "🗑️ Eliminar", Location = new Point(1090, 13), Size = new Size(110, 36) };
            UITheme.StyleDangerButton(btnEliminar);
            btnEliminar.Click += BtnEliminar_Click;

            pnlFilters.Controls.Add(lblSearch);
            pnlFilters.Controls.Add(txtBuscar);
            pnlFilters.Controls.Add(chkSoloHabilitados);
            pnlFilters.Controls.Add(btnBuscar);
            pnlFilters.Controls.Add(btnNuevo);
            pnlFilters.Controls.Add(btnEditar);
            pnlFilters.Controls.Add(btnToggleEstado);
            pnlFilters.Controls.Add(btnEliminar);

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.Background
            };

            gridPacientes = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridPacientes);
            ConfigurarColumnas();
            gridPacientes.CellDoubleClick += (s, e) => ModificarSeleccionado();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando pacientes...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridPacientes);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlFilters);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private void ConfigurarColumnas()
        {
            gridPacientes.Columns.Clear();
            gridPacientes.AutoGenerateColumns = false;

            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, DataPropertyName = "Id" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dni", HeaderText = "DNI / Doc.", Width = 110, DataPropertyName = "Dni" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", Width = 150, DataPropertyName = "Apellido" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 150, DataPropertyName = "Nombre" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", Width = 130, DataPropertyName = "Telefono" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Mail", HeaderText = "Correo Electrónico", Width = 220, DataPropertyName = "Mail" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObraSocial", HeaderText = "Obra Social / Cobertura", Width = 180, DataPropertyName = "ObraSocialNombre" });
            gridPacientes.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 140 });

            gridPacientes.CellFormatting += (s, e) =>
            {
                if (gridPacientes.Columns[e.ColumnIndex].Name == "Estado" && e.RowIndex >= 0 && e.RowIndex < _pacientes.Count)
                {
                    var p = _pacientes[e.RowIndex];
                    e.Value = p.EstadoHabilitado ? "✅ Habilitado" : "❌ Inhabilitado";
                    if (e.CellStyle != null)
                    {
                        e.CellStyle.ForeColor = p.EstadoHabilitado ? UITheme.Success : UITheme.Danger;
                        e.CellStyle.Font = UITheme.RegularBold;
                    }
                }
            };
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private async void TxtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) await CargarPacientes();
        }

        private async void ChkSoloHabilitados_CheckedChanged(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private async void BtnToggleEstado_Click(object? sender, EventArgs e)
        {
            await ToggleHabilitacion();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
        }

        public async Task CargarPacientes()
        {
            try
            {
                lblEstado.Text = "Buscando pacientes en la base de datos...";
                var texto = txtBuscar.Text.Trim();
                bool? habilitados = chkSoloHabilitados.Checked ? true : null;

                _pacientes = await _apiClient.GetByCriteriaAsync(texto, habilitados);
                gridPacientes.DataSource = null;
                gridPacientes.DataSource = _pacientes;

                ActualizarTarjetasMetricas();

                lblEstado.Text = $"Padrón activo: {_pacientes.Count} paciente(s) registrado(s). Habilitados: {_pacientes.Count(p => p.EstadoHabilitado)}.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar: {ex.Message}";
            }
        }

        private void ActualizarTarjetasMetricas()
        {
            pnlStats.Controls.Clear();

            int total = _pacientes.Count;
            int habilitados = _pacientes.Count(p => p.EstadoHabilitado);
            int inhabilitados = total - habilitados;
            int conObraSocial = _pacientes.Count(p => p.ObraSocialId.HasValue && p.ObraSocialId.Value != 4);

            pnlStats.Controls.Add(UITheme.CreateStatCard("Total Pacientes", total.ToString(), "Registrados en clínica", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Habilitados", habilitados.ToString(), "Aptos para turnos", UITheme.Success));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Inhabilitados", inhabilitados.ToString(), "Con multas o deudas", inhabilitados > 0 ? UITheme.Danger : UITheme.Secondary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Con Obra Social", conObraSocial.ToString(), "Prepagas y mutuales", UITheme.Accent));
        }

        private void AbrirDetalle(PacienteDTO? paciente)
        {
            var form = new PacienteDetalleForm(paciente);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarPacientes();
            }
        }

        private void ModificarSeleccionado()
        {
            if (gridPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un paciente de la lista.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var paciente = (PacienteDTO)gridPacientes.SelectedRows[0].DataBoundItem;
            AbrirDetalle(paciente);
        }

        private async Task ToggleHabilitacion()
        {
            if (gridPacientes.SelectedRows.Count == 0) return;

            var paciente = (PacienteDTO)gridPacientes.SelectedRows[0].DataBoundItem;
            bool nuevoEstado = !paciente.EstadoHabilitado;
            string accion = nuevoEstado ? "HABILITAR" : "INHABILITAR (Bloqueo de turnos)";

            if (MessageBox.Show($"¿Desea {accion} al paciente {paciente.Apellido}, {paciente.Nombre}?", "Clínica Odontológica - Control de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                paciente.EstadoHabilitado = nuevoEstado;
                await _apiClient.UpdateAsync(paciente);
                await CargarPacientes();
            }
        }

        private async Task EliminarSeleccionado()
        {
            if (gridPacientes.SelectedRows.Count == 0) return;

            var paciente = (PacienteDTO)gridPacientes.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Está seguro de eliminar la ficha médica del paciente {paciente.Apellido}, {paciente.Nombre}?\nEsta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var ok = await _apiClient.DeleteAsync(paciente.Id);
                if (ok)
                {
                    MessageBox.Show("Paciente eliminado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarPacientes();
                }
            }
        }
    }
}
