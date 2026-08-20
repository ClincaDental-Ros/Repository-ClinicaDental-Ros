using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly TurnoMolarDbContext _context;

        public PacienteRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> GetAsync(int id)
        {
            return await _context.Pacientes
                .Include(p => p.ObraSocial)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes
                .Include(p => p.ObraSocial)
                .OrderBy(p => p.Apellido)
                .ThenBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Paciente>> GetByCriteriaAsync(PacienteCriteria criteria)
        {
            var query = _context.Pacientes
                .Include(p => p.ObraSocial)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(criteria.Texto))
            {
                var text = criteria.Texto.Trim().ToLower();
                query = query.Where(p =>
                    p.Nombre.ToLower().Contains(text) ||
                    p.Apellido.ToLower().Contains(text) ||
                    p.Dni.ToString().Contains(text) ||
                    p.Mail.ToLower().Contains(text));
            }

            if (criteria.SoloHabilitados.HasValue && criteria.SoloHabilitados.Value)
            {
                query = query.Where(p => p.EstadoHabilitado);
            }

            return await query.OrderBy(p => p.Apellido).ThenBy(p => p.Nombre).ToListAsync();
        }

        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> UpdateAsync(Paciente paciente)
        {
            var existing = await _context.Pacientes.FindAsync(paciente.Id);
            if (existing == null)
                return false;

            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.Dni = paciente.Dni;
            existing.Telefono = paciente.Telefono;
            existing.Mail = paciente.Mail;
            existing.Domicilio = paciente.Domicilio;
            existing.EstadoHabilitado = paciente.EstadoHabilitado;
            existing.ObraSocialId = paciente.ObraSocialId;
            existing.NumeroAfiliado = paciente.NumeroAfiliado;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            return await _context.Pacientes.AnyAsync(p =>
                p.Mail.ToLower() == email.ToLower() &&
                (!excludeId.HasValue || p.Id != excludeId.Value));
        }

        public async Task<bool> DniExistsAsync(int dni, int? excludeId = null)
        {
            return await _context.Pacientes.AnyAsync(p =>
                p.Dni == dni &&
                (!excludeId.HasValue || p.Id != excludeId.Value));
        }
    }
}