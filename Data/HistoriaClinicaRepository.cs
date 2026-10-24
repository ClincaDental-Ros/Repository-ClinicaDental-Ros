using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HistoriaClinicaRepository : IHistoriaClinicaRepository
    {
        private readonly TurnoMolarDbContext _context;

        public HistoriaClinicaRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<HistoriaClinica?> GetByPacienteIdAsync(int pacienteId)
        {
            return await _context.HistoriasClinicas
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(h => h.PacienteId == pacienteId);
        }

        public async Task<HistoriaClinica> AddAsync(HistoriaClinica historiaClinica)
        {
            _context.HistoriasClinicas.Add(historiaClinica);
            await _context.SaveChangesAsync();
            return historiaClinica;
        }

        public async Task<bool> UpdateAsync(HistoriaClinica historiaClinica)
        {
            var existing = await _context.HistoriasClinicas.FindAsync(historiaClinica.Id);
            if (existing == null)
                return false;

            existing.SetAntecedentesMedicos(historiaClinica.AntecedentesMedicos);
            existing.SetAlergias(historiaClinica.Alergias);
            existing.SetObservacionesGenerales(historiaClinica.ObservacionesGenerales);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
