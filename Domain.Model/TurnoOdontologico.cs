namespace Domain.Model
{
    public class TurnoOdontologico
    {
        public int Id { get; set; }
        public string Fecha { get; private set; }
        public string HorarioTurno { get; private set; }
        public string EstadoTurno { get; private set; }
        public string MotivoCancelacion { get; private set; }

        private static int _nextId = 0;


        public TurnoOdontologico(string fecha, string horarioTurno, string estadoTurno, string motivoCancelacion, int id)
        {
            SetFechaT(fecha);
            SetHoraT(horarioTurno);
            SetEstado(estadoTurno);
            SetMotivo(motivoCancelacion);
            SetIncrementalID();

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
        public void SetEstado(string estadoTurno)
        {
            if (string.IsNullOrWhiteSpace(estadoTurno))
                throw new ArgumentException("El estado del turno no puede ser nulo o vacío.", nameof(estadoTurno));
            EstadoTurno = estadoTurno;
        }
        public void SetMotivo(string motivoCancelacion)
        {
            MotivoCancelacion = motivoCancelacion;

        }

        public void SetIncrementalID()
        {
            _nextId++;
            Id = _nextId;

        }


    }
}
