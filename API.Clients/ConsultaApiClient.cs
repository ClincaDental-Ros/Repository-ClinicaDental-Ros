using DTOs;

namespace API.Clients
{
    public class ConsultaApiClient : BaseApiClient
    {
        public async Task<List<ConsultaDTO>> GetAllAsync(int? pacienteId = null)
        {
            var url = pacienteId.HasValue ? $"/api/consultas?pacienteId={pacienteId.Value}" : "/api/consultas";
            var list = await GetAsync<List<ConsultaDTO>>(url);
            return list ?? new List<ConsultaDTO>();
        }

        public async Task<ConsultaDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<ConsultaDTO>($"/api/consultas/{id}");
        }

        public async Task<ConsultaDTO?> GetByTurnoIdAsync(int turnoId)
        {
            return await GetAsync<ConsultaDTO>($"/api/consultas/turno/{turnoId}");
        }

        public async Task<ConsultaDTO?> RegistrarAsync(ConsultaDTO dto)
        {
            return await PostAsync<ConsultaDTO, ConsultaDTO>("/api/consultas/registrar", dto);
        }

        public async Task<bool> ValorarAsync(int id, int estrellas, string comentario)
        {
            return await PostAsync($"/api/consultas/{id}/valorar", new { Estrellas = estrellas, Comentario = comentario });
        }
    }

    public class FacturaApiClient : BaseApiClient
    {
        public async Task<List<FacturaDTO>> GetAllAsync(int? pacienteId = null)
        {
            var url = pacienteId.HasValue ? $"/api/facturas?pacienteId={pacienteId.Value}" : "/api/facturas";
            var list = await GetAsync<List<FacturaDTO>>(url);
            return list ?? new List<FacturaDTO>();
        }

        public async Task<FacturaDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<FacturaDTO>($"/api/facturas/{id}");
        }

        public async Task<FacturaDTO?> GetByTurnoIdAsync(int turnoId)
        {
            return await GetAsync<FacturaDTO>($"/api/facturas/turno/{turnoId}");
        }

        public async Task<FacturaDTO?> CrearAsync(FacturaDTO dto)
        {
            return await PostAsync<FacturaDTO, FacturaDTO>("/api/facturas/crear", dto);
        }

        public async Task<bool> PagarAsync(int id, string metodoPago)
        {
            return await PostAsync($"/api/facturas/{id}/pagar", new { MetodoPago = metodoPago });
        }
    }

    public class MultaApiClient : BaseApiClient
    {
        public async Task<List<MultaDTO>> GetAllAsync(int? pacienteId = null, bool? soloImpagas = null)
        {
            var query = new List<string>();
            if (pacienteId.HasValue) query.Add($"pacienteId={pacienteId.Value}");
            if (soloImpagas.HasValue) query.Add($"soloImpagas={soloImpagas.Value}");
            var qs = query.Count > 0 ? "?" + string.Join("&", query) : "";

            var list = await GetAsync<List<MultaDTO>>($"/api/multas{qs}");
            return list ?? new List<MultaDTO>();
        }

        public async Task<MultaDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<MultaDTO>($"/api/multas/{id}");
        }

        public async Task<MultaDTO?> CrearAsync(MultaDTO dto)
        {
            return await PostAsync<MultaDTO, MultaDTO>("/api/multas", dto);
        }

        public async Task<bool> PagarAsync(int id)
        {
            return await PostAsync($"/api/multas/{id}/pagar", new { });
        }
    }

    public class ReportesApiClient : BaseApiClient
    {
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
