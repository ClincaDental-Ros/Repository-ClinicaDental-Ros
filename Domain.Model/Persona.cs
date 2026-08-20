namespace Domain.Model
{
    public abstract class Persona
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Dni { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;

        protected Persona() { }

        protected Persona(string nombre, string apellido, int dni, string telefono, string mail, string domicilio)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Mail = mail;
            Domicilio = domicilio;
        }

        public void SetNom(string nombre) => Nombre = nombre;
        public void SetApe(string apellido) => Apellido = apellido;
        public void SetDni(int dni) => Dni = dni;
        public void SetTel(string telefono) => Telefono = telefono;
        public void SetMail(string mail) => Mail = mail;
        public void SetDom(string domicilio) => Domicilio = domicilio;
    }
}
