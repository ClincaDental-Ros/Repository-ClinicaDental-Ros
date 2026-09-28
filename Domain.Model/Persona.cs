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

        public virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(Nombre));

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new ArgumentException("El apellido es obligatorio.", nameof(Apellido));

            if (Dni <= 0)
                throw new ArgumentException("El DNI debe ser un número entero mayor a cero.", nameof(Dni));

            if (!string.IsNullOrWhiteSpace(Mail) && !Mail.Contains("@"))
                throw new ArgumentException("El formato del correo electrónico es inválido.", nameof(Mail));
        }

        public void SetNom(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetApe(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es obligatorio.", nameof(apellido));
            Apellido = apellido;
        }

        public void SetDni(int dni)
        {
            if (dni <= 0)
                throw new ArgumentException("El DNI debe ser un número entero mayor a cero.", nameof(dni));
            Dni = dni;
        }

        public void SetTel(string telefono)
        {
            Telefono = telefono ?? string.Empty;
        }

        public void SetMail(string mail)
        {
            if (!string.IsNullOrWhiteSpace(mail) && !mail.Contains("@"))
                throw new ArgumentException("El formato del correo electrónico es inválido.", nameof(mail));
            Mail = mail ?? string.Empty;
        }

        public void SetDom(string domicilio)
        {
            Domicilio = domicilio ?? string.Empty;
        }
    }
}
