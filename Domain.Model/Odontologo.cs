namespace Domain.Model
{
    public class Odontologo : Persona
    {
        public int Id { get; set; }
        public int NumMatricula { get; set; }
        public int EspecialidadId { get; set; }
        public Especialidad? Especialidad { get; set; }

        public Odontologo() { }

        public Odontologo(int id, int numMatricula, string nombre, string apellido, int dni, string telefono, string mail, string domicilio, int especialidadId = 1)
            : base(nombre, apellido, dni, telefono, mail, domicilio)
        {
            Id = id;
            NumMatricula = numMatricula;
            EspecialidadId = especialidadId;
        }
    }
}