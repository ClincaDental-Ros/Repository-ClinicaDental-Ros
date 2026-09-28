namespace Domain.Model
{
    public class Multa
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public decimal Monto { get; set; }
        public bool EstadoPago { get; set; } = false;
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public DateTime? FechaPago { get; set; }
        public string Motivo { get; set; } = "Ausencia no justificada a turno odontológico";

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

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la multa no puede ser negativo.", nameof(id));
            Id = id;
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

        public void MarcarComoPagada()
        {
            if (EstadoPago)
                throw new InvalidOperationException("La multa ya fue pagada.");
            EstadoPago = true;
            FechaPago = DateTime.Now;
        }
    }
}
