using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class TurnoListaControl : UserControl
    {
        private readonly TurnoApiClient _apiClient = new();
        private readonly OdontologoApiClient _odontologoClient = new();

        private List<TurnoOdontologicoDTO> _turnos = new();

        public TurnoListaControl()
        {
            InitializeComponent();
            dtpFiltroFecha.Value = DateTime.Today;
            if (cbFiltroEstado.Items.Count > 0)
                cbFiltroEstado.SelectedIndex = 0;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private void GridTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
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
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && IsHandleCreated)
                await CargarTurnos();
        }

        private async void CbFiltroOdontologo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && IsHandleCreated)
                await CargarTurnos();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarTurnos();
        }

        private void BtnReservar_Click(object? sender, EventArgs e)
        {
            AbrirReserva();
        }

        private void BtnModificarTurno_Click(object? sender, EventArgs e)
        {
            ModificarTurnoSeleccionado();
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
            catch (Exception ex)
            {
                lblEstado.Text = $"No se pudieron cargar los profesionales: {ex.Message}";
            }
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
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _ = CargarTurnos();
            }
        }

        private void ModificarTurnoSeleccionado()
        {
            if (gridTurnos.SelectedRows.Count == 0) return;

            var turno = (TurnoOdontologicoDTO)gridTurnos.SelectedRows[0].DataBoundItem;
            if (turno.EstadoTurno != "Pendiente")
            {
                MessageBox.Show($"Solo se pueden modificar turnos pendientes. Este turno está {turno.EstadoTurno}.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new TurnoReservaForm(turnoAEditar: turno);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
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
