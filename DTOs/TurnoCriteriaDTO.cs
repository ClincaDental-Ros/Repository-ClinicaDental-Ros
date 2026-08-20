namespace DTOs
{
    public class TurnoCriteriaDTO
    {
        public DateTime? Fecha { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int? OdontologoId { get; set; }
        public int? PacienteId { get; set; }
        public int? EspecialidadId { get; set; }
        public string? EstadoTurno { get; set; }
    }
}
