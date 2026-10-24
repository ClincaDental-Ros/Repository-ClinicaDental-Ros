using DTOs;

namespace API.Clients
{
    public class ConsultaApiClient : BaseApiClient
    {
        public ConsultaApiClient() : base()
        {
        }

        public ConsultaApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

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
}
