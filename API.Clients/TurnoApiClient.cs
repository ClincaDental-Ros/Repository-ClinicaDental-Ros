using DTOs;

namespace API.Clients
{
    public class TurnoApiClient : BaseApiClient
    {
        public async Task<List<TurnoOdontologicoDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<TurnoOdontologicoDTO>>("/api/turnos");
            return list ?? new List<TurnoOdontologicoDTO>();
        }

        public async Task<List<TurnoOdontologicoDTO>> GetHoyAsync(DateTime? fecha = null)
        {
            var url = fecha.HasValue ? $"/api/turnos/hoy?fecha={fecha.Value:yyyy-MM-dd}" : "/api/turnos/hoy";
            var list = await GetAsync<List<TurnoOdontologicoDTO>>(url);
            return list ?? new List<TurnoOdontologicoDTO>();
        }

        public async Task<List<TurnoOdontologicoDTO>> GetByCriteriaAsync(TurnoCriteriaDTO criteria)
        {
            var query = new List<string>();
            if (criteria.Fecha.HasValue)
                query.Add($"fecha={criteria.Fecha.Value:yyyy-MM-dd}");
            if (criteria.FechaDesde.HasValue)
                query.Add($"fechaDesde={criteria.FechaDesde.Value:yyyy-MM-dd}");
            if (criteria.FechaHasta.HasValue)
                query.Add($"fechaHasta={criteria.FechaHasta.Value:yyyy-MM-dd}");
            if (criteria.OdontologoId.HasValue && criteria.OdontologoId > 0)
                query.Add($"odontologoId={criteria.OdontologoId.Value}");
            if (criteria.PacienteId.HasValue && criteria.PacienteId > 0)
                query.Add($"pacienteId={criteria.PacienteId.Value}");
            if (criteria.EspecialidadId.HasValue && criteria.EspecialidadId > 0)
                query.Add($"especialidadId={criteria.EspecialidadId.Value}");
            if (!string.IsNullOrWhiteSpace(criteria.EstadoTurno))
                query.Add($"estadoTurno={Uri.EscapeDataString(criteria.EstadoTurno)}");

            var queryString = query.Count > 0 ? "?" + string.Join("&", query) : "";
            var list = await GetAsync<List<TurnoOdontologicoDTO>>($"/api/turnos{queryString}");
            return list ?? new List<TurnoOdontologicoDTO>();
        }

        public async Task<TurnoOdontologicoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<TurnoOdontologicoDTO>($"/api/turnos/{id}");
        }

        public async Task<TurnoOdontologicoDTO?> ReservarAsync(TurnoOdontologicoDTO dto)
        {
            return await PostAsync<TurnoOdontologicoDTO, TurnoOdontologicoDTO>("/api/turnos/reservar", dto);
        }

        public async Task<TurnoOdontologicoDTO?> UpdateAsync(TurnoOdontologicoDTO dto)
        {
            return await PutAsync<TurnoOdontologicoDTO, TurnoOdontologicoDTO>($"/api/turnos/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/turnos/{id}");
        }

        public async Task<bool> ConfirmarPresenciaAsync(int id)
        {
            return await PostAsync($"/api/turnos/{id}/confirmar-presencia", new { });
        }

        public async Task<bool> RegistrarAusenciaAsync(int id, string motivo, decimal montoMulta = 3500m)
        {
            return await PostAsync($"/api/turnos/{id}/registrar-ausencia", new { Motivo = motivo, MontoMulta = montoMulta });
        }

        public async Task<bool> CancelarAsync(int id, string motivo)
        {
            return await PostAsync($"/api/turnos/{id}/cancelar", new { Motivo = motivo });
        }

        public async Task<bool> AtenderAsync(int id)
        {
            return await PostAsync($"/api/turnos/{id}/atender", new { });
        }
    }
}
