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
