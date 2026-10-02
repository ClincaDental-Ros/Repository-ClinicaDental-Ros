using DTOs;

namespace API.Clients
{
    public class OdontologoApiClient : BaseApiClient
    {
        public OdontologoApiClient() : base()
        {
        }

        public OdontologoApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<OdontologoDTO>> GetAllAsync(int? especialidadId = null)
        {
            var url = especialidadId.HasValue && especialidadId.Value > 0
                ? $"/api/odontologos?especialidadId={especialidadId.Value}"
                : "/api/odontologos";

            var list = await GetAsync<List<OdontologoDTO>>(url);
            return list ?? new List<OdontologoDTO>();
        }

        public async Task<OdontologoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<OdontologoDTO>($"/api/odontologos/{id}");
        }

        public async Task<OdontologoDTO?> CreateAsync(OdontologoDTO dto)
        {
            return await PostAsync<OdontologoDTO, OdontologoDTO>("/api/odontologos", dto);
        }

        public async Task<OdontologoDTO?> UpdateAsync(OdontologoDTO dto)
        {
            return await PutAsync<OdontologoDTO, OdontologoDTO>($"/api/odontologos/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/odontologos/{id}");
        }
    }

    public class EspecialidadApiClient : BaseApiClient
    {
        public EspecialidadApiClient() : base()
        {
        }

        public EspecialidadApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<EspecialidadDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<EspecialidadDTO>>("/api/especialidades");
            return list ?? new List<EspecialidadDTO>();
        }

        public async Task<EspecialidadDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<EspecialidadDTO>($"/api/especialidades/{id}");
        }

        public async Task<EspecialidadDTO?> CreateAsync(EspecialidadDTO dto)
        {
            return await PostAsync<EspecialidadDTO, EspecialidadDTO>("/api/especialidades", dto);
        }

        public async Task<EspecialidadDTO?> UpdateAsync(EspecialidadDTO dto)
        {
            return await PutAsync<EspecialidadDTO, EspecialidadDTO>($"/api/especialidades/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/especialidades/{id}");
        }
    }

    public class InsumoApiClient : BaseApiClient
    {
        public InsumoApiClient() : base()
        {
        }

        public InsumoApiClient(HttpClient httpClient, IAuthService authService)
            : base(httpClient, authService)
        {
        }

        public async Task<List<InsumoDTO>> GetAllAsync()
        {
            var list = await GetAsync<List<InsumoDTO>>("/api/insumos");
            return list ?? new List<InsumoDTO>();
        }

        public async Task<InsumoDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<InsumoDTO>($"/api/insumos/{id}");
        }

        public async Task<InsumoDTO?> CreateAsync(InsumoDTO dto)
        {
            return await PostAsync<InsumoDTO, InsumoDTO>("/api/insumos", dto);
        }

        public async Task<InsumoDTO?> UpdateAsync(InsumoDTO dto)
        {
            return await PutAsync<InsumoDTO, InsumoDTO>($"/api/insumos/{dto.Id}", dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await DeleteAsync($"/api/insumos/{id}");
        }
    }
}