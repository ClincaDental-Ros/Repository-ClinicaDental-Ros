using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PacienteListaControl : UserControl
    {
        private readonly PacienteApiClient _apiClient = new();
        private List<PacienteDTO> _pacientes = new();

        public PacienteListaControl()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private async void TxtBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await CargarPacientes();
            }
        }

        private async void ChkSoloHabilitados_CheckedChanged(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private async void BtnBuscar_Click(object? sender, EventArgs e)
        {
            await CargarPacientes();
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            AbrirDetalle(null);
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            ModificarSeleccionado();
        }

        private async void BtnToggleEstado_Click(object? sender, EventArgs e)
        {
            await ToggleHabilitacion();
        }

        private async void BtnEliminar_Click(object? sender, EventArgs e)
        {
            await EliminarSeleccionado();
        }

        private void GridPacientes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ModificarSeleccionado();
        }

        private void GridPacientes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridPacientes.Columns[e.ColumnIndex].Name == "Estado" && e.RowIndex >= 0 && e.RowIndex < gridPacientes.Rows.Count)
            {
                if (gridPacientes.Rows[e.RowIndex].DataBoundItem is PacienteDTO p)
                {
                    e.Value = p.EstadoHabilitado ? "✅ Habilitado" : "❌ Inhabilitado";
                    if (e.CellStyle != null)
                    {
                        e.CellStyle.ForeColor = p.EstadoHabilitado ? UITheme.Success : UITheme.Danger;
                        e.CellStyle.Font = UITheme.RegularBold;
                    }
                }
            }
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
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
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
                try
                {
                    paciente.EstadoHabilitado = nuevoEstado;
                    await _apiClient.UpdateAsync(paciente);
                }
                catch (HttpRequestException ex)
                {
                    paciente.EstadoHabilitado = !nuevoEstado;
                    MessageBox.Show(FindForm(), $"No se pudo cambiar el estado del paciente.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                await CargarPacientes();
            }
        }

        private async Task EliminarSeleccionado()
        {
            if (gridPacientes.SelectedRows.Count == 0) return;

            var paciente = (PacienteDTO)gridPacientes.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"¿Está seguro de eliminar la ficha médica del paciente {paciente.Apellido}, {paciente.Nombre}?\nEsta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var ok = await _apiClient.DeleteAsync(paciente.Id);
                    if (ok)
                    {
                        MessageBox.Show("Paciente eliminado con éxito.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarPacientes();
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Por ejemplo, si otros datos todavía lo usan: se informa sin cerrar la aplicación.
                    MessageBox.Show(FindForm(), $"No se pudo eliminar el paciente.\n\n{ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
