namespace Domain.Model
{
    public class Factura
    {
        public int Id { get; private set; }
        public int? TurnoId { get; private set; }
        public TurnoOdontologico? Turno { get; private set; }
        public int PacienteId { get; private set; }
        public Paciente? Paciente { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public decimal Subtotal { get; private set; }
        public decimal DescuentoObraSocial { get; private set; }
        public decimal Total { get; private set; }
        public decimal MontoAPagarPaciente { get; private set; }
        public bool EstadoPago { get; private set; } = false;
        public string MetodoPago { get; private set; } = "Efectivo"; 
        public DateTime FechaEmision { get; private set; } = DateTime.Now;
        public List<ItemFactura> Items { get; private set; } = new();

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

        public void SetTurnoId(int? turnoId)
        {
            if (turnoId.HasValue && turnoId.Value <= 0)
                throw new ArgumentException("El ID del turno debe ser mayor a cero.", nameof(turnoId));
            TurnoId = turnoId;
        }

        public void SetPacienteId(int pacienteId)
        {
            if (pacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(pacienteId));
            PacienteId = pacienteId;
        }

        public void SetDescripcion(string descripcion) => Descripcion = descripcion ?? string.Empty;

        public void SetMontos(decimal subtotal, decimal descuentoObraSocial, decimal total, decimal montoAPagarPaciente)
        {
            if (subtotal < 0)
                throw new ArgumentException("El subtotal no puede ser negativo.", nameof(subtotal));
            if (descuentoObraSocial < 0)
                throw new ArgumentException("El descuento de la obra social no puede ser negativo.", nameof(descuentoObraSocial));
            if (total < 0)
                throw new ArgumentException("El total no puede ser negativo.", nameof(total));
            if (montoAPagarPaciente < 0)
                throw new ArgumentException("El monto a pagar por el paciente no puede ser negativo.", nameof(montoAPagarPaciente));

            Subtotal = subtotal;
            DescuentoObraSocial = descuentoObraSocial;
            Total = total;
            MontoAPagarPaciente = montoAPagarPaciente;
        }

        public void SetEstadoPago(bool estadoPago) => EstadoPago = estadoPago;

        public void SetMetodoPago(string metodoPago)
        {
            if (string.IsNullOrWhiteSpace(metodoPago))
                throw new ArgumentException("El método de pago es obligatorio.", nameof(metodoPago));
            MetodoPago = metodoPago;
        }

        public void SetFechaEmision(DateTime fecha) => FechaEmision = fecha;

        public void SetItems(List<ItemFactura> items) => Items = items ?? new List<ItemFactura>();
    }
}
