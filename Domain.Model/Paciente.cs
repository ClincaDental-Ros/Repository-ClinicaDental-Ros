namespace Domain.Model
{
    public class Paciente : Persona
    {
        public int Id { get; private set; }
        public bool EstadoHabilitado { get; private set; } = true;
        public int? ObraSocialId { get; private set; }
        public ObraSocial? ObraSocial { get; private set; }
        public string? NumeroAfiliado { get; private set; }

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

        public void SetObraSocial(ObraSocial? obraSocial)
        {
            ObraSocial = obraSocial;
            if (obraSocial != null)
                ObraSocialId = obraSocial.Id;
        }

        public void SetObraSocial(int? obraSocialId, string? numeroAfiliado = null)
        {
            if (obraSocialId.HasValue && obraSocialId.Value <= 0)
                throw new ArgumentException("El ID de la obra social debe ser mayor a cero.", nameof(obraSocialId));
            ObraSocialId = obraSocialId;
            NumeroAfiliado = numeroAfiliado;
        }

        public void SetObraSocialId(int? obraSocialId)
        {
            if (obraSocialId.HasValue && obraSocialId.Value <= 0)
                throw new ArgumentException("El ID de la obra social debe ser mayor a cero.", nameof(obraSocialId));
            ObraSocialId = obraSocialId;
        }

        public void SetNumeroAfiliado(string? numeroAfiliado)
        {
            NumeroAfiliado = numeroAfiliado;
        }
    }
}