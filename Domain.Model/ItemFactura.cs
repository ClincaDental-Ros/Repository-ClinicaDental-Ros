namespace Domain.Model
{
    public class ItemFactura
    {
        public int Id { get; private set; }
        public int FacturaId { get; private set; }
        public Factura? Factura { get; private set; }
        public int InsumoId { get; private set; }
        public Insumo? Insumo { get; private set; }
        public int CantidadInsumo { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal
        {
            get => CantidadInsumo * PrecioUnitario;
            private set { }
        }

        public ItemFactura() { }

        public ItemFactura(int id, int facturaId, int insumoId, int cantidadInsumo, decimal precioUnitario)
        {
            Id = id;
            FacturaId = facturaId;
            InsumoId = insumoId;
            CantidadInsumo = cantidadInsumo;
            PrecioUnitario = precioUnitario;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del ítem de factura no puede ser negativo.", nameof(Id));

            if (InsumoId <= 0)
                throw new ArgumentException("El ID del insumo es obligatorio.", nameof(InsumoId));

            if (CantidadInsumo <= 0)
                throw new ArgumentException("La cantidad de insumo debe ser mayor a cero.", nameof(CantidadInsumo));

            if (PrecioUnitario < 0)
                throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(PrecioUnitario));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetFacturaId(int facturaId)
        {
            if (facturaId <= 0)
                throw new ArgumentException("El ID de la factura debe ser mayor a cero.", nameof(facturaId));
            FacturaId = facturaId;
        }

        public void SetInsumoId(int insumoId)
        {
            if (insumoId <= 0)
                throw new ArgumentException("El ID del insumo es obligatorio.", nameof(insumoId));
            InsumoId = insumoId;
        }

        public void SetCantidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad de insumo debe ser mayor a cero.", nameof(cantidad));
            CantidadInsumo = cantidad;
        }

        public void SetPrecioUnitario(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(precio));
            PrecioUnitario = precio;
        }
    }
}