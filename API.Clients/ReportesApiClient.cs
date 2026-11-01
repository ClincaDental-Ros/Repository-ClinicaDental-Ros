using DTOs;

namespace API.Clients
{
    public class ReportesApiClient : BaseApiClient
    {
        public ReportesApiClient() : base()
        {
        }

        public ReportesApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<ReporteTurnosDiaDTO?> GetTurnosDiaAsync(DateTime? fecha = null)
        {
            var qs = fecha.HasValue ? $"?fecha={fecha.Value:yyyy-MM-dd}" : "";
            return await GetAsync<ReporteTurnosDiaDTO>($"/api/reportes/turnos-dia{qs}");
        }

        public async Task<ReporteAusentismoDTO?> GetAusentismoAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await GetAsync<ReporteAusentismoDTO>($"/api/reportes/ausentismo?fechaDesde={fechaDesde:yyyy-MM-dd}&fechaHasta={fechaHasta:yyyy-MM-dd}");
        }

        public async Task<ReporteFacturacionDTO?> GetFacturacionAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await GetAsync<ReporteFacturacionDTO>($"/api/reportes/facturacion?fechaDesde={fechaDesde:yyyy-MM-dd}&fechaHasta={fechaHasta:yyyy-MM-dd}");
        }

        public async Task<HistoriaClinicaDTO?> GetHistoriaClinicaAsync(int pacienteId)
        {
            return await GetAsync<HistoriaClinicaDTO>($"/api/reportes/historia-clinica/{pacienteId}");
        }
    }
}
