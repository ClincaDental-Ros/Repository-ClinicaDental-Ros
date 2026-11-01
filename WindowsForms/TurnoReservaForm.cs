using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class TurnoReservaForm : Form
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly PacienteApiClient _pacienteClient = new();
        private readonly OdontologoApiClient _odontologoClient = new();
        private readonly EspecialidadApiClient _especialidadClient = new();
        private readonly MultaApiClient _multaClient = new();

        private List<PacienteDTO> _pacientes = new();
        private List<OdontologoDTO> _odontologos = new();
        private List<EspecialidadDTO> _especialidades = new();
        private readonly int? _pacienteFijoId;
        private readonly TurnoOdontologicoDTO? _turnoAEditar;
        private bool EsEdicion => _turnoAEditar != null;

        /// <param name="pacienteFijoId">Si se indica (portal del paciente), solo se puede reservar para ese paciente.</param>
        /// <param name="turnoAEditar">Si se indica, el formulario modifica (reprograma) ese turno en lugar de crear uno nuevo.</param>
        public TurnoReservaForm(int? pacienteFijoId = null, TurnoOdontologicoDTO? turnoAEditar = null)
        {
            _pacienteFijoId = pacienteFijoId;
            _turnoAEditar = turnoAEditar;
            InitializeComponent();

            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today.AddDays(1);
            if (cbHorario.Items.Count > 2) cbHorario.SelectedIndex = 2;
            if (cbMetodoPago.Items.Count > 0) cbMetodoPago.SelectedIndex = 0;

            if (EsEdicion)
            {
                this.Text = "Modificar Turno Odontológico - Clínica Dental";
                lblHeader.Text = $"✏️ Modificar / Reprogramar Turno #{_turnoAEditar!.Id}";
                btnReservar.Text = "💾 Guardar Cambios";
            }

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnFormLoad;
            }
        }

        private async void OnFormLoad(object? sender, EventArgs e)
        {
            await CargarDatosIniciales();
        }

        private async void CbPaciente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await ValidarPacienteSeleccionado();
        }

        private void CbEspecialidad_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarOdontologosPorEspecialidad();
        }

        private async void BtnReservar_Click(object? sender, EventArgs e)
        {
            await ReservarTurno();
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                if (_pacienteFijoId.HasValue || EsEdicion)
                {
                    // Al modificar un turno el paciente no cambia
                    var propio = await _pacienteClient.GetByIdAsync(_turnoAEditar?.PacienteId ?? _pacienteFijoId!.Value);
                    _pacientes = propio != null ? new List<PacienteDTO> { propio } : new List<PacienteDTO>();
                    cbPaciente.Enabled = false;
                }
                else
                {
                    _pacientes = await _pacienteClient.GetAllAsync();
                }
                cbPaciente.DataSource = _pacientes;
                cbPaciente.DisplayMember = "NombreCompleto";
                cbPaciente.ValueMember = "Id";

                _especialidades = await _especialidadClient.GetAllAsync();
                cbEspecialidad.DataSource = _especialidades;
                cbEspecialidad.DisplayMember = "Nombre";
                cbEspecialidad.ValueMember = "Id";

                _odontologos = await _odontologoClient.GetAllAsync();

                if (EsEdicion)
                {
                    CargarDatosDelTurno(_turnoAEditar!);
                    return;
                }

                FiltrarOdontologosPorEspecialidad();

                await ValidarPacienteSeleccionado();
            }
            catch (Exception ex)
            {
                lblError.Text = $"Error cargando datos: {ex.Message}";
            }
        }

        private void CargarDatosDelTurno(TurnoOdontologicoDTO t)
        {
            cbEspecialidad.SelectedValue = t.EspecialidadId;
            FiltrarOdontologosPorEspecialidad();
            cbOdontologo.SelectedValue = t.OdontologoId;
            dtpFecha.Value = t.Fecha.Date < DateTime.Today ? DateTime.Today : t.Fecha.Date;

            var hora = t.HorarioTurno.ToString("HH:mm");
            if (!cbHorario.Items.Contains(hora)) cbHorario.Items.Add(hora);
            cbHorario.SelectedItem = hora;

            lblEstadoPaciente.Text = $"Turno {t.EstadoTurno} del {t.Fecha:dd/MM/yyyy} a las {hora} hs";
            lblEstadoPaciente.ForeColor = UITheme.TextSecondary;
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
            // Al modificar no se crea un turno nuevo, así que no se revalida al paciente
            if (EsEdicion) return;
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
            catch (Exception ex)
            {
                // La API vuelve a validar multas al reservar; acá solo se informa
                lblEstadoPaciente.Text = $"⚠️ No se pudieron verificar las multas: {ex.Message}";
                lblEstadoPaciente.ForeColor = UITheme.Warning;
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
                if (EsEdicion)
                {
                    var t = _turnoAEditar!;
                    var cambios = new TurnoOdontologicoDTO
                    {
                        Id = t.Id,
                        PacienteId = t.PacienteId,
                        OdontologoId = odontologoId,
                        EspecialidadId = especialidadId,
                        Fecha = dtpFecha.Value.Date,
                        HorarioTurno = horario,
                        EstadoTurno = t.EstadoTurno,
                        MotivoCancelacion = t.MotivoCancelacion,
                        MontoEstimado = t.MontoEstimado
                    };

                    await _turnoClient.UpdateAsync(cambios);
                    MessageBox.Show($"Turno #{t.Id} reprogramado para el {cambios.Fecha:dd/MM/yyyy} a las {horarioStr} hs.", "Clínica Odontológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

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
            AddDetail("ESTADO:", "RESERVA CONFIRMADA (Citado)");

            var btnCerrar = new Button { Text = "Imprimir / Aceptar", Location = new Point(130, y + 20), Size = new Size(180, 38) };
            UITheme.StyleSuccessButton(btnCerrar);
            btnCerrar.Click += (s, e) => formTicket.Close();

            pnlBody.Controls.Add(lblCodigo);
            pnlBody.Controls.Add(btnCerrar);

            formTicket.Controls.Add(pnlBody);
            formTicket.Controls.Add(pnlH);
            formTicket.ShowDialog(FindForm());
        }
    }
}
