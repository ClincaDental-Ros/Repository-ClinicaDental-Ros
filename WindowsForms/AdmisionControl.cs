using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class AdmisionControl : UserControl
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly MultaApiClient _multaClient = new();

        private DateTimePicker dtpFecha = null!;
        private Button btnBuscar = null!;
        private Button btnConfirmarPresencia = null!;
        private Button btnRegistrarAusencia = null!;
        private Button btnVerMultas = null!;
        private DataGridView gridAdmision = null!;
        private FlowLayoutPanel pnlStats = null!;
        private Label lblEstado = null!;
        private List<TurnoOdontologicoDTO> _turnos = new();

        public AdmisionControl()
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
            this.Name = "AdmisionControl";
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
                Text = "Módulo de Recepción y Admisión Diaria",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Control de sala de espera, confirmación de presencia y aplicación de sanciones por ausentismo",
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

            var pnlBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 65,
                Padding = new Padding(25, 12, 25, 12),
                BackColor = UITheme.CardBackground
            };

            var lblFec = new Label { Text = "Fecha de Admisión:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpFecha = new DateTimePicker { Location = new Point(170, 17), Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            dtpFecha.ValueChanged += DtpFecha_ValueChanged;

            btnBuscar = new Button { Text = "🔄 Actualizar", Location = new Point(315, 13), Size = new Size(120, 36) };
            UITheme.StylePrimaryButton(btnBuscar);
            btnBuscar.Click += BtnBuscar_Click;

            btnConfirmarPresencia = new Button { Text = "✅ Confirmar Presencia", Location = new Point(450, 13), Size = new Size(190, 36) };
            UITheme.StyleSuccessButton(btnConfirmarPresencia);
            btnConfirmarPresencia.Click += BtnConfirmarPresencia_Click;

            btnRegistrarAusencia = new Button { Text = "⚠️ Registrar Ausencia (Multa)", Location = new Point(650, 13), Size = new Size(230, 36) };
            UITheme.StyleDangerButton(btnRegistrarAusencia);
            btnRegistrarAusencia.Click += BtnRegistrarAusencia_Click;

            btnVerMultas = new Button { Text = "💳 Cobro de Multas", Location = new Point(890, 13), Size = new Size(160, 36) };
            UITheme.StyleSecondaryButton(btnVerMultas);
            btnVerMultas.Click += BtnVerMultas_Click;

            pnlBar.Controls.Add(lblFec);
            pnlBar.Controls.Add(dtpFecha);
            pnlBar.Controls.Add(btnBuscar);
            pnlBar.Controls.Add(btnConfirmarPresencia);
            pnlBar.Controls.Add(btnRegistrarAusencia);
            pnlBar.Controls.Add(btnVerMultas);

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10), BackColor = UITheme.Background };
            gridAdmision = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridAdmision);
            ConfigurarColumnas();

            lblEstado = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 32,
                Text = "Cargando citas...",
                ForeColor = UITheme.TextSecondary,
                Font = UITheme.SmallFont,
                Padding = new Padding(25, 6, 0, 0),
                BackColor = UITheme.CardBackground
            };

            pnlGrid.Controls.Add(gridAdmision);

            this.Controls.Add(pnlGrid);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlBar);
            this.Controls.Add(pnlStats);
            this.Controls.Add(pnlTop);
        }

        private void ConfigurarColumnas()
        {
            gridAdmision.Columns.Clear();
            gridAdmision.AutoGenerateColumns = false;

            gridAdmision.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hora", HeaderText = "Horario", Width = 90, DataPropertyName = "HorarioTurno" });
            gridAdmision.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente Citado", Width = 240, DataPropertyName = "PacienteNombre" });
            gridAdmision.Columns.Add(new DataGridViewTextBoxColumn { Name = "Odontologo", HeaderText = "Profesional Asignado", Width = 230, DataPropertyName = "OdontologoNombre" });
            gridAdmision.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", HeaderText = "Especialidad", Width = 200, DataPropertyName = "EspecialidadNombre" });
            gridAdmision.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado Actual", Width = 180, DataPropertyName = "EstadoTurno" });

            gridAdmision.CellFormatting += (s, e) =>
            {
                if (gridAdmision.Columns[e.ColumnIndex].Name == "Estado" && e.Value is string estado && e.CellStyle != null)
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
                            e.Value = "🩺 Atendido / En Caja";
                            e.CellStyle.ForeColor = UITheme.Success;
                            break;
                        case "NoAsistido":
                            e.Value = "❌ Ausente (Multado)";
                            e.CellStyle.ForeColor = UITheme.Danger;
                            e.CellStyle.Font = UITheme.RegularBold;
                            break;
                        case "Cancelado":
                            e.Value = "🚫 Cancelado";
                            e.CellStyle.ForeColor = Color.Gray;
                            break;
                    }
                }
            };
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarTurnosDelDia();
        }

        private async void DtpFecha_ValueChanged(object? sender, EventArgs e)
        {
            await CargarTurnosDelDia();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarTurnosDelDia();
        }

        private async void BtnConfirmarPresencia_Click(object? sender, EventArgs e)
        {
            await ConfirmarPresencia();
        }

        private async void BtnRegistrarAusencia_Click(object? sender, EventArgs e)
        {
            await RegistrarAusencia();
        }

        private async void BtnVerMultas_Click(object? sender, EventArgs e)
        {
            await VerCobroMultas();
        }

        public async Task CargarTurnosDelDia()
        {
            try
            {
                lblEstado.Text = "Cargando citas del día...";
                _turnos = await _turnoClient.GetHoyAsync(dtpFecha.Value.Date);
                gridAdmision.DataSource = null;
                gridAdmision.DataSource = _turnos;

                ActualizarTarjetasMetricas();

                lblEstado.Text = $"Total citados para hoy: {_turnos.Count} paciente(s). En sala de espera: {_turnos.Count(t => t.EstadoTurno == "Presente")}.";
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
            int presentes = _turnos.Count(t => t.EstadoTurno == "Presente");
            int atendidos = _turnos.Count(t => t.EstadoTurno == "Atendido");
            int ausentes = _turnos.Count(t => t.EstadoTurno == "NoAsistido");

            pnlStats.Controls.Add(UITheme.CreateStatCard("Turnos Hoy", total.ToString(), dtpFecha.Value.ToString("dd/MM/yyyy"), UITheme.Primary));
            pnlStats.Controls.Add(UITheme.CreateStatCard("En Sala de Espera", presentes.ToString(), "Listos para atender", UITheme.Accent));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Atendidos", atendidos.ToString(), "Consultas concluidas", UITheme.Success));
            pnlStats.Controls.Add(UITheme.CreateStatCard("Ausencias / Multas", ausentes.ToString(), "Inasistencias registradas", ausentes > 0 ? UITheme.Danger : UITheme.Secondary));
        }

        private async Task ConfirmarPresencia()
        {
            if (gridAdmision.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente de la grilla para confirmar su llegada.", "TurnoMolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var turno = (TurnoOdontologicoDTO)gridAdmision.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno != "Pendiente")
            {
                MessageBox.Show($"El turno ya se encuentra en estado '{turno.EstadoTurno}'.", "TurnoMolar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _turnoClient.ConfirmarPresenciaAsync(turno.Id);
            MessageBox.Show($"Llegada confirmada. El paciente {turno.PacienteNombre} pasa a sala de espera.", "TurnoMolar - Admisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarTurnosDelDia();
        }

        private async Task RegistrarAusencia()
        {
            if (gridAdmision.SelectedRows.Count == 0) return;

            var turno = (TurnoOdontologicoDTO)gridAdmision.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno != "Pendiente")
            {
                MessageBox.Show($"No se puede registrar ausencia a un turno en estado '{turno.EstadoTurno}'.", "TurnoMolar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Confirmar ausencia del paciente {turno.PacienteNombre}?\n\nAl registrar la ausencia se generará automáticamente una MULTA de $3.500 y el paciente quedará INHABILITADO para futuros turnos.", "Registrar Ausencia y Sanción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _turnoClient.RegistrarAusenciaAsync(turno.Id, "Inasistencia sin previo aviso en el horario asignado", 3500m);
                MessageBox.Show("Ausencia registrada. Se aplicó la multa e inhabilitación correspondiente.", "TurnoMolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTurnosDelDia();
            }
        }

        private async Task VerCobroMultas()
        {
            var multas = await _multaClient.GetAllAsync(soloImpagas: true);
            if (multas.Count == 0)
            {
                MessageBox.Show("No hay multas impagas pendientes en este momento.", "Caja de Multas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form
            {
                Text = "Cobro y Liquidación de Multas - TurnoMolar",
                Size = new Size(720, 460),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = UITheme.CardBackground,
                Font = UITheme.RegularFont
            };

            var pnlH = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = UITheme.Primary, Padding = new Padding(20, 15, 20, 10) };
            var lblT = new Label { Text = "💳 Liquidación y Cobro de Multas por Inasistencia", ForeColor = Color.White, Font = UITheme.HeaderFont, AutoSize = true };
            pnlH.Controls.Add(lblT);

            var grid = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(grid);
            grid.AutoGenerateColumns = false;
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID Multa", Width = 80, DataPropertyName = "Id" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente Sancionado", Width = 220, DataPropertyName = "PacienteNombre" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Monto", HeaderText = "Monto ($)", Width = 120, DataPropertyName = "Monto" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Motivo", HeaderText = "Motivo de la Sanción", DataPropertyName = "Motivo" });
            grid.DataSource = multas;

            var pnlBtns = new Panel { Dock = DockStyle.Bottom, Height = 65, Padding = new Padding(20, 12, 20, 12), BackColor = UITheme.Background };
            var btnPagar = new Button { Text = "💳 Cobrar y Rehabilitar Paciente", Location = new Point(20, 12), Size = new Size(270, 38) };
            UITheme.StyleSuccessButton(btnPagar);
            btnPagar.Click += async (s, e) =>
            {
                if (grid.SelectedRows.Count == 0) return;
                var m = (MultaDTO)grid.SelectedRows[0].DataBoundItem;
                await _multaClient.PagarAsync(m.Id);
                MessageBox.Show($"Multa #{m.Id} cobrada con éxito. El paciente ha sido REHABILITADO.", "TurnoMolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.Close();
                await CargarTurnosDelDia();
            };

            pnlBtns.Controls.Add(btnPagar);

            form.Controls.Add(grid);
            form.Controls.Add(pnlBtns);
            form.Controls.Add(pnlH);
            form.ShowDialog();
        }
    }
}
