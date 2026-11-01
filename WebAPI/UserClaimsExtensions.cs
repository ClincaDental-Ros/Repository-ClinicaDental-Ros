using System.Security.Claims;

namespace WebAPI
{
    public static class UserClaimsExtensions
    {
        public static bool EsPersonal(this ClaimsPrincipal user) =>
            user.IsInRole("Admin") || user.IsInRole("Recepcionista") || user.IsInRole("Odontologo");

        /// <summary>Id del paciente asociado al usuario logueado, o null si no es un paciente.</summary>
        public static int? PacienteId(this ClaimsPrincipal user)
        {
            if (!user.IsInRole("Paciente")) return null;
            return int.TryParse(user.FindFirst("EntidadId")?.Value, out var id) ? id : null;
        }

        /// <summary>El personal accede a cualquier paciente; un paciente solo a sus propios datos.</summary>
        public static bool PuedeAccederAPaciente(this ClaimsPrincipal user, int pacienteId) =>
            user.EsPersonal() || user.PacienteId() == pacienteId;
    }
}
