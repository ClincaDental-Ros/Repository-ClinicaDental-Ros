namespace DTOs
{
    public class TurnoOdontologicoDTO
    {
      public int Id { get; set; }
      public string Fecha { get; set; } = string.Empty;
      public string HorarioTurno { get; set; } = string.Empty;
      public bool EstadoTurno { get; set; }
      public string MotivoCancelacion { get; set; } = string.Empty;
    }
  }



