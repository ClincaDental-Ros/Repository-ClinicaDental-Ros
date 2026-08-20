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
        }
    }
}