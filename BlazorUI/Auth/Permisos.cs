namespace BlazorUI.Auth;

/// <summary>
/// Única fuente de verdad de "qué rol puede entrar a qué".
/// Las páginas usan estas constantes en [Authorize(Roles = ...)] y el NavMenu
/// las usa para decidir qué links mostrar, así nunca se desincronizan.
/// </summary>
public static class Permisos
{
    // Nombres de rol 
    public const string Admin = "Admin";
    public const string Odontologo = "Odontologo";
    public const string Recepcionista = "Recepcionista";
    public const string Paciente = "Paciente";

    // Roles permitidos por página (formato "Rol1,Rol2" para [Authorize(Roles = ...)])
    public const string Pacientes = Admin + "," + Recepcionista + "," + Odontologo;
    public const string Odontologos = Admin + "," + Recepcionista + "," + Odontologo;
    public const string Especialidades = Admin + "," + Recepcionista;
    public const string Insumos = Admin + "," + Recepcionista + "," + Odontologo;
    public const string Turnos = Admin + "," + Recepcionista + "," + Odontologo;
    public const string Admision = Admin + "," + Recepcionista + "," + Odontologo;
    public const string AtencionClinica = Admin + "," + Odontologo;
    public const string Cobro = Admin + "," + Recepcionista;
    public const string Reportes = Admin + "," + Recepcionista;
    public const string PortalPaciente = Paciente;

    /// <summary>¿Este rol está incluido en la lista de roles de un permiso?</summary>
    public static bool Puede(string? rol, string permiso)
    {
        if (string.IsNullOrWhiteSpace(rol)) return false;
        return permiso.Split(',').Contains(rol, StringComparer.OrdinalIgnoreCase);
    }
}

