namespace Domain.Model
{
    public class Multa
    {
        public int Id { get; private set; }
        public int PacienteId { get; private set; }
        public Paciente? Paciente { get; private set; }
        public decimal Monto { get; private set; }
        public bool EstadoPago { get; private set; } = false;
        public DateTime FechaEmision { get; private set; } = DateTime.Now;
        public DateTime? FechaPago { get; private set; }
        public string Motivo { get; private set; } = "Ausencia no justificada a turno odontológico";

        public Multa() { }

        public Multa(int id, int pacienteId, decimal monto, bool estadoPago = false, DateTime? fechaPago = null, string motivo = "Ausencia no justificada a turno odontológico")
        {
            Id = id;
            PacienteId = pacienteId;
            Monto = monto;
            EstadoPago = estadoPago;
            FechaEmision = DateTime.Now;
            FechaPago = fechaPago;
            Motivo = motivo;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la multa no puede ser negativo.", nameof(Id));

            if (PacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(PacienteId));

            if (Monto <= 0)
                throw new ArgumentException("El monto de la multa debe ser mayor a cero.", nameof(Monto));

            if (string.IsNullOrWhiteSpace(Motivo))
                throw new ArgumentException("El motivo de la multa es obligatorio.", nameof(Motivo));
        }

        public void SetFechaEmision(DateTime fecha) => FechaEmision = fecha;

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la multa no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetPacienteId(int pacienteId)
        {
            if (pacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(pacienteId));
            PacienteId = pacienteId;
        }

        public void SetMonto(decimal monto)
        {
            if (monto <= 0)
                throw new ArgumentException("El monto de la multa debe ser mayor a cero.", nameof(monto));
            Monto = monto;
        }

        public void SetMotivo(string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
                throw new ArgumentException("El motivo de la multa es obligatorio.", nameof(motivo));
            Motivo = motivo;
        }

        public void SetEstadoPago(bool estadoPago) => EstadoPago = estadoPago;

        public void SetFechaPago(DateTime? fechaPago) => FechaPago = fechaPago;

        public void MarcarComoPagada()
        {
            if (EstadoPago)
                throw new InvalidOperationException("La multa ya fue pagada.");
            EstadoPago = true;
            FechaPago = DateTime.Now;
        }
    }
}
