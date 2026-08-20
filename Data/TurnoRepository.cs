using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly TurnoMolarDbContext _context;

        public TurnoRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<TurnoOdontologico?> GetAsync(int id)
        {
            return await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .Include(t => t.Especialidad)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TurnoOdontologico>> GetAllAsync()
        {
            return await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .Include(t => t.Especialidad)
                .OrderBy(t => t.Fecha)
                .ThenBy(t => t.HorarioTurno)
                .ToListAsync();
        }

        public async Task<IEnumerable<TurnoOdontologico>> GetByCriteriaAsync(TurnoCriteria criteria)
        {
            var query = _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .Include(t => t.Especialidad)
                .AsQueryable();

            if (criteria.Fecha.HasValue)
            {
                var d = criteria.Fecha.Value.Date;
                query = query.Where(t => t.Fecha.Date == d);
            }

            if (criteria.FechaDesde.HasValue)
            {
                var d = criteria.FechaDesde.Value.Date;
                query = query.Where(t => t.Fecha.Date >= d);
            }

            if (criteria.FechaHasta.HasValue)
            {
                var d = criteria.FechaHasta.Value.Date;
                query = query.Where(t => t.Fecha.Date <= d);
            }

            if (criteria.OdontologoId.HasValue && criteria.OdontologoId.Value > 0)
            {
                query = query.Where(t => t.OdontologoId == criteria.OdontologoId.Value);
            }

            if (criteria.PacienteId.HasValue && criteria.PacienteId.Value > 0)
            {
                query = query.Where(t => t.PacienteId == criteria.PacienteId.Value);
            }

            if (criteria.EspecialidadId.HasValue && criteria.EspecialidadId.Value > 0)
            {
                query = query.Where(t => t.EspecialidadId == criteria.EspecialidadId.Value);
            }

            if (!string.IsNullOrWhiteSpace(criteria.EstadoTurno))
            {
                if (Enum.TryParse<TurnoOdontologico.EstadoTurnoEnum>(criteria.EstadoTurno, true, out var estadoEnum))
                {
                    query = query.Where(t => t.EstadoTurno == estadoEnum);
                }
            }

            return await query.OrderBy(t => t.Fecha).ThenBy(t => t.HorarioTurno).ToListAsync();
        }

        public async Task<IEnumerable<TurnoOdontologico>> GetByFechaAsync(DateTime fecha)
        {
            var d = fecha.Date;
            return await _context.Turnos
                .Include(t => t.Paciente)
                .Include(t => t.Odontologo)
                .Include(t => t.Especialidad)
                .Where(t => t.Fecha.Date == d)
                .OrderBy(t => t.HorarioTurno)
                .ToListAsync();
        }

        public async Task<TurnoOdontologico> AddAsync(TurnoOdontologico turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task<bool> UpdateAsync(TurnoOdontologico turno)
        {
            var existing = await _context.Turnos.FindAsync(turno.Id);
            if (existing == null)
                return false;

            existing.Fecha = turno.Fecha;
            existing.HorarioTurno = turno.HorarioTurno;
            existing.EstadoTurno = turno.EstadoTurno;
            existing.MotivoCancelacion = turno.MotivoCancelacion;
            existing.PacienteId = turno.PacienteId;
            existing.OdontologoId = turno.OdontologoId;
            existing.EspecialidadId = turno.EspecialidadId;
            existing.MontoEstimado = turno.MontoEstimado;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
                return false;

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TurnoExistsAsync(DateTime fecha, TimeOnly horarioTurno, int? odontologoId = null, int? excludeId = null)
        {
            var d = fecha.Date;
            return await _context.Turnos.AnyAsync(t =>
                t.Fecha.Date == d &&
                t.HorarioTurno == horarioTurno &&
                t.EstadoTurno != TurnoOdontologico.EstadoTurnoEnum.Cancelado &&
                (!odontologoId.HasValue || t.OdontologoId == odontologoId.Value) &&
                (!excludeId.HasValue || t.Id != excludeId.Value));
        }

        public async Task<bool> PacienteTieneTurnoEnFechaAsync(int pacienteId, DateTime fecha, int? excludeId = null)
        {
            var d = fecha.Date;
            return await _context.Turnos.AnyAsync(t =>
                t.PacienteId == pacienteId &&
                t.Fecha.Date == d &&
                t.EstadoTurno != TurnoOdontologico.EstadoTurnoEnum.Cancelado &&
                (!excludeId.HasValue || t.Id != excludeId.Value));
        }
    }
}
