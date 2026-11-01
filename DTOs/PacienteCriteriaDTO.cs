namespace DTOs
{
    public class PacienteCriteriaDTO
    {
        public string? Texto { get; set; }
        public bool? SoloHabilitados { get; set; }

        public PacienteCriteriaDTO() { }

        public PacienteCriteriaDTO(string? texto, bool? soloHabilitados = null)
        {
            Texto = texto;
            SoloHabilitados = soloHabilitados;
        }
    }
}