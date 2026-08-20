using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class AtencionClinicaControl : UserControl
    {
        private readonly TurnoApiClient _turnoClient = new();
        private readonly ConsultaApiClient _consultaClient = new();
        private readonly InsumoApiClient _insumoClient = new();

        private ComboBox cbTurnosPresentes = null!;
        private TextBox txtDiagnostico = null!;
        private ComboBox cbTratamiento = null!;
        private TextBox txtObservaciones = null!;
        private CheckBox chkAnestesia = null!;
        private CheckBox chkRadiografia = null!;
        private CheckedListBox clbInsumos = null!;
        private Button btnFinalizar = null!;
        private Button btnActualizar = null!;
        private Label lblPacienteInfo = null!;
        private Label lblEstado = null!;

        private List<TurnoOdontologicoDTO> _turnosPresentes = new();
        private List<InsumoDTO> _insumosDisponibles = new();

        public AtencionClinicaControl()
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
            this.Name = "AtencionClinicaControl";
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
                Text = "Consola Médica Odontológica - Evolución Clínica",
                Font = UITheme.HeaderFont,
                ForeColor = UITheme.Primary,
                Location = new Point(25, 12),
                AutoSize = true
            };

            var lblSubtitle = new Label
            {
                Text = "Diagnóstico (CIE-10), tratamientos realizados, consumo de insumos y derivación automática a facturación",
                Font = UITheme.SmallFont,
                ForeColor = UITheme.TextSecondary,
                Location = new Point(27, 40),
                AutoSize = true
            };

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSubtitle);

            var pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(25, 15, 25, 15),
                AutoScroll = true,
                BackColor = UITheme.CardBackground
            };

            int y = 15;
            int x = 20;

            var lblTurno = new Label { Text = "1. Paciente en Sala de Espera (Estado: Presente):", Font = UITheme.SubheaderFont, ForeColor = UITheme.Primary, Location = new Point(x, y), AutoSize = true };
            pnlBody.Controls.Add(lblTurno);
            y += 35;

            cbTurnosPresentes = new ComboBox { Location = new Point(x, y), Width = 520, DropDownStyle = ComboBoxStyle.DropDownList };
            cbTurnosPresentes.SelectedIndexChanged += CbTurnosPresentes_SelectedIndexChanged;

            btnActualizar = new Button { Text = "🔄 Refrescar Espera", Location = new Point(x + 535, y - 2), Size = new Size(170, 32) };
            UITheme.StyleSecondaryButton(btnActualizar);
            btnActualizar.Click += BtnActualizar_Click;

            pnlBody.Controls.Add(cbTurnosPresentes);
            pnlBody.Controls.Add(btnActualizar);
            y += 35;

            lblPacienteInfo = new Label { Text = "", Font = UITheme.RegularBold, ForeColor = UITheme.TextSecondary, Location = new Point(x, y), Size = new Size(720, 25) };
            pnlBody.Controls.Add(lblPacienteInfo);
            y += 35;

            var lblDiag = new Label { Text = "2. Diagnóstico Clínico / Código CIE-10 *:", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(x, y), AutoSize = true };
            pnlBody.Controls.Add(lblDiag);
            y += 25;

            txtDiagnostico = new TextBox { Location = new Point(x, y), Width = 720, Text = "K02.1 Caries de la dentina / Restauración estética" };
            pnlBody.Controls.Add(txtDiagnostico);
            y += 35;

            var lblTrat = new Label { Text = "3. Tipo de Tratamiento Odontológico Realizado *:", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(x, y), AutoSize = true };
            pnlBody.Controls.Add(lblTrat);
            y += 25;

            cbTratamiento = new ComboBox { Location = new Point(x, y), Width = 420, DropDownStyle = ComboBoxStyle.DropDownList };
            cbTratamiento.Items.AddRange(new object[] {
                "Limpieza y Profilaxis Dental",
                "Restauración con Resina Fotocurable",
                "Tratamiento de Conducto (Endodoncia)",
                "Extracción Simple",
                "Extracción Quirúrgica / Implante",
                "Ajuste y Control de Ortodoncia",
                "Consulta y Diagnóstico General"
            });
            cbTratamiento.SelectedIndex = 1;
            pnlBody.Controls.Add(cbTratamiento);
            y += 35;

            var pnlChecks = new Panel { Location = new Point(x, y), Size = new Size(720, 35) };
            chkAnestesia = new CheckBox { Text = "Aplicó Anestesia Local", Location = new Point(0, 5), AutoSize = true, Font = UITheme.RegularBold, Checked = true, ForeColor = UITheme.TextPrimary };
            chkRadiografia = new CheckBox { Text = "Tomó Radiografías Periapicales / Panorámicas", Location = new Point(240, 5), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            pnlChecks.Controls.Add(chkAnestesia);
            pnlChecks.Controls.Add(chkRadiografia);
            pnlBody.Controls.Add(pnlChecks);
            y += 40;

            var lblObs = new Label { Text = "4. Observaciones y Evolución Clínica:", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(x, y), AutoSize = true };
            pnlBody.Controls.Add(lblObs);
            y += 25;

            txtObservaciones = new TextBox { Location = new Point(x, y), Width = 720, Height = 65, Multiline = true, Text = "Paciente tolera adecuadamente el procedimiento. Se indica control preventivo en 6 meses." };
            pnlBody.Controls.Add(txtObservaciones);
            y += 80;

            var lblIns = new Label { Text = "5. Insumos Consumidos durante la Atención (Se descontarán de Stock automáticamente):", Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary, Location = new Point(x, y), AutoSize = true };
            pnlBody.Controls.Add(lblIns);
            y += 25;

            clbInsumos = new CheckedListBox { Location = new Point(x, y), Width = 720, Height = 100, CheckOnClick = true };
            pnlBody.Controls.Add(clbInsumos);
            y += 115;

            btnFinalizar = new Button { Text = "🩺 Finalizar Atención y Enviar Orden a Caja", Location = new Point(x, y), Size = new Size(360, 44) };
            UITheme.StyleSuccessButton(btnFinalizar);
            btnFinalizar.Click += BtnFinalizar_Click;

            pnlBody.Controls.Add(btnFinalizar);

            lblEstado = new Label { Dock = DockStyle.Bottom, Height = 32, Text = "", ForeColor = UITheme.TextSecondary, Font = UITheme.SmallFont, Padding = new Padding(25, 6, 0, 0), BackColor = UITheme.CardBackground };

            this.Controls.Add(pnlBody);
            this.Controls.Add(lblEstado);
            this.Controls.Add(pnlTop);
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
                if (clbInsumos.Items.Count > 0)
                {
                    clbInsumos.SetItemChecked(0, true);
                    if (clbInsumos.Items.Count > 1) clbInsumos.SetItemChecked(1, true);
                }
            }
            catch { }
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
