using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class OdontologoDetalleForm : Form
    {
        private readonly OdontologoApiClient _apiClient = new();
        private readonly EspecialidadApiClient _espClient = new();
        private readonly OdontologoDTO? _odontologoExistente;
        private List<EspecialidadDTO> _especialidades = new();

        private TextBox txtNombre = null!;
        private TextBox txtApellido = null!;
        private TextBox txtMatricula = null!;
        private TextBox txtDni = null!;
        private TextBox txtTelefono = null!;
        private TextBox txtMail = null!;
        private TextBox txtDomicilio = null!;
        private ComboBox cbEspecialidad = null!;
        private Button btnGuardar = null!;
        private Button btnCancelar = null!;
        private Label lblError = null!;

        public OdontologoDetalleForm(OdontologoDTO? odontologo = null)
        {
            _odontologoExistente = odontologo;
            InitializeComponent();
            BuildUI();
            this.Load += OnFormLoad;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(540, 560);
            this.Name = "OdontologoDetalleForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = _odontologoExistente == null ? "Alta de Profesional - Cuerpo Médico" : "Modificar Profesional";
            this.Size = new Size(540, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            int y = 20;
            int labelWidth = 140;
            int inputWidth = 330;
            int x = 25;

            var lblHeader = new Label
            {
                Text = _odontologoExistente == null ? "🩺 Registrar Odontólogo" : $"Editar Odontólogo #{_odontologoExistente.Id}",
                Font = UITheme.LargeTitleFont,
                ForeColor = UITheme.Primary,
                Location = new Point(x, y),
                AutoSize = true
            };
            this.Controls.Add(lblHeader);
            y += 45;

            void AddRow(string labelText, Control ctrl)
            {
                var lbl = new Label { Text = labelText, Location = new Point(x, y + 3), Size = new Size(labelWidth, 22), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
                ctrl.Location = new Point(x + labelWidth, y);
                ctrl.Size = new Size(inputWidth, 28);
                this.Controls.Add(lbl);
                this.Controls.Add(ctrl);
                y += 38;
            }

            txtMatricula = new TextBox();
            AddRow("N° Matrícula *:", txtMatricula);

            txtNombre = new TextBox();
            AddRow("Nombre *:", txtNombre);

            txtApellido = new TextBox();
            AddRow("Apellido *:", txtApellido);

            txtDni = new TextBox();
            AddRow("DNI *:", txtDni);

            cbEspecialidad = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            AddRow("Especialidad *:", cbEspecialidad);

            txtTelefono = new TextBox();
            AddRow("Teléfono:", txtTelefono);

            txtMail = new TextBox();
            AddRow("Email:", txtMail);

            txtDomicilio = new TextBox();
            AddRow("Domicilio:", txtDomicilio);

            lblError = new Label { Text = "", ForeColor = UITheme.Danger, Font = UITheme.SmallFont, Location = new Point(x, y), Size = new Size(470, 30) };
            this.Controls.Add(lblError);
            y += 35;

            var pnlActions = new Panel { Location = new Point(x + labelWidth, y), Size = new Size(inputWidth, 45) };
            btnGuardar = new Button { Text = "💾 Guardar Profesional", Location = new Point(0, 0), Size = new Size(180, 40) };
            UITheme.StylePrimaryButton(btnGuardar);
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(190, 0), Size = new Size(130, 40) };
            UITheme.StyleSecondaryButton(btnCancelar);
            btnCancelar.Click += (s, e) => this.Close();

            pnlActions.Controls.Add(btnGuardar);
            pnlActions.Controls.Add(btnCancelar);
            this.Controls.Add(pnlActions);
        }

        private async void OnFormLoad(object? sender, EventArgs e)
        {
            await CargarEspecialidades();
            if (_odontologoExistente != null)
            {
                CargarDatos();
            }
        }

        private async Task CargarEspecialidades()
        {
            try
            {
                _especialidades = await _espClient.GetAllAsync();
                cbEspecialidad.DataSource = _especialidades;
                cbEspecialidad.DisplayMember = "Nombre";
                cbEspecialidad.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error cargando especialidades: {ex.Message}";
            }
        }

        private void CargarDatos()
        {
            if (_odontologoExistente == null) return;

            txtMatricula.Text = _odontologoExistente.NumMatricula.ToString();
            txtNombre.Text = _odontologoExistente.Nombre;
            txtApellido.Text = _odontologoExistente.Apellido;
            txtDni.Text = _odontologoExistente.Dni.ToString();
            txtTelefono.Text = _odontologoExistente.Telefono;
            txtMail.Text = _odontologoExistente.Mail;
            txtDomicilio.Text = _odontologoExistente.Domicilio;

            if (_odontologoExistente.EspecialidadId > 0)
            {
                cbEspecialidad.SelectedValue = _odontologoExistente.EspecialidadId;
            }
        }

        private async void BtnGuardar_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                lblError.Text = "Por favor, complete los campos obligatorios (*).";
                return;
            }

            if (!int.TryParse(txtMatricula.Text.Trim(), out var matricula) || matricula <= 0)
            {
                lblError.Text = "La matrícula debe ser un número entero positivo.";
                return;
            }

            int.TryParse(txtDni.Text.Trim(), out var dni);
            int especialidadId = cbEspecialidad.SelectedValue is int id ? id : 1;

            btnGuardar.Enabled = false;

            try
            {
                var dto = new OdontologoDTO
                {
                    Id = _odontologoExistente?.Id ?? 0,
                    NumMatricula = matricula,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = dni,
                    Telefono = txtTelefono.Text.Trim(),
                    Mail = txtMail.Text.Trim(),
                    Domicilio = txtDomicilio.Text.Trim(),
                    EspecialidadId = especialidadId
                };

                if (_odontologoExistente == null)
                {
                    await _apiClient.CreateAsync(dto);
                    MessageBox.Show("Odontólogo registrado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _apiClient.UpdateAsync(dto);
                    MessageBox.Show("Odontólogo modificado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }

    public class OdontologoListaControl : UserControl
    {
        private readonly OdontologoApiClient _apiClient = new();
        private readonly EspecialidadApiClient _espClient = new();

        private ComboBox cbFiltroEspecialidad = null!;
        private Button btnBuscar = null!;
        private Button btnNuevo = null!;
        private Button btnEditar = null!;
        private Button btnEliminar = null!;
        private DataGridView gridOdontologos = null!;
        private Label lblEstado = null!;
        private FlowLayoutPanel pnlStats = null!;
        private List<OdontologoDTO> _odontologos = new();

        public OdontologoListaControl()
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
            this.Name = "OdontologoListaControl";
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
                Text = "Cuerpo Médico Odontológico",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Plantel de profesionales, matrículas habilitadas y asignación de especialidades",
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

            var lblEsp = new Label { Text = "Especialidad:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            cbFiltroEspecialidad = new ComboBox { Location = new Point(125, 17), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
            cbFiltroEspecialidad.SelectedIndexChanged += CbFiltroEspecialidad_SelectedIndexChanged;

            btnBuscar = new Button { Text = "🔄 Refrescar", Location = new Point(400, 13), Size = new Size(120, 36) };
            UITheme.StylePrimaryButton(btnBuscar);
            btnBuscar.Click += BtnBuscar_Click;

            btnNuevo = new Button { Text = "+ Nuevo Profesional", Location = new Point(535, 13), Size = new Size(180, 36) };
            UITheme.StyleSuccessButton(btnNuevo);
            btnNuevo.Click += (s, e) => AbrirDetalle(null);

            btnEditar = new Button { Text = "✏️ Modificar", Location = new Point(725, 13), Size = new Size(120, 36) };
            UITheme.StyleSecondaryButton(btnEditar);
            btnEditar.Click += (s, e) => ModificarSeleccionado();

            btnEliminar = new Button { Text = "🗑️ Eliminar", Location = new Point(855, 13), Size = new Size(110, 36) };
            UITheme.StyleDangerButton(btnEliminar);
            btnEliminar.Click += BtnEliminar_Click;

            pnlFilters.Controls.Add(lblEsp);
            pnlFilters.Controls.Add(cbFiltroEspecialidad);
            pnlFilters.Controls.Add(btnBuscar);
            pnlFilters.Controls.Add(btnNuevo);
            pnlFilters.Controls.Add(btnEditar);
            pnlFilters.Controls.Add(btnEliminar);

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.Background
            };

            gridOdontologos = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridOdontologos);
            ConfigurarColumnas();
            gridOdontologos.CellDoubleClick += (s, e) => ModificarSeleccionado();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando odontólogos...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridOdontologos);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlFilters);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private void ConfigurarColumnas()
        {
            gridOdontologos.Columns.Clear();
            gridOdontologos.AutoGenerateColumns = false;

            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, DataPropertyName = "Id" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Matricula", HeaderText = "Matrícula Nac.", Width = 130, DataPropertyName = "NumMatricula" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido", Width = 160, DataPropertyName = "Apellido" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", Width = 160, DataPropertyName = "Nombre" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", HeaderText = "Especialidad Principal", Width = 200, DataPropertyName = "EspecialidadNombre" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono Directo", Width = 140, DataPropertyName = "Telefono" });
            gridOdontologos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Mail", HeaderText = "Correo Electrónico", Width = 220, DataPropertyName = "Mail" });
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

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
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
            catch { }
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
            pnlStats.Controls.Add(UITheme.CreateStatCard("Atención", "Consultorios 1 al 4", "Sede Central Rosario", UITheme.Success));
        }

        private void AbrirDetalle(OdontologoDTO? odontologo)
        {
            var form = new OdontologoDetalleForm(odontologo);
            if (form.ShowDialog() == DialogResult.OK)
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
                await _apiClient.DeleteAsync(o.Id);
                await CargarOdontologos();
            }
        }
    }
}
