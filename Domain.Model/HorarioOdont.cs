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
        }
    }
}
