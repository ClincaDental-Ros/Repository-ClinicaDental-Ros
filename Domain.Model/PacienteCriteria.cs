namespace Domain.Model
{
    public class PacienteCriteria
    {
        public string? Texto { get; set; }
        public bool? SoloHabilitados { get; set; }

        public PacienteCriteria() { }

        public PacienteCriteria(string? texto, bool? soloHabilitados = null)
        {
            Texto = texto;
            SoloHabilitados = soloHabilitados;
        }
    }
}