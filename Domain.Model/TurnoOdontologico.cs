namespace Domain.Model
{
    public class TurnoOdontologico
    {
        public int Id { get; set; }
        public string Fecha { get; private set; }
        public string HorarioTurno { get; private set; }
        public Estadoturno EstadoTurno { get; private set; }
        public string MotivoCancelacion { get; private set; }

        public enum Estadoturno
        {
            Confirmado,
            Realizado,
            Cancelado,
            Reprogramado
        }

        public TurnoOdontologico(int id, string fecha, string horarioTurno, Estadoturno estadoTurno, string motivoCancelacion)
        {
            Id = id;
            SetFechaT(fecha);
            SetHoraT(horarioTurno);
            SetEstado(estadoTurno);
            SetMotivo(motivoCancelacion);
        }

        public void SetFechaT(string fecha)
        {
            if (string.IsNullOrWhiteSpace(fecha))
                throw new ArgumentException("La fecha del turno no puede ser nulo o vacío.", nameof(fecha));
            Fecha = fecha;
        }

        public void SetHoraT(string horarioTurno)
        {
            if (string.IsNullOrWhiteSpace(horarioTurno))
                throw new ArgumentException("El horario del turno no puede ser nulo o vacío.", nameof(horarioTurno));
            HorarioTurno = horarioTurno;
        }

        public void SetEstado(Estadoturno estadoTurno)
        {
            EstadoTurno = estadoTurno;
        }

        public void SetMotivo(string motivoCancelacion)
        {
            MotivoCancelacion = motivoCancelacion;
        }
    }
}