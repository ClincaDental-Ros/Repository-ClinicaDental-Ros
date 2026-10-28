namespace API.Clients
{
    /// <summary>
    /// Lo implementa una sesión que quiere enterarse cuando la API responde 401.
    /// En la web cada usuario tiene la suya, así que un 401 solo cierra la sesión de quien lo recibió.
    /// </summary>
    public interface INotificaSesionExpirada
    {
        void NotificarSesionExpirada();
    }
}
