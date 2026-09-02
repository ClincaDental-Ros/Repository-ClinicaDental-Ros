namespace Domain.Model
{
    public class Factura
    {
        public int Id { get; set; }
        public int? TurnoId { get; set; }
        public TurnoOdontologico? Turno { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal DescuentoObraSocial { get; set; }
        public decimal Total { get; set; }
        public decimal MontoAPagarPaciente { get; set; }
        public bool EstadoPago { get; set; } = false;
        public string MetodoPago { get; set; } = "Efectivo"; 
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public List<ItemFactura> Items { get; set; } = new();

        public Factura() { }

        public Factura(int id, int? turnoId, int pacienteId, string descripcion, decimal subtotal, decimal descuentoObraSocial, decimal total, decimal montoAPagarPaciente, bool estadoPago = false, string metodoPago = "Efectivo")
        {
            Id = id;
            TurnoId = turnoId;
            PacienteId = pacienteId;
            Descripcion = descripcion;
            Subtotal = subtotal;
            DescuentoObraSocial = descuentoObraSocial;
            Total = total;
            MontoAPagarPaciente = montoAPagarPaciente;
            EstadoPago = estadoPago;
            MetodoPago = metodoPago;
            FechaEmision = DateTime.Now;
        }
    }
}
