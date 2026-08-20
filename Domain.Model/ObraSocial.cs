namespace Domain.Model
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
        public decimal PorcentajeCobertura { get; set; } = 0.50m; // Ejemplo: 50% de cobertura por defecto

        public ObraSocial() { }

        public ObraSocial(int id, string nombre, string plan, decimal porcentajeCobertura = 0.50m)
        {
            Id = id;
            Nombre = nombre;
            Plan = plan;
            PorcentajeCobertura = porcentajeCobertura;
        }

        public void SetNombre(string nombre) => Nombre = nombre;
        public void SetPlan(string plan) => Plan = plan;
    }
}