using API.Clients;
using DTOs;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public class ReportesControl : UserControl
    {
        private readonly ReportesApiClient _reportesClient = new();
        private readonly PacienteApiClient _pacienteClient = new();

        private TabControl tabReportes = null!;

        // Tab Turnos del Día
        private DateTimePicker dtpTurnosDia = null!;
        private Label lblStatsTurnos = null!;
        private DataGridView gridTurnosDia = null!;

        // Tab Ausentismo
        private DateTimePicker dtpAusDesde = null!;
        private DateTimePicker dtpAusHasta = null!;
        private Label lblAusResumen = null!;

        // Tab Facturación
        private DateTimePicker dtpFacDesde = null!;
        private DateTimePicker dtpFacHasta = null!;
        private Label lblFacResumen = null!;
        private DataGridView gridFacturacion = null!;

        // Tab Historia Clínica
        private ComboBox cbPacienteHC = null!;
        private Label lblHCDetalle = null!;
        private DataGridView gridConsultasHC = null!;

        public ReportesControl()
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
            this.Name = "ReportesControl";
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

            var lblTitle = new Label { Text = "Módulo de Reportes, Auditoría y Estadísticas", Font = UITheme.HeaderFont, ForeColor = UITheme.Primary, Location = new Point(25, 12), AutoSize = true };
            var lblSub = new Label { Text = "Métricas de ausentismo, liquidación a obras sociales, balance financiero e historial médico", Font = UITheme.SmallFont, ForeColor = UITheme.TextSecondary, Location = new Point(27, 40), AutoSize = true };
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblSub);

            tabReportes = new TabControl { Dock = DockStyle.Fill, Padding = new Point(18, 10), Font = UITheme.RegularBold };

            tabReportes.TabPages.Add(CrearTabTurnosDia());
            tabReportes.TabPages.Add(CrearTabAusentismo());
            tabReportes.TabPages.Add(CrearTabFacturacion());
            tabReportes.TabPages.Add(CrearTabHistoriaClinica());

            this.Controls.Add(tabReportes);
            this.Controls.Add(pnlTop);
        }

        private TabPage CrearTabTurnosDia()
        {
            var tab = new TabPage("📅 Citas del Día") { BackColor = UITheme.Background };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };
            var lblF = new Label { Text = "Fecha:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpTurnosDia = new DateTimePicker { Location = new Point(85, 17), Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
            dtpTurnosDia.ValueChanged += DtpTurnosDia_ValueChanged;

            var btnRefrescar = new Button { Text = "🔄 Consultar", Location = new Point(230, 13), Size = new Size(130, 36) };
            UITheme.StylePrimaryButton(btnRefrescar);
            btnRefrescar.Click += BtnRefrescar_Click;

            pnlBar.Controls.Add(lblF);
            pnlBar.Controls.Add(dtpTurnosDia);
            pnlBar.Controls.Add(btnRefrescar);

            lblStatsTurnos = new Label
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = UITheme.PrimaryLight,
                ForeColor = UITheme.PrimaryDark,
                Font = UITheme.RegularBold,
                Padding = new Padding(25, 14, 25, 5),
                Text = "Cargando estadísticas..."
            };

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10) };
            gridTurnosDia = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridTurnosDia);
            gridTurnosDia.AutoGenerateColumns = false;

            gridTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hora", HeaderText = "Horario", Width = 90, DataPropertyName = "HorarioTurno" });
            gridTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente Citado", Width = 230, DataPropertyName = "PacienteNombre" });
            gridTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Odontologo", HeaderText = "Profesional Asignado", Width = 230, DataPropertyName = "OdontologoNombre" });
            gridTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Especialidad", HeaderText = "Especialidad", Width = 200, DataPropertyName = "EspecialidadNombre" });
            gridTurnosDia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 150, DataPropertyName = "EstadoTurno" });
            pnlGrid.Controls.Add(gridTurnosDia);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(lblStatsTurnos);
            tab.Controls.Add(pnlBar);
            return tab;
        }

        private TabPage CrearTabAusentismo()
        {
            var tab = new TabPage("⚠️ Tasa de Ausentismo y Multas") { BackColor = UITheme.Background };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };
            var lblD = new Label { Text = "Desde:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpAusDesde = new DateTimePicker { Location = new Point(85, 17), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-30) };

            var lblH = new Label { Text = "Hasta:", Location = new Point(220, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpAusHasta = new DateTimePicker { Location = new Point(275, 17), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            var btnCalcular = new Button { Text = "📊 Calcular Métricas", Location = new Point(415, 13), Size = new Size(170, 36) };
            UITheme.StylePrimaryButton(btnCalcular);
            btnCalcular.Click += BtnCalcularAus_Click;

            pnlBar.Controls.Add(lblD);
            pnlBar.Controls.Add(dtpAusDesde);
            pnlBar.Controls.Add(lblH);
            pnlBar.Controls.Add(dtpAusHasta);
            pnlBar.Controls.Add(btnCalcular);

            lblAusResumen = new Label
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(35),
                Font = UITheme.SubheaderFont,
                ForeColor = UITheme.TextPrimary,
                Text = "Cargando métricas de ausentismo..."
            };

            tab.Controls.Add(lblAusResumen);
            tab.Controls.Add(pnlBar);
            return tab;
        }

        private TabPage CrearTabFacturacion()
        {
            var tab = new TabPage("💰 Facturación y Obras Sociales") { BackColor = UITheme.Background };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };
            var lblD = new Label { Text = "Desde:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpFacDesde = new DateTimePicker { Location = new Point(85, 17), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-30) };

            var lblH = new Label { Text = "Hasta:", Location = new Point(220, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            dtpFacHasta = new DateTimePicker { Location = new Point(275, 17), Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            var btnCalcular = new Button { Text = "📈 Liquidar Período", Location = new Point(415, 13), Size = new Size(170, 36) };
            UITheme.StylePrimaryButton(btnCalcular);
            btnCalcular.Click += BtnCalcularFac_Click;

            pnlBar.Controls.Add(lblD);
            pnlBar.Controls.Add(dtpFacDesde);
            pnlBar.Controls.Add(lblH);
            pnlBar.Controls.Add(dtpFacHasta);
            pnlBar.Controls.Add(btnCalcular);

            lblFacResumen = new Label
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = UITheme.PrimaryLight,
                ForeColor = UITheme.PrimaryDark,
                Font = UITheme.RegularBold,
                Padding = new Padding(25, 18, 25, 5),
                Text = "Cargando facturación..."
            };

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10) };
            gridFacturacion = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridFacturacion);
            gridFacturacion.AutoGenerateColumns = false;

            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "N° Factura", Width = 90, DataPropertyName = "Id" });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", Width = 120 });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "Paciente", HeaderText = "Paciente", Width = 220, DataPropertyName = "PacienteNombre" });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "OS", HeaderText = "Obra Social", Width = 160, DataPropertyName = "ObraSocialNombre" });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total Prestación", Width = 140, DataPropertyName = "Total" });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "DescOS", HeaderText = "Liq. Obra Social", Width = 140, DataPropertyName = "DescuentoObraSocial" });
            gridFacturacion.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cobrado", HeaderText = "Cobrado Paciente", Width = 140, DataPropertyName = "MontoAPagarPaciente" });
            pnlGrid.Controls.Add(gridFacturacion);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(lblFacResumen);
            tab.Controls.Add(pnlBar);
            return tab;
        }

        private TabPage CrearTabHistoriaClinica()
        {
            var tab = new TabPage("📋 Historia Clínica") { BackColor = UITheme.Background };

            var pnlBar = new Panel { Dock = DockStyle.Top, Height = 65, Padding = new Padding(25, 12, 25, 12), BackColor = UITheme.CardBackground };
            var lblP = new Label { Text = "Paciente:", Location = new Point(25, 20), AutoSize = true, Font = UITheme.RegularBold, ForeColor = UITheme.TextPrimary };
            cbPacienteHC = new ComboBox { Location = new Point(95, 17), Width = 370, DropDownStyle = ComboBoxStyle.DropDownList };
            cbPacienteHC.SelectedIndexChanged += CbPacienteHC_SelectedIndexChanged;

            var btnBuscar = new Button { Text = "🔍 Ver Ficha", Location = new Point(480, 13), Size = new Size(130, 36) };
            UITheme.StylePrimaryButton(btnBuscar);
            btnBuscar.Click += BtnBuscarHC_Click;

            pnlBar.Controls.Add(lblP);
            pnlBar.Controls.Add(cbPacienteHC);
            pnlBar.Controls.Add(btnBuscar);

            lblHCDetalle = new Label
            {
                Dock = DockStyle.Top,
                Height = 85,
                BackColor = Color.White,
                ForeColor = UITheme.TextPrimary,
                Font = UITheme.RegularFont,
                Padding = new Padding(25, 14, 25, 5),
                Text = "Seleccione un paciente para ver antecedentes médicos, odontograma y consultas previas."
            };

            var pnlGrid = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 15, 25, 10) };
            gridConsultasHC = new DataGridView { Dock = DockStyle.Fill };
            UITheme.StyleDataGridView(gridConsultasHC);
            gridConsultasHC.AutoGenerateColumns = false;

            gridConsultasHC.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha Atención", Width = 120 });
            gridConsultasHC.Columns.Add(new DataGridViewTextBoxColumn { Name = "Doctor", HeaderText = "Profesional Interviniente", Width = 200, DataPropertyName = "OdontologoNombre" });
            gridConsultasHC.Columns.Add(new DataGridViewTextBoxColumn { Name = "Diagnostico", HeaderText = "Diagnóstico (CIE-10)", Width = 240, DataPropertyName = "Diagnostico" });
            gridConsultasHC.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tratamiento", HeaderText = "Tratamiento Realizado", Width = 240, DataPropertyName = "Tratamiento" });
            gridConsultasHC.Columns.Add(new DataGridViewTextBoxColumn { Name = "Observaciones", HeaderText = "Evolución y Notas Clínicas", DataPropertyName = "Observaciones" });
            pnlGrid.Controls.Add(gridConsultasHC);

            tab.Controls.Add(pnlGrid);
            tab.Controls.Add(lblHCDetalle);
            tab.Controls.Add(pnlBar);
            return tab;
        }

        private async void OnControlLoad(object? sender, EventArgs e)
        {
            await CargarReporteTurnos();
            await CargarReporteAusentismo();
            await CargarReporteFacturacion();
            await CargarPacientesHC();
        }

        private async void DtpTurnosDia_ValueChanged(object? sender, EventArgs e)
        {
            await CargarReporteTurnos();
        }

        private async void BtnRefrescar_Click(object? sender, EventArgs e)
        {
            await CargarReporteTurnos();
        }

        private async void BtnCalcularAus_Click(object? sender, EventArgs e)
        {
            await CargarReporteAusentismo();
        }

        private async void BtnCalcularFac_Click(object? sender, EventArgs e)
        {
            await CargarReporteFacturacion();
        }

        private async void CbPacienteHC_SelectedIndexChanged(object? sender, EventArgs e)
        {
            await CargarHistoriaClinicaPaciente();
        }

        private async void BtnBuscarHC_Click(object? sender, EventArgs e)
        {
            await CargarHistoriaClinicaPaciente();
        }

        private async Task CargarReporteTurnos()
        {
            try
            {
                var rep = await _reportesClient.GetTurnosDiaAsync(dtpTurnosDia.Value.Date);
                if (rep != null)
                {
                    lblStatsTurnos.Text = $"📊 Total: {rep.TotalTurnos} | Pendientes: {rep.TurnosPendientes} | En Sala: {rep.TurnosPresentes} | Atendidos: {rep.TurnosAtendidos} | Ausencias: {rep.TurnosAusentes} | Cancelados: {rep.TurnosCancelados}";
                    gridTurnosDia.DataSource = rep.DetalleTurnos;
                }
            }
            catch { }
        }

        private async Task CargarReporteAusentismo()
        {
            try
            {
                var rep = await _reportesClient.GetAusentismoAsync(dtpAusDesde.Value.Date, dtpAusHasta.Value.Date);
                if (rep != null)
                {
                    lblAusResumen.Text = $@"📊 INFORME EJECUTIVO DE AUSENTISMO Y SANCIONES CLÍNICAS

Período Evaluado: {rep.FechaDesde:dd/MM/yyyy} al {rep.FechaHasta:dd/MM/yyyy}

• Total de Turnos Programados: {rep.TotalTurnosProgramados}
• Inasistencias Registradas (No Asistió): {rep.TotalAusencias}
• Tasa de Ausentismo Global: {rep.PorcentajeAusentismo}%

• Total de Multas Emitidas: {rep.TotalMultasGeneradas:C2}
• Total de Multas Cobradas / Regularizadas: {rep.TotalMultasCobradas:C2}
• Saldo Pendiente de Cobro por Multas: {(rep.TotalMultasGeneradas - rep.TotalMultasCobradas):C2}";
                }
            }
            catch { }
        }

        private async Task CargarReporteFacturacion()
        {
            try
            {
                var rep = await _reportesClient.GetFacturacionAsync(dtpFacDesde.Value.Date, dtpFacHasta.Value.Date);
                if (rep != null)
                {
                    lblFacResumen.Text = $"📈 Total Facturado: {rep.TotalFacturado:C2} | Cobrado en Caja: {rep.TotalCobradoPacientes:C2} | Liquidación O.S.: {rep.TotalLiquidadoObrasSociales:C2} | Consultas: {rep.CantidadConsultasAtendidas}";
                    gridFacturacion.DataSource = rep.Facturas;
                }
            }
            catch { }
        }

        private async Task CargarPacientesHC()
        {
            try
            {
                var pacientes = await _pacienteClient.GetAllAsync();
                cbPacienteHC.DataSource = pacientes;
                cbPacienteHC.DisplayMember = "NombreCompleto";
                cbPacienteHC.ValueMember = "Id";
                if (pacientes.Count > 0)
                {
                    await CargarHistoriaClinicaPaciente();
                }
            }
            catch { }
        }

        private async Task CargarHistoriaClinicaPaciente()
        {
            if (cbPacienteHC.SelectedValue is not int pacienteId || pacienteId <= 0) return;

            try
            {
                var hc = await _reportesClient.GetHistoriaClinicaAsync(pacienteId);
                if (hc != null)
                {
                    lblHCDetalle.Text = $"📋 Historia Clínica N° {hc.NumeroHistoriaClinica:D5} - Paciente: {hc.PacienteNombre} (Alta: {hc.FechaAlta:dd/MM/yyyy})\n" +
                                        $"• Antecedentes Médicos: {hc.AntecedentesMedicos} | Alergias: {hc.Alergias}\n" +
                                        $"• Observaciones Generales: {hc.ObservacionesGenerales}";

                    gridConsultasHC.DataSource = hc.ConsultasPrevias;
                }
            }
            catch { }
        }
    }
}
