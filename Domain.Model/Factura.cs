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
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la factura no puede ser negativo.", nameof(Id));

            if (PacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(PacienteId));

            if (TurnoId.HasValue && TurnoId.Value <= 0)
                throw new ArgumentException("El ID del turno debe ser mayor a cero.", nameof(TurnoId));

            if (Subtotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo.", nameof(Subtotal));

            if (DescuentoObraSocial < 0)
                throw new ArgumentException("El descuento de la obra social no puede ser negativo.", nameof(DescuentoObraSocial));

            if (Total < 0)
                throw new ArgumentException("El total no puede ser negativo.", nameof(Total));

            if (MontoAPagarPaciente < 0)
                throw new ArgumentException("El monto a pagar por el paciente no puede ser negativo.", nameof(MontoAPagarPaciente));

            if (string.IsNullOrWhiteSpace(MetodoPago))
                throw new ArgumentException("El método de pago es obligatorio.", nameof(MetodoPago));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la factura no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetMetodoPago(string metodoPago)
        {
            if (string.IsNullOrWhiteSpace(metodoPago))
                throw new ArgumentException("El método de pago es obligatorio.", nameof(metodoPago));
            MetodoPago = metodoPago;
        }
    }
}
