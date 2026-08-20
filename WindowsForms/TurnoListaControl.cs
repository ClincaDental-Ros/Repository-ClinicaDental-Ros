using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class TurnoReservaForm : Form
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly OdontologoApiClient _odontologoClient = new();
        private readonly EspecialidadApiClient _especialidadClient = new();
        private readonly MultaApiClient _multaClient = new();

        private ComboBox cbPaciente = null!;
        private ComboBox cbEspecialidad = null!;
        private ComboBox cbOdontologo = null!;
        private DateTimePicker dtpFecha = null!;
        private ComboBox cbHorario = null!;
        private ComboBox cbMetodoPago = null!;
        private CheckBox chkPoliticas = null!;
        private Label lblEstadoPaciente = null!;
        private Label lblMontoEstimado = null!;
        private Button btnReservar = null!;
        private Button btnCancelar = null!;
        private Label lblError = null!;

        private List<PacienteDTO> _pacientes = new();
        private List<OdontologoDTO> _odontologos = new();
        private List<EspecialidadDTO> _especialidades = new();

        public TurnoReservaForm()
        {
            InitializeComponent();
            BuildUI();
            this.Load += OnFormLoad;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(620, 680);
            this.Name = "TurnoReservaForm";
            this.ResumeLayout(false);
        }

        private void BuildUI()
        {
            this.Text = "Agendar Turno Odontológico - Clínica Dental";
            this.Size = new Size(620, 680);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = UITheme.CardBackground;
            this.Font = UITheme.RegularFont;

            int y = 20;
            int labelWidth = 150;
            int inputWidth = 380;
            int x = 25;

            var lblHeader = new Label
            {
                Text = "📅 Agendamiento de Turno Odontológico",
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

            cbPaciente = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbPaciente.SelectedIndexChanged += CbPaciente_SelectedIndexChanged;
            AddRow("1. Paciente *:", cbPaciente);

            lblEstadoPaciente = new Label
            {
                Text = "",
                Location = new Point(x + labelWidth, y - 5),
                Size = new Size(inputWidth, 24),
                Font = UITheme.SmallBold
            };
            this.Controls.Add(lblEstadoPaciente);
            y += 25;

            cbEspecialidad = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbEspecialidad.SelectedIndexChanged += (s, e) => FiltrarOdontologosPorEspecialidad();
            AddRow("2. Especialidad *:", cbEspecialidad);

            cbOdontologo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            AddRow("3. Profesional *:", cbOdontologo);

            dtpFecha = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Today,
                Value = DateTime.Today.AddDays(1)
            };
            AddRow("4. Fecha de Cita *:", dtpFecha);

            cbHorario = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbHorario.Items.AddRange(new object[] {
                "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
                "12:00", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00"
            });
            cbHorario.SelectedIndex = 2; // 09:00
            AddRow("5. Horario *:", cbHorario);

            cbMetodoPago = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbMetodoPago.Items.AddRange(new object[] { "Obra Social / Cobertura Médica", "Particular (Efectivo / Tarjeta)" });
            cbMetodoPago.SelectedIndex = 0;
            AddRow("6. Cobertura / Pago *:", cbMetodoPago);

            lblMontoEstimado = new Label
            {
                Text = "Arancel Estimado de Consulta: $ 12.000,00 (Sujeto a cobertura)",
                Location = new Point(x + labelWidth, y),
                Size = new Size(inputWidth, 24),
                Font = UITheme.RegularBold,
                ForeColor = UITheme.PrimaryDark
            };
            this.Controls.Add(lblMontoEstimado);
            y += 35;

            chkPoliticas = new CheckBox
            {
                Text = "Acepto las políticas de cancelación (mínimo 24 hs antes) y asistencia.",
                Checked = true,
                Location = new Point(x + labelWidth, y),
                Size = new Size(inputWidth, 30),
                Font = UITheme.SmallBold,
                ForeColor = UITheme.TextPrimary
            };
            this.Controls.Add(chkPoliticas);
            y += 35;

            lblError = new Label
            {
                Text = "",
                ForeColor = UITheme.Danger,
                Font = UITheme.SmallFont,
                Location = new Point(x, y),
                Size = new Size(540, 35)
            };
            this.Controls.Add(lblError);
            y += 40;

            var pnlActions = new Panel { Location = new Point(x + labelWidth, y), Size = new Size(inputWidth, 45) };
            btnReservar = new Button { Text = "✅ Confirmar Reserva", Location = new Point(0, 0), Size = new Size(190, 40) };
            UITheme.StylePrimaryButton(btnReservar);
            btnReservar.Click += BtnReservar_Click;

            btnCancelar = new Button { Text = "Cancelar", Location = new Point(200, 0), Size = new Size(130, 40) };
            UITheme.StyleSecondaryButton(btnCancelar);
            btnCancelar.Click += (s, e) => this.Close();

            pnlActions.Controls.Add(btnReservar);
            pnlActions.Controls.Add(btnCancelar);
            this.Controls.Add(pnlActions);
        }

        private async void OnFormLoad(object? sender, EventArgs e)
        {
            await CargarDatosIniciales();
        }

        private async void CbPaciente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await ValidarPacienteSeleccionado();
        }

        private async void BtnReservar_Click(object? sender, EventArgs e)
        {
            await ReservarTurno();
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                _pacientes = await _pacienteClient.GetAllAsync();
                cbPaciente.DataSource = _pacientes;
                cbPaciente.DisplayMember = "NombreCompleto";
                cbPaciente.ValueMember = "Id";

                _especialidades = await _especialidadClient.GetAllAsync();
                cbEspecialidad.DataSource = _especialidades;
                cbEspecialidad.DisplayMember = "Nombre";
                cbEspecialidad.ValueMember = "Id";

                _odontologos = await _odontologoClient.GetAllAsync();
                FiltrarOdontologosPorEspecialidad();

                await ValidarPacienteSeleccionado();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error cargando datos: {ex.Message}";
            }
        }

        private void FiltrarOdontologosPorEspecialidad()
        {
            if (cbEspecialidad.SelectedValue is int espId && espId > 0)
            {
                var filtrados = _odontologos.Where(o => o.EspecialidadId == espId).ToList();
                cbOdontologo.DataSource = filtrados.Count > 0 ? filtrados : _odontologos;
            }
            else
            {
                cbOdontologo.DataSource = _odontologos;
            }
            cbOdontologo.DisplayMember = "NombreCompleto";
            cbOdontologo.ValueMember = "Id";
        }

        private async Task ValidarPacienteSeleccionado()
        {
            if (cbPaciente.SelectedItem is not PacienteDTO p) return;

            lblError.Text = "";
            btnReservar.Enabled = true;

            if (!p.EstadoHabilitado)
            {
                lblEstadoPaciente.Text = "⚠️ PACIENTE INHABILITADO POR MULTAS O DEUDA";
                lblEstadoPaciente.ForeColor = UITheme.Danger;
                btnReservar.Enabled = false;
                lblError.Text = "El paciente no puede agendar turnos hasta regularizar sus deudas.";
                return;
            }

            try
            {
                var multas = await _multaClient.GetAllAsync(p.Id, soloImpagas: true);
                if (multas.Count > 0)
                {
                    lblEstadoPaciente.Text = $"⚠️ REGISTRA {multas.Count} MULTA(S) IMPAGA(S)";
                    lblEstadoPaciente.ForeColor = UITheme.Danger;
                    btnReservar.Enabled = false;
                    lblError.Text = "El paciente debe saldar sus multas pendientes antes de solicitar un turno.";
                    return;
                }

                lblEstadoPaciente.Text = $"✅ Habilitado - Cobertura: {p.ObraSocialNombre}";
                lblEstadoPaciente.ForeColor = UITheme.Success;
            }
            catch
            {
                lblEstadoPaciente.Text = "✅ Habilitado";
                lblEstadoPaciente.ForeColor = UITheme.Success;
            }
        }

        private async Task ReservarTurno()
        {
            lblError.Text = "";

            if (cbPaciente.SelectedValue is not int pacienteId || pacienteId <= 0)
            {
                lblError.Text = "Seleccione un paciente válido.";
                return;
            }

            if (cbOdontologo.SelectedValue is not int odontologoId || odontologoId <= 0)
            {
                lblError.Text = "Seleccione un odontólogo disponible.";
                return;
            }

            if (!chkPoliticas.Checked)
            {
                lblError.Text = "Debe aceptar las políticas de cancelación y reprogramación.";
                return;
            }

            int especialidadId = cbEspecialidad.SelectedValue is int espId ? espId : 1;
            var horarioStr = cbHorario.SelectedItem?.ToString() ?? "09:00";
            TimeOnly.TryParse(horarioStr, out var horario);

            btnReservar.Enabled = false;

            try
            {
                var dto = new TurnoOdontologicoDTO
                {
                    PacienteId = pacienteId,
                    OdontologoId = odontologoId,
                    EspecialidadId = especialidadId,
                    Fecha = dtpFecha.Value.Date,
                    HorarioTurno = horario,
                    EstadoTurno = "Pendiente",
                    MontoEstimado = 12000m
                };

                var created = await _turnoClient.ReservarAsync(dto);
                if (created != null)
                {
                    MostrarComprobanteDigital(created);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                btnReservar.Enabled = true;
            }
        }

        private void MostrarComprobanteDigital(TurnoOdontologicoDTO t)
        {
            var formTicket = new Form
            {
                Text = "Comprobante de Turno - Clínica Odontológica",
                Size = new Size(480, 520),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = UITheme.Primary, Padding = new Padding(20) };
            var lblT1 = new Label { Text = "🦷 Clínica Dental Rosario", ForeColor = Color.White, Font = UITheme.LargeTitleFont, Location = new Point(20, 15), AutoSize = true };
            var lblT2 = new Label { Text = "COMPROBANTE DE ATENCIÓN / TICKET DIGITAL", ForeColor = UITheme.PrimaryLight, Font = UITheme.SmallBold, Location = new Point(22, 55), AutoSize = true };
            pnlH.Controls.Add(lblT1);
            pnlH.Controls.Add(lblT2);

            var pnlBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25) };
            var lblCodigo = new Label { Text = $"CÓDIGO DE RESERVA: TM-{t.Id:D5}", Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = UITheme.Accent, Location = new Point(25, 15), AutoSize = true };

            int y = 50;
            void AddDetail(string label, string? val)
            {
                var l1 = new Label { Text = label, Location = new Point(25, y), Size = new Size(140, 20), Font = UITheme.SmallBold, ForeColor = UITheme.TextSecondary };
                var l2 = new Label { Text = val ?? "N/A", Location = new Point(170, y), Size = new Size(260, 20), Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
                pnlBody.Controls.Add(l1);
                pnlBody.Controls.Add(l2);
                y += 28;
            }

            AddDetail("PACIENTE:", t.PacienteNombre);
            AddDetail("PROFESIONAL:", t.OdontologoNombre);
            AddDetail("ESPECIALIDAD:", t.EspecialidadNombre);
            AddDetail("FECHA Y HORA:", $"{t.Fecha:dd/MM/yyyy} a las {t.HorarioTurno}");
            AddDetail("UBICACIÓN:", "Consultorio 3 - Piso 1, Sede Rosario");
            AddDetail("ESTADO:", "RESERVA CONFIRMADA (Citado)");

            var btnCerrar = new Button { Text = "Imprimir / Aceptar", Location = new Point(130, y + 20), Size = new Size(180, 38) };
            UITheme.StyleSuccessButton(btnCerrar);
            btnCerrar.Click += (s, e) => formTicket.Close();

            pnlBody.Controls.Add(lblCodigo);
            pnlBody.Controls.Add(btnCerrar);

            formTicket.Controls.Add(pnlBody);
            formTicket.Controls.Add(pnlH);
            formTicket.ShowDialog();
        }
    }

    public class TurnoListaControl : UserControl
    {
        private readonly TurnoApiClient _apiClient = new();
        private readonly OdontologoApiClient _odontologoClient = new();

        private DateTimePicker dtpFiltroFecha = null!;
        private CheckBox chkFiltrarFecha = null!;
        private ComboBox cbFiltroEstado = null!;
        private ComboBox cbFiltroOdontologo = null!;
        private Button btnBuscar = null!;
        private Button btnReservar = null!;
        private Button btnCancelarTurno = null!;
        private DataGridView gridTurnos = null!;
        private Label lblEstado = null!;
        private FlowLayoutPanel pnlStats = null!;
        private List<TurnoOdontologicoDTO> _turnos = new();

        public TurnoListaControl()
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
            this.Name = "TurnoListaControl";
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
                Text = "Gestión de Turnos y Agenda Odontológica",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Monitoreo de citas, estados de atención, cancelaciones y sala de espera",
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

            chkFiltrarFecha = new CheckBox { Text = "Fecha:", Location = new Point(25, 20), AutoSize = true, Checked = false, Font = UITheme.RegularBold };
            dtpFiltroFecha = new DateTimePicker { Location = new Point(95, 17), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            chkFiltrarFecha.CheckedChanged += ChkFiltrarFecha_CheckedChanged;
            dtpFiltroFecha.ValueChanged += DtpFiltroFecha_ValueChanged;

            var lblEst = new Label { Text = "Estado:", Location = new Point(230, 20), AutoSize = true, Font = UITheme.RegularBold };
            cbFiltroEstado = new ComboBox { Location = new Point(290, 17), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cbFiltroEstado.Items.AddRange(new object[] { "Todos los estados", "Pendiente", "Presente", "Atendido", "Cancelado", "NoAsistido" });
            cbFiltroEstado.SelectedIndex = 0;
            cbFiltroEstado.SelectedIndexChanged += CbFiltroEstado_SelectedIndexChanged;

            var lblOdo = new Label { Text = "Odontólogo:", Location = new Point(460, 20), AutoSize = true, Font = UITheme.RegularBold };
            cbFiltroOdontologo = new ComboBox { Location = new Point(555, 17), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbFiltroOdontologo.SelectedIndexChanged += CbFiltroOdontologo_SelectedIndexChanged;

            btnBuscar = new Button { Text = "🔍 Filtrar", Location = new Point(770, 13), Size = new Size(110, 36) };
            UITheme.StylePrimaryButton(btnBuscar);
            btnBuscar.Click += BtnBuscar_Click;

            btnReservar = new Button { Text = "📅 + Agendar Turno", Location = new Point(890, 13), Size = new Size(170, 36) };
            UITheme.StyleSuccessButton(btnReservar);
            btnReservar.Click += (s, e) => AbrirReserva();

            btnCancelarTurno = new Button { Text = "❌ Cancelar Turno", Location = new Point(1070, 13), Size = new Size(140, 36) };
            UITheme.StyleDangerButton(btnCancelarTurno);
            btnCancelarTurno.Click += BtnCancelarTurno_Click;

            pnlFilters.Controls.Add(chkFiltrarFecha);
            pnlFilters.Controls.Add(dtpFiltroFecha);
            pnlFilters.Controls.Add(lblEst);
            pnlFilters.Controls.Add(cbFiltroEstado);
            pnlFilters.Controls.Add(lblOdo);
            pnlFilters.Controls.Add(cbFiltroOdontologo);
            pnlFilters.Controls.Add(btnBuscar);
            pnlFilters.Controls.Add(btnReservar);
            pnlFilters.Controls.Add(btnCancelarTurno);

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(25, 15, 25, 10),
                BackColor = UITheme.Background
            };

            gridTurnos = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridTurnos);
            ConfigurarColumnas();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando turnos...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridTurnos);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlFilters);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private void ConfigurarColumnas()
        {
            gridTurnos.Columns.Clear();
            gridTurnos.AutoGenerateColumns = false;

            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, DataPropertyName = "Id" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha Cita", Width = 110 });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hora", HeaderText = "Horario", Width = 90, DataPropertyName = "HorarioTurno" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente", Width = 200, DataPropertyName = "PacienteNombre" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Odontologo", HeaderText = "Odontólogo Asignado", Width = 200, DataPropertyName = "OdontologoNombre" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", HeaderText = "Especialidad", Width = 170, DataPropertyName = "EspecialidadNombre" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 150, DataPropertyName = "EstadoTurno" });
            gridTurnos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Motivo", HeaderText = "Observación / Motivo", Width = 200, DataPropertyName = "MotivoCancelacion" });

            gridTurnos.CellFormatting += (s, e) =>
            {
                if (gridTurnos.Columns[e.ColumnIndex].Name == "Fecha" && e.RowIndex >= 0 && e.RowIndex < _turnos.Count)
                {
                    e.Value = _turnos[e.RowIndex].Fecha.ToString("dd/MM/yyyy");
                }
                else if (gridTurnos.Columns[e.ColumnIndex].Name == "Estado" && e.Value is string estado && e.CellStyle != null)
                {
                    switch (estado)
                    {
                        case "Pendiente":
                            e.Value = "⏳ Citado (Pendiente)";
                            e.CellStyle.ForeColor = Color.FromArgb(180, 100, 0);
                            break;
                        case "Presente":
                            e.Value = "✅ En Sala de Espera";
                            e.CellStyle.ForeColor = UITheme.Accent;
                            e.CellStyle.Font = UITheme.RegularBold;
                            break;
                        case "Atendido":
                            e.Value = "🩺 Atendido";
                            e.CellStyle.ForeColor = UITheme.Success;
                            break;
                        case "Cancelado":
                            e.Value = "🚫 Cancelado";
                            e.CellStyle.ForeColor = Color.Gray;
                            break;
                        case "NoAsistido":
                            e.Value = "❌ Ausente (Multado)";
                            e.CellStyle.ForeColor = UITheme.Danger;
                            e.CellStyle.Font = UITheme.RegularBold;
                            break;
                    }
                }
            };
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarOdontologosFiltro();
            await CargarTurnos();
        }

        private async void ChkFiltrarFecha_CheckedChanged(object? sender, EventArgs e)
        {
            await CargarTurnos();
        }

        private async void DtpFiltroFecha_ValueChanged(object? sender, EventArgs e)
        {
            if (chkFiltrarFecha.Checked) await CargarTurnos();
        }

        private async void CbFiltroEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarTurnos();
        }

        private async void CbFiltroOdontologo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarTurnos();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarTurnos();
        }

        private async void BtnCancelarTurno_Click(object? sender, EventArgs e)
        {
            await CancelarTurnoSeleccionado();
        }

        private async Task CargarOdontologosFiltro()
        {
            try
            {
                var list = await _odontologoClient.GetAllAsync();
                var items = new List<OdontologoDTO> { new OdontologoDTO { Id = 0, Nombre = "Todos los profesionales" } };
                items.AddRange(list);

                cbFiltroOdontologo.DataSource = items;
                cbFiltroOdontologo.DisplayMember = "NombreCompleto";
                cbFiltroOdontologo.ValueMember = "Id";
                cbFiltroOdontologo.SelectedIndex = 0;
            }
            catch { }
        }

        public async Task CargarTurnos()
        {
            try
            {
                lblEstado.Text = "Cargando turnos...";
                var criteria = new TurnoCriteriaDTO();

                if (chkFiltrarFecha.Checked)
                    criteria.Fecha = dtpFiltroFecha.Value.Date;

                if (cbFiltroEstado.SelectedIndex > 0)
                    criteria.EstadoTurno = cbFiltroEstado.SelectedItem?.ToString();

                if (cbFiltroOdontologo.SelectedValue is int odoId && odoId > 0)
                    criteria.OdontologoId = odoId;

                _turnos = await _apiClient.GetByCriteriaAsync(criteria);
                gridTurnos.DataSource = null;
                gridTurnos.DataSource = _turnos;

                ActualizarTarjetasMetricas();

                lblEstado.Text = $"Agenda cargada: {_turnos.Count} turno(s) en listado.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
            }
        }

        private void ActualizarTarjetasMetricas()
        {
            pnlStats.Controls.Clear();

            int total = _turnos.Count;
            int pendientes = _turnos.Count(t => t.EstadoTurno == "Pendiente");
            int presentes = _turnos.Count(t => t.EstadoTurno == "Presente");
            int atendidos = _turnos.Count(t => t.EstadoTurno == "Atendido");
            int ausentes = _turnos.Count(t => t.EstadoTurno == "NoAsistido");

            pnlStats.Controls.Add(UITheme.CreateStatCard("Total Turnos", total.ToString(), "En el período", UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Citados", pendientes.ToString(), "Por asistir", UITheme.Warning));
            pnlStats.Controls.Add(UITheme.CreateStatCard("En Espera", presentes.ToString(), "Llegaron a clínica", UITheme.Accent));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Atendidos", atendidos.ToString(), "Consultas realizadas", UITheme.Success));
            if (ausentes > 0)
            {
                pnlStats.Controls.Add(UITheme.CreateStatCard("Inasistencias", ausentes.ToString(), "Multados por falta", UITheme.Danger));
            }
        }

        private void AbrirReserva()
        {
            var form = new TurnoReservaForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = CargarTurnos();
            }
        }

        private async Task CancelarTurnoSeleccionado()
        {
            if (gridTurnos.SelectedRows.Count == 0) return;

            var turno = (TurnoOdontologicoDTO)gridTurnos.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno == "Cancelado" || turno.EstadoTurno == "Atendido")
            {
                MessageBox.Show($"No se puede cancelar un turno en estado {turno.EstadoTurno}.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desea cancelar el turno de {turno.PacienteNombre} para el {turno.Fecha:dd/MM/yyyy} a las {turno.HorarioTurno}?", "Cancelar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _apiClient.CancelarAsync(turno.Id, "Cancelación solicitada por el usuario");
                MessageBox.Show("Turno cancelado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTurnos();
            }
        }
    }
}
