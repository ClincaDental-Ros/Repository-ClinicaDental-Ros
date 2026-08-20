namespace Domain.Model
{
    public class TurnoOdontologico
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HorarioTurno { get; set; }
        public EstadoTurnoEnum EstadoTurno { get; set; }
        public string? MotivoCancelacion { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int OdontologoId { get; set; }
        public Odontologo? Odontologo { get; set; }

        public int EspecialidadId { get; set; }
        public Especialidad? Especialidad { get; set; }

        public decimal MontoEstimado { get; set; }

        public enum EstadoTurnoEnum
        {
            Pendiente,
            Presente,
            Atendido,
            Cancelado,
            NoAsistido
        }

        public TurnoOdontologico() { }

        public TurnoOdontologico(
            int id,
            DateTime fecha,
            TimeOnly horarioTurno,
            EstadoTurnoEnum estadoTurno,
            string? motivoCancelacion = null,
            int pacienteId = 0,
            int odontologoId = 0,
            int especialidadId = 0,
            decimal montoEstimado = 0)
        {
            Id = id;
            Fecha = fecha;
            HorarioTurno = horarioTurno;
            EstadoTurno = estadoTurno;
            MotivoCancelacion = motivoCancelacion;
            PacienteId = pacienteId;
            OdontologoId = odontologoId;
            EspecialidadId = especialidadId;
            MontoEstimado = montoEstimado;
        }

        public void SetFechaT(DateTime fecha) => Fecha = fecha;
        public void SetHoraT(TimeOnly horarioTurno) => HorarioTurno = horarioTurno;
        public void SetId(int id) => Id = id;
        public void SetEstado(EstadoTurnoEnum estadoTurno) => EstadoTurno = estadoTurno;
        public void SetMotivo(string? motivoCancelacion) => MotivoCancelacion = motivoCancelacion;
    }
}