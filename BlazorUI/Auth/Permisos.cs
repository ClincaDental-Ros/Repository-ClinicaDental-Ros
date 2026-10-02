namespace BlazorUI.Auth;

public static class Permisos
{
    // Nombres de rol 
    public const string Admin = "Admin";
    public const string Odontologo = "Odontologo";
    public const string Recepcionista = "Recepcionista";
    public const string Paciente = "Paciente";

    // Roles permitidos por página 
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

    public static bool Puede(string? rol, string permiso)
    {
        if (string.IsNullOrWhiteSpace(rol)) return false;
        return permiso.Split(',').Contains(rol, StringComparer.OrdinalIgnoreCase);
    }
}

