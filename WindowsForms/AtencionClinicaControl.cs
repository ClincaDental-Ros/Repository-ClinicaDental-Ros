using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class AtencionClinicaControl : UserControl
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly ConsultaApiClient _consultaClient = new();
        private readonly InsumoApiClient _insumoClient = new();

        private List<TurnoOdontologicoDTO> _turnosPresentes = new();
        private List<InsumoDTO> _insumosDisponibles = new();

        public AtencionClinicaControl()
        {
            InitializeComponent();
            cbTratamiento.SelectedIndex = 1;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarDatos();
        }

        private void CbTurnosPresentes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ActualizarInfoPaciente();
        }

        private async void BtnActualizar_Click(object? sender, EventArgs e)
        {
            await CargarTurnosPresentes();
        }

        private async void BtnFinalizar_Click(object? sender, EventArgs e)
        {
            await FinalizarAtencion();
        }

        public async Task CargarDatos()
        {
            await CargarInsumos();
            await CargarTurnosPresentes();
        }

        private async Task CargarInsumos()
        {
            try
            {
                _insumosDisponibles = await _insumoClient.GetAllAsync();
                clbInsumos.Items.Clear();
                foreach (var ins in _insumosDisponibles)
                {
                    clbInsumos.Items.Add($"{ins.Nombre} - ${ins.Precio:N0} (Stock: {ins.Stock})");
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"No se pudieron cargar los insumos: {ex.Message}";
            }
        }

        private async Task CargarTurnosPresentes()
        {
            try
            {
                var hoy = await _turnoClient.GetHoyAsync(DateTime.Today);
                _turnosPresentes = hoy.Where(t => t.EstadoTurno == "Presente").ToList();

                cbTurnosPresentes.DataSource = null;
                cbTurnosPresentes.Items.Clear();

                if (_turnosPresentes.Count == 0)
                {
                    cbTurnosPresentes.Items.Add("No hay pacientes esperando en sala (Estado: Presente)");
                    cbTurnosPresentes.SelectedIndex = 0;
                    btnFinalizar.Enabled = false;
                    lblPacienteInfo.Text = "ℹ️ Solicite a Recepción confirmar la presencia del paciente citado para habilitar la atención.";
                }
                else
                {
                    cbTurnosPresentes.DataSource = _turnosPresentes;
                    cbTurnosPresentes.DisplayMember = "PacienteNombre";
                    cbTurnosPresentes.ValueMember = "Id";
                    btnFinalizar.Enabled = true;
                    ActualizarInfoPaciente();
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
            }
        }

        private void ActualizarInfoPaciente()
        {
            if (cbTurnosPresentes.SelectedItem is TurnoOdontologicoDTO t)
            {
                lblPacienteInfo.Text = $"👤 Paciente: {t.PacienteNombre} | Profesional: {t.OdontologoNombre} | Especialidad: {t.EspecialidadNombre} | Turno: {t.HorarioTurno}";
            }
        }

        private async Task FinalizarAtencion()
        {
            if (cbTurnosPresentes.SelectedItem is not TurnoOdontologicoDTO turno) return;

            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
            {
                MessageBox.Show("Debe ingresar un diagnóstico clínico.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnFinalizar.Enabled = false;

            try
            {
                var insumosConsumidos = new List<ItemFacturaDTO>();
                for (int i = 0; i < clbInsumos.Items.Count; i++)
                {
                    if (clbInsumos.GetItemChecked(i) && i < _insumosDisponibles.Count)
                    {
                        var ins = _insumosDisponibles[i];
                        insumosConsumidos.Add(new ItemFacturaDTO
                        {
                            InsumoId = ins.Id,
                            InsumoNombre = ins.Nombre,
                            CantidadInsumo = 1,
                            PrecioUnitario = ins.Precio
                        });
                    }
                }

                var consultaDto = new ConsultaDTO
                {
                    TurnoId = turno.Id,
                    Diagnostico = txtDiagnostico.Text.Trim(),
                    Tratamiento = cbTratamiento.SelectedItem?.ToString() ?? "Tratamiento Odontológico",
                    Observaciones = txtObservaciones.Text.Trim(),
                    AnestesiaLocal = chkAnestesia.Checked,
                    Radiografias = chkRadiografia.Checked,
                    InsumosUtilizados = insumosConsumidos,
                    Fecha = DateTime.Now
                };

                await _consultaClient.RegistrarAsync(consultaDto);

                MessageBox.Show($"¡Atención médica registrada exitosamente!\n\nSe ha emitido la orden de cobro a Caja y se actualizaron los insumos consumidos.", "Clínica Odontológica - Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarTurnosPresentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al finalizar la consulta: {ex.Message}", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFinalizar.Enabled = true;
            }
        }
    }
}
