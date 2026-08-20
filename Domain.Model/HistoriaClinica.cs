namespace Domain.Model
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public int NumeroHistoriaClinica { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public string AntecedentesMedicos { get; set; } = string.Empty;
        public string Alergias { get; set; } = string.Empty;
        public string ObservacionesGenerales { get; set; } = string.Empty;

        public HistoriaClinica() { }

        public HistoriaClinica(int id, int numeroHistoriaClinica, int pacienteId, DateTime fechaAlta, string antecedentesMedicos = "", string alergias = "", string observacionesGenerales = "")
        {
            Id = id;
            NumeroHistoriaClinica = numeroHistoriaClinica;
            PacienteId = pacienteId;
            FechaAlta = fechaAlta;
            AntecedentesMedicos = antecedentesMedicos;
            Alergias = alergias;
            ObservacionesGenerales = observacionesGenerales;
        }
    }
}