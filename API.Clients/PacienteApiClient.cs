using DTOs;

namespace API.Clients
{
    public class PacienteApiClient : BaseApiClient
    {
        public async Task<List<PacienteDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<PacienteDTO>>("/api/pacientes");
            return list ?? new List<PacienteDTO>();
        }

        public async Task<List<PacienteDTO>> GetByCriteriaAsync(string? texto, bool? soloHabilitados = null)
        {
            var query = new List<string>();
            if (!string.IsNullOrWhiteSpace(texto))
                query.Add($"texto={Uri.EscapeDataString(texto)}");
            if (soloHabilitados.HasValue)
                query.Add($"soloHabilitados={soloHabilitados.Value}");

            var queryString = query.Count > 0 ? "?" + string.Join("&", query) : "";
            var list = await GetAsync<List<PacienteDTO>>($"/api/pacientes{queryString}");
            return list ?? new List<PacienteDTO>();
        }

        public async Task<PacienteDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<PacienteDTO>($"/api/pacientes/{id}");
        }

        public async Task<PacienteDTO?> CreateAsync(PacienteDTO dto)
        {
            return await PostAsync<PacienteDTO, PacienteDTO>("/api/pacientes", dto);
        }

        public async Task<PacienteDTO?> UpdateAsync(PacienteDTO dto)
        {
            return await PutAsync<PacienteDTO, PacienteDTO>($"/api/pacientes/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/pacientes/{id}");
        }
    }
}
