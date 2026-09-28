namespace Domain.Model
{
    public class HorarioOdont
    {
        public int Id { get; set; }
        public int OdontologoId { get; set; }
        public Odontologo? Odontologo { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeOnly HoraDesde { get; set; }
        public TimeOnly HoraHasta { get; set; }

        public HorarioOdont() { }

        public HorarioOdont(int id, int odontologoId, string diaSemana, TimeOnly horaDesde, TimeOnly horaHasta)
        {
            Id = id;
            OdontologoId = odontologoId;
            DiaSemana = diaSemana;
            HoraDesde = horaDesde;
            HoraHasta = horaHasta;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del horario no puede ser negativo.", nameof(Id));

            if (OdontologoId <= 0)
                throw new ArgumentException("El ID del odontólogo es obligatorio.", nameof(OdontologoId));

            if (string.IsNullOrWhiteSpace(DiaSemana))
                throw new ArgumentException("El día de la semana es obligatorio.", nameof(DiaSemana));

            if (HoraHasta <= HoraDesde)
                throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio.", nameof(HoraHasta));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del horario no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetDiaSemana(string diaSemana)
        {
            if (string.IsNullOrWhiteSpace(diaSemana))
                throw new ArgumentException("El día de la semana es obligatorio.", nameof(diaSemana));
            DiaSemana = diaSemana;
        }

        public void SetHorarios(TimeOnly desde, TimeOnly hasta)
        {
            if (hasta <= desde)
                throw new ArgumentException("La hora de fin debe ser posterior a la hora de inicio.", nameof(hasta));
            HoraDesde = desde;
            HoraHasta = hasta;
        }
    }
}
