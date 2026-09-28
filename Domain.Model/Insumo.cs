namespace Domain.Model
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Insumo() { }

        public Insumo(int id, string nombre, string descripcion, decimal precio = 0m, int stock = 0)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del insumo no puede ser negativo.", nameof(Id));

            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentException("El nombre del insumo es obligatorio.", nameof(Nombre));

            if (Precio < 0)
                throw new ArgumentException("El precio del insumo no puede ser negativo.", nameof(Precio));

            if (Stock < 0)
                throw new ArgumentException("El stock del insumo no puede ser negativo.", nameof(Stock));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del insumo no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del insumo es obligatorio.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetDescripcion(string descripcion) => Descripcion = descripcion ?? string.Empty;

        public void SetPrecio(decimal precio)
        {
            if (precio < 0)
                throw new ArgumentException("El precio del insumo no puede ser negativo.", nameof(precio));
            Precio = precio;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("El stock del insumo no puede ser negativo.", nameof(stock));
            Stock = stock;
        }
    }
}