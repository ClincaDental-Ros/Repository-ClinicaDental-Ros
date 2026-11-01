namespace Domain.Model
{
    public class TurnoOdontologico
    {
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public TimeOnly HorarioTurno { get; private set; }
        public EstadoTurnoEnum EstadoTurno { get; private set; }
        public string? MotivoCancelacion { get; private set; }

        public int PacienteId { get; private set; }
        public Paciente? Paciente { get; private set; }

        public int OdontologoId { get; private set; }
        public Odontologo? Odontologo { get; private set; }

        public int EspecialidadId { get; private set; }
        public Especialidad? Especialidad { get; private set; }

        public decimal MontoEstimado { get; private set; }

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
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del turno no puede ser negativo.", nameof(Id));

            if (PacienteId < 0)
                throw new ArgumentException("El ID del paciente no puede ser negativo.", nameof(PacienteId));

            if (OdontologoId < 0)
                throw new ArgumentException("El ID del odontólogo no puede ser negativo.", nameof(OdontologoId));

            if (EspecialidadId < 0)
                throw new ArgumentException("El ID de la especialidad no puede ser negativo.", nameof(EspecialidadId));

            if (MontoEstimado < 0)
                throw new ArgumentException("El monto estimado no puede ser negativo.", nameof(MontoEstimado));

            if (EstadoTurno == EstadoTurnoEnum.Cancelado && string.IsNullOrWhiteSpace(MotivoCancelacion))
                throw new ArgumentException("Debe ingresar un motivo al cancelar un turno.", nameof(MotivoCancelacion));
        }

        public void SetFecha(DateTime fecha) => Fecha = fecha;
        public void SetFechaT(DateTime fecha) => SetFecha(fecha);

        public void SetHorarioTurno(TimeOnly horarioTurno) => HorarioTurno = horarioTurno;
        public void SetHoraT(TimeOnly horarioTurno) => SetHorarioTurno(horarioTurno);

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetPacienteId(int pacienteId)
        {
            if (pacienteId < 0)
                throw new ArgumentException("El ID del paciente no puede ser negativo.", nameof(pacienteId));
            PacienteId = pacienteId;
        }

        public void SetOdontologoId(int odontologoId)
        {
            if (odontologoId < 0)
                throw new ArgumentException("El ID del odontólogo no puede ser negativo.", nameof(odontologoId));
            OdontologoId = odontologoId;
        }

        public void SetEspecialidadId(int especialidadId)
        {
            if (especialidadId < 0)
                throw new ArgumentException("El ID de la especialidad no puede ser negativo.", nameof(especialidadId));
            EspecialidadId = especialidadId;
        }

        public void SetMontoEstimado(decimal montoEstimado)
        {
            if (montoEstimado < 0)
                throw new ArgumentException("El monto estimado no puede ser negativo.", nameof(montoEstimado));
            MontoEstimado = montoEstimado;
        }

        /// <summary>
        /// Transiciones permitidas entre estados. El servidor las hace cumplir aunque la pantalla
        /// ya las impida: Pendiente → Presente / Cancelado / NoAsistido; Presente → Atendido / Cancelado.
        /// Atendido, Cancelado y NoAsistido son estados finales.
        /// </summary>
        public static bool PuedeCambiar(EstadoTurnoEnum desde, EstadoTurnoEnum hacia) => (desde, hacia) switch
        {
            (EstadoTurnoEnum.Pendiente, EstadoTurnoEnum.Presente) => true,
            (EstadoTurnoEnum.Pendiente, EstadoTurnoEnum.Cancelado) => true,
            (EstadoTurnoEnum.Pendiente, EstadoTurnoEnum.NoAsistido) => true,
            (EstadoTurnoEnum.Presente, EstadoTurnoEnum.Atendido) => true,
            (EstadoTurnoEnum.Presente, EstadoTurnoEnum.Cancelado) => true,
            _ => false
        };

        public static string Descripcion(EstadoTurnoEnum estado) => estado switch
        {
            EstadoTurnoEnum.Pendiente => "pendiente",
            EstadoTurnoEnum.Presente => "en sala de espera",
            EstadoTurnoEnum.Atendido => "atendido",
            EstadoTurnoEnum.Cancelado => "cancelado",
            EstadoTurnoEnum.NoAsistido => "ausente",
            _ => estado.ToString()
        };

        private void ValidarTransicion(EstadoTurnoEnum nuevo)
        {
            if (nuevo == EstadoTurno) return;
            if (!Enum.IsDefined(typeof(EstadoTurnoEnum), nuevo))
                throw new ArgumentException($"El estado de turno '{nuevo}' no existe.", nameof(nuevo));
            if (!PuedeCambiar(EstadoTurno, nuevo))
                throw new InvalidOperationException(
                    $"Un turno {Descripcion(EstadoTurno)} no puede pasar a {Descripcion(nuevo)}.");
        }

        /// <summary>Fecha, horario y profesional solo se pueden cambiar mientras el turno está pendiente.</summary>
        public void ValidarReprogramable()
        {
            if (EstadoTurno != EstadoTurnoEnum.Pendiente)
                throw new InvalidOperationException(
                    $"Solo se pueden modificar turnos pendientes; este turno está {Descripcion(EstadoTurno)}.");
        }

        public void SetEstado(EstadoTurnoEnum estadoTurno)
        {
            if (estadoTurno == EstadoTurnoEnum.Cancelado && string.IsNullOrWhiteSpace(MotivoCancelacion))
            {
                throw new ArgumentException("Debe ingresar un motivo al cancelar un turno.", nameof(MotivoCancelacion));
            }
            ValidarTransicion(estadoTurno);
            EstadoTurno = estadoTurno;
        }

        public void SetMotivo(string? motivoCancelacion)
        {
            if (EstadoTurno == EstadoTurnoEnum.Cancelado && string.IsNullOrWhiteSpace(motivoCancelacion))
            {
                throw new ArgumentException("Debe ingresar un motivo al cancelar un turno.", nameof(motivoCancelacion));
            }
            MotivoCancelacion = motivoCancelacion;
        }

        public void Cancelar(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("Debe ingresar un motivo al cancelar un turno.", nameof(motivo));
            }
            ValidarTransicion(EstadoTurnoEnum.Cancelado);
            EstadoTurno = EstadoTurnoEnum.Cancelado;
            MotivoCancelacion = motivo;
        }

        public void ConfirmarPresencia()
        {
            ValidarTransicion(EstadoTurnoEnum.Presente);
            EstadoTurno = EstadoTurnoEnum.Presente;
        }

        public void Atender()
        {
            ValidarTransicion(EstadoTurnoEnum.Atendido);
            EstadoTurno = EstadoTurnoEnum.Atendido;
        }

        public void RegistrarAusencia(string? motivo = null)
        {
            ValidarTransicion(EstadoTurnoEnum.NoAsistido);
            EstadoTurno = EstadoTurnoEnum.NoAsistido;
            MotivoCancelacion = string.IsNullOrWhiteSpace(motivo) ? "Ausencia registrada en recepción" : motivo;
        }
    }
}
