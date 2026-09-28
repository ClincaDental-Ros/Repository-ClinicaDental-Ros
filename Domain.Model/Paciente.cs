namespace Domain.Model
{
    public class Paciente : Persona
    {
        public int Id { get; set; }
        public bool EstadoHabilitado { get; set; } = true;
        public int? ObraSocialId { get; set; }
        public ObraSocial? ObraSocial { get; set; }
        public string? NumeroAfiliado { get; set; }

        public Paciente() { }

        public Paciente(int id, string nombre, string apellido, int dni, string telefono, string mail, string domicilio, bool estadoHabilitado = true, int? obraSocialId = null, string? numeroAfiliado = null)
            : base(nombre, apellido, dni, telefono, mail, domicilio)
        {
            Id = id;
            EstadoHabilitado = estadoHabilitado;
            ObraSocialId = obraSocialId;
            NumeroAfiliado = numeroAfiliado;
            Validate();
        }

        public override void Validate()
        {
            base.Validate();

            if (Id < 0)
                throw new ArgumentException("El ID del paciente no puede ser negativo.", nameof(Id));

            if (ObraSocialId.HasValue && ObraSocialId.Value <= 0)
                throw new ArgumentException("El ID de la obra social debe ser mayor a cero.", nameof(ObraSocialId));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del paciente no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetEstadoHabilitado(bool habilitado) => EstadoHabilitado = habilitado;
    }
}