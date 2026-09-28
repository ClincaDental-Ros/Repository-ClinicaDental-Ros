namespace Domain.Model
{
    public class Consultorio
    {
        public int Id { get; set; }
        public int NumConsultorio { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Equipamiento { get; set; } = string.Empty;

        public Consultorio() { }

        public Consultorio(int id, int numConsultorio, string direccion, string equipamiento = "")
        {
            Id = id;
            NumConsultorio = numConsultorio;
            Direccion = direccion;
            Equipamiento = equipamiento;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del consultorio no puede ser negativo.", nameof(Id));

            if (NumConsultorio <= 0)
                throw new ArgumentException("El número de consultorio debe ser mayor a cero.", nameof(NumConsultorio));

            if (string.IsNullOrWhiteSpace(Direccion))
                throw new ArgumentException("La dirección del consultorio es obligatoria.", nameof(Direccion));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del consultorio no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetNumConsultorio(int numConsultorio)
        {
            if (numConsultorio <= 0)
                throw new ArgumentException("El número de consultorio debe ser mayor a cero.", nameof(numConsultorio));
            NumConsultorio = numConsultorio;
        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección del consultorio es obligatoria.", nameof(direccion));
            Direccion = direccion;
        }
    }
}