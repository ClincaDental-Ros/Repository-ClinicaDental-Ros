using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AdmisionControl : UserControl
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly MultaApiClient _multaClient = new();
        private List<TurnoOdontologicoDTO> _turnos = new();

        public AdmisionControl()
        {
            InitializeComponent();
            gridAdmision.AutoGenerateColumns = false;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private void GridAdmision_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((gridAdmision.Columns[e.ColumnIndex].Name == "Estado" || gridAdmision.Columns[e.ColumnIndex].Name == "colEstado") && e.Value is string estado && e.CellStyle != null)
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
            form.ShowDialog(FindForm());
        }
    }
}
