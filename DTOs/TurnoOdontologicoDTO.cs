namespace DTOs
{
    public class TurnoOdontologicoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HorarioTurno { get; set; }
        public string EstadoTurno { get; set; } = "Pendiente";
        public string? MotivoCancelacion { get; set; }
        public int PacienteId { get; set; }
        public string? PacienteNombre { get; set; }
        public int OdontologoId { get; set; }
        public string? OdontologoNombre { get; set; }
        public int EspecialidadId { get; set; }
        public string? EspecialidadNombre { get; set; }
        public decimal MontoEstimado { get; set; }
    }
}
