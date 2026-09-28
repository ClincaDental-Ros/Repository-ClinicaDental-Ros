namespace Domain.Model
{
    public class ItemFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }
        public int InsumoId { get; set; }
        public Insumo? Insumo { get; set; }
        public int CantidadInsumo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal
        {
            get => CantidadInsumo * PrecioUnitario;
            set { }
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