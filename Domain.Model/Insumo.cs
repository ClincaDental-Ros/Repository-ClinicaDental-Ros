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
        }

        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetDescripcion(string descripcion) => Descripcion = descripcion;
    }
}