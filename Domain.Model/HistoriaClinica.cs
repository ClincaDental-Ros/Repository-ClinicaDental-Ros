namespace Domain.Model
{
    public class HistoriaClinica
    {
        public int Id { get; private set; }
        public int NumeroHistoriaClinica { get; private set; }
        public int PacienteId { get; private set; }
        public Paciente? Paciente { get; private set; }
        public DateTime FechaAlta { get; private set; } = DateTime.Now;
        public string AntecedentesMedicos { get; private set; } = string.Empty;
        public string Alergias { get; private set; } = string.Empty;
        public string ObservacionesGenerales { get; private set; } = string.Empty;

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

        public void SetPacienteId(int pacienteId)
        {
            if (pacienteId <= 0)
                throw new ArgumentException("El ID del paciente es obligatorio.", nameof(pacienteId));
            PacienteId = pacienteId;
        }

        public void SetAntecedentesMedicos(string antecedentes) => AntecedentesMedicos = antecedentes ?? string.Empty;

        public void SetAlergias(string alergias) => Alergias = alergias ?? string.Empty;

        public void SetObservacionesGenerales(string observaciones) => ObservacionesGenerales = observaciones ?? string.Empty;
    }
}