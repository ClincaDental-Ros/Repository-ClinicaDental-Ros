using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ObraSocialRepository : IObraSocialRepository
    {
        private readonly TurnoMolarDbContext _context;

        public ObraSocialRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<ObraSocial?> GetAsync(int id)
        {
            return await _context.ObrasSociales.FindAsync(id);
        }

        public async Task<IEnumerable<ObraSocial>> GetAllAsync()
        {
            return await _context.ObrasSociales.OrderBy(o => o.Nombre).ToListAsync();
        }

        public async Task<ObraSocial> AddAsync(ObraSocial obraSocial)
        {
            _context.ObrasSociales.Add(obraSocial);
            await _context.SaveChangesAsync();
            return obraSocial;
        }

        public async Task<bool> UpdateAsync(ObraSocial obraSocial)
        {
            var existing = await _context.ObrasSociales.FindAsync(obraSocial.Id);
            if (existing == null)
                return false;

            existing.SetNombre(obraSocial.Nombre);
            existing.SetPlan(obraSocial.Plan);
            existing.SetPorcentajeCobertura(obraSocial.PorcentajeCobertura);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
