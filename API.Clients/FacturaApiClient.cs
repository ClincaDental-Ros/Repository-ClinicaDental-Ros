using DTOs;

namespace API.Clients
{
    public class FacturaApiClient : BaseApiClient
    {
        public FacturaApiClient() : base()
        {
        }

        public FacturaApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

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

        public async Task<FacturaDTO?> ActualizarAsync(FacturaDTO dto)
        {
            return await PutAsync<FacturaDTO, FacturaDTO>($"/api/facturas/{dto.Id}", dto);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await DeleteAsync($"/api/facturas/{id}");
        }

        public async Task<bool> PagarAsync(int id, string metodoPago)
        {
            return await PostAsync($"/api/facturas/{id}/pagar", new { MetodoPago = metodoPago });
        }
    }
}
