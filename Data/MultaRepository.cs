using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MultaRepository : IMultaRepository
    {
        private readonly TurnoMolarDbContext _context;

        public MultaRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<Multa?> GetAsync(int id)
        {
            return await _context.Multas
                .Include(m => m.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Multa>> GetAllAsync()
        {
            return await _context.Multas
                .Include(m => m.Paciente)
                .OrderByDescending(m => m.FechaEmision)
                .ToListAsync();
        }

        public async Task<IEnumerable<Multa>> GetByPacienteIdAsync(int pacienteId)
        {
            return await _context.Multas
                .Include(m => m.Paciente)
                .Where(m => m.PacienteId == pacienteId)
                .OrderByDescending(m => m.FechaEmision)
                .ToListAsync();
        }

        public async Task<IEnumerable<Multa>> GetImpagasByPacienteIdAsync(int pacienteId)
        {
            return await _context.Multas
                .Where(m => m.PacienteId == pacienteId && !m.EstadoPago)
                .ToListAsync();
        }

        public async Task<IEnumerable<Multa>> GetByRangoFechasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            // El filtro por período se resuelve en SQL, no trayendo todas las multas a memoria.
            var desde = fechaDesde.Date;
            var hastaExclusivo = fechaHasta.Date.AddDays(1);
            return await _context.Multas
                .Where(m => m.FechaEmision >= desde && m.FechaEmision < hastaExclusivo)
                .OrderByDescending(m => m.FechaEmision)
                .ToListAsync();
        }

        public async Task<Multa> AddAsync(Multa multa)
        {
            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();
            return multa;
        }

        public async Task<bool> PagarMultaAsync(int id)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null)
                return false;

            multa.MarcarComoPagada();

            // Si el paciente no tiene más multas impagas, re-habilitarlo
            var otrasMultas = await _context.Multas.AnyAsync(m => m.PacienteId == multa.PacienteId && !m.EstadoPago && m.Id != id);
            if (!otrasMultas)
            {
                var paciente = await _context.Pacientes.FindAsync(multa.PacienteId);
                if (paciente != null)
                {
                    paciente.SetEstadoHabilitado(true);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
