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
            Validate();
        }

        public override void Validate()
        {
            base.Validate();

            if (Id < 0)
                throw new ArgumentException("El ID del odontólogo no puede ser negativo.", nameof(Id));

            if (NumMatricula <= 0)
                throw new ArgumentException("El número de matrícula debe ser mayor a cero.", nameof(NumMatricula));

            if (EspecialidadId <= 0)
                throw new ArgumentException("La especialidad es obligatoria y su ID debe ser mayor a cero.", nameof(EspecialidadId));
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del odontólogo no puede ser negativo.", nameof(id));
            Id = id;
        }

        public void SetMatricula(int numMatricula)
        {
            if (numMatricula <= 0)
                throw new ArgumentException("El número de matrícula debe ser mayor a cero.", nameof(numMatricula));
            NumMatricula = numMatricula;
        }
    }
}