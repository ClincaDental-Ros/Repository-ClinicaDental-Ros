namespace Domain.Model
{
    public class ObraSocial
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
        public decimal PorcentajeCobertura { get; set; } = 0.50m;

        public ObraSocial() { }

        public ObraSocial(int id, string nombre, string plan, decimal porcentajeCobertura = 0.50m)
        {
            Id = id;
            Nombre = nombre;
            Plan = plan;
            PorcentajeCobertura = porcentajeCobertura;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la obra social no puede ser negativo.", nameof(Id));

            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentException("El nombre de la obra social es obligatorio.", nameof(Nombre));

            if (string.IsNullOrWhiteSpace(Plan))
                throw new ArgumentException("El plan de la obra social es obligatorio.", nameof(Plan));

            if (PorcentajeCobertura < 0 || PorcentajeCobertura > 1)
                throw new ArgumentOutOfRangeException(nameof(PorcentajeCobertura), "El porcentaje de cobertura debe estar entre 0 (0%) y 1 (100%).");
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la obra social no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la obra social es obligatorio.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetPlan(string plan)
        {
            if (string.IsNullOrWhiteSpace(plan))
                throw new ArgumentException("El plan de la obra social es obligatorio.", nameof(plan));
            Plan = plan;
        }

        public void SetPorcentajeCobertura(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 1)
                throw new ArgumentOutOfRangeException(nameof(porcentaje), "El porcentaje de cobertura debe estar entre 0 (0%) y 1 (100%).");
            PorcentajeCobertura = porcentaje;
        }
    }
}