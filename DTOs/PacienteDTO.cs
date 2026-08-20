namespace DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Dni { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
        public bool EstadoHabilitado { get; set; } = true;
        public int? ObraSocialId { get; set; }
        public string? ObraSocialNombre { get; set; }
        public string? NumeroAfiliado { get; set; }

        public string NombreCompleto => $"{Apellido}, {Nombre}";
    }
}