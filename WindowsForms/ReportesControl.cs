using API.Clients;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class ReportesControl : UserControl
    {
        private readonly ReportesApiClient _reportesClient = new();
        private readonly PacienteApiClient _pacienteClient = new();

        public ReportesControl()
        {
            InitializeComponent();
            gridTurnosDia.AutoGenerateColumns = false;
            gridFacturacion.AutoGenerateColumns = false;
            gridConsultasHC.AutoGenerateColumns = false;
            dtpTurnosDia.Value = DateTime.Today;
            dtpAusDesde.Value = DateTime.Today.AddDays(-30);
            dtpAusHasta.Value = DateTime.Today;
            dtpFacDesde.Value = DateTime.Today.AddDays(-30);
            dtpFacHasta.Value = DateTime.Today;

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += OnControlLoad;
            }
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
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
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
                    graficoTurnos.SetDatos(new[]
                    {
                        ("Pendientes", (decimal)rep.TurnosPendientes, UITheme.Warning),
                        ("En sala", (decimal)rep.TurnosPresentes, UITheme.Accent),
                        ("Atendidos", (decimal)rep.TurnosAtendidos, UITheme.Success),
                        ("Ausentes", (decimal)rep.TurnosAusentes, UITheme.Danger),
                        ("Cancelados", (decimal)rep.TurnosCancelados, UITheme.Secondary)
                    });
                }
            }
            catch (Exception ex)
            {
                lblStatsTurnos.Text = $"No se pudo cargar el reporte de citas: {ex.Message}";
            }
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
            catch (Exception ex)
            {
                lblAusResumen.Text = $"No se pudo calcular el ausentismo: {ex.Message}";
            }
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
                    graficoFacturacion.SetDatos(new[]
                    {
                        ("Facturado", rep.TotalFacturado, UITheme.Primary),
                        ("Cobrado caja", rep.TotalCobradoPacientes, UITheme.Success),
                        ("Liq. O.S.", rep.TotalLiquidadoObrasSociales, UITheme.Accent)
                    }, "C0");
                }
            }
            catch (Exception ex)
            {
                lblFacResumen.Text = $"No se pudo cargar la facturación: {ex.Message}";
            }
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
            catch (Exception ex)
            {
                lblHCDetalle.Text = $"No se pudo cargar la lista de pacientes: {ex.Message}";
            }
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
            catch (Exception ex)
            {
                lblHCDetalle.Text = $"No se pudo cargar la historia clínica: {ex.Message}";
            }
        }
    }
}
