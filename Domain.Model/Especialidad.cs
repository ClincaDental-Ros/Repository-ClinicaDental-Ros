namespace Domain.Model
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public Especialidad() { }

        public Especialidad(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public void SetNom(string nombre) => Nombre = nombre;
        public void SetDesc(string descripcion) => Descripcion = descripcion;
    }
}
