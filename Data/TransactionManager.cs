using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TransactionManager : ITransactionManager
    {
        private readonly TurnoMolarDbContext _context;

        public TransactionManager(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<T> EjecutarEnTransaccionAsync<T>(Func<Task<T>> operacion)
        {
            // La estrategia de reintentos de SQL Server exige envolver la transacción en CreateExecutionStrategy
            var strategy = _context.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var resultado = await operacion();
                    await transaction.CommitAsync();
                    return resultado;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    _context.ChangeTracker.Clear();
                    throw;
                }
            });
        }
    }
}
