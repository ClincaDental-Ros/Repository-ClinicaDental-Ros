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
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID de la historia clínica no puede ser negativo.", nameof(Id));

            if (NumeroHistoriaClinica <= 0)
                throw new ArgumentException("El número de historia clínica debe ser mayor a cero.", nameof(NumeroHistoriaClinica));

            if (PacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(PacienteId));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID de la historia clínica no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetNumeroHistoriaClinica(int num)
        {
            if (num <= 0)
                throw new ArgumentException("El número de historia clínica debe ser mayor a cero.", nameof(num));
            NumeroHistoriaClinica = num;
        }
    }
}