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
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la especialidad no puede ser negativo.", nameof(Id));

            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentException("El nombre de la especialidad es obligatorio.", nameof(Nombre));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la especialidad no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetNom(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la especialidad es obligatorio.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetDesc(string descripcion) => Descripcion = descripcion ?? string.Empty;
    }
}
