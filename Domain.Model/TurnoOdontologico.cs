namespace DentalClinic.Domain.Model
{
    public class TurnoOdontologico
    {
        public string Fecha { get; private set; }
        public string HorarioTurno { get; private set; }
        public bool EstadoTurno { get; private set; }
        public string MotivoCancelacion { get; private set; }


        public HorarioOdont(string fecha, string horarioTurno, bool estadoTurno, string motivoCancelacion)
        {
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
        public void SetEstado(bool estadoTurno)
        {
            if (string.IsNullOrWhiteSpace(estadoTurno))
                throw new ArgumentException("El dia de la semana no puede ser nulo o vacío.", nameof(estadoTurno));
            EstadoTurno = estadoTurno;
        }
        public void SetMotivo(string motivoCancelacion)
        {
            MotivoCancelacion = motivoCancelacion;

        }
