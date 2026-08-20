using Domain.Model;

namespace Data
{
    public interface ITurnoRepository
    {
        Task<TurnoOdontologico?> GetAsync(int id);
        Task<IEnumerable<TurnoOdontologico>> GetAllAsync();
        Task<IEnumerable<TurnoOdontologico>> GetByCriteriaAsync(TurnoCriteria criteria);
        Task<IEnumerable<TurnoOdontologico>> GetByFechaAsync(DateTime fecha);
        Task<TurnoOdontologico> AddAsync(TurnoOdontologico turno);
        Task<bool> UpdateAsync(TurnoOdontologico turno);
        Task<bool> DeleteAsync(int id);
        Task<bool> TurnoExistsAsync(DateTime fecha, TimeOnly horarioTurno, int? odontologoId = null, int? excludeId = null);
        Task<bool> PacienteTieneTurnoEnFechaAsync(int pacienteId, DateTime fecha, int? excludeId = null);
    }
}
