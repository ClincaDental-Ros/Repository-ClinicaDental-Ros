namespace Data
{
    /// <summary>
    /// Ejecuta varias operaciones de repositorio dentro de una única transacción de base de datos.
    /// Todos los repositorios comparten el mismo DbContext por request, así que sus SaveChanges quedan dentro de ella.
    /// </summary>
    public interface ITransactionManager
    {
        Task<T> EjecutarEnTransaccionAsync<T>(Func<Task<T>> operacion);
    }
}
