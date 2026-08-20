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
        }

        public void SetId(int id) => Id = id;
        public void SetEstadoHabilitado(bool habilitado) => EstadoHabilitado = habilitado;
    }
}