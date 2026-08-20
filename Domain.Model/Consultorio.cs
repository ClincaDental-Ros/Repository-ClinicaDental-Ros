namespace Domain.Model
{
    public class Consultorio
    {
        public int Id { get; set; }
        public int NumConsultorio { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Equipamiento { get; set; } = string.Empty;

        public Consultorio() { }

        public Consultorio(int id, int numConsultorio, string direccion, string equipamiento = "")
        {
            Id = id;
            NumConsultorio = numConsultorio;
            Direccion = direccion;
            Equipamiento = equipamiento;
        }
    }
}