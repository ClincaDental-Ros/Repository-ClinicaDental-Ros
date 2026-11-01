using Data;
using DTOs;

namespace Application.Services
{
    public interface IObraSocialService
    {
        Task<IEnumerable<ObraSocialDTO>> GetAllAsync();
    }

    /// <summary>Catálogo de obras sociales: las pantallas de pacientes lo usan para armar su lista.</summary>
    public class ObraSocialService : IObraSocialService
    {
        private readonly IObraSocialRepository _obraSocialRepository;

        public ObraSocialService(IObraSocialRepository obraSocialRepository)
        {
            _obraSocialRepository = obraSocialRepository;
        }

        public async Task<IEnumerable<ObraSocialDTO>> GetAllAsync()
        {
            var lista = await _obraSocialRepository.GetAllAsync();
            return lista.Select(o => new ObraSocialDTO
            {
                Id = o.Id,
                Nombre = o.Nombre,
                Plan = o.Plan,
                PorcentajeCobertura = o.PorcentajeCobertura
            }).ToList();
        }
    }
}
