using System.Text.RegularExpressions;

namespace Domain.Model
{
    public abstract class Persona
    {
        public string Nombre { get; protected set; } = string.Empty;
        public string Apellido { get; protected set; } = string.Empty;
        public int Dni { get; protected set; }
        public string Telefono { get; protected set; } = string.Empty;
        public string Mail { get; protected set; } = string.Empty;
        public string Domicilio { get; protected set; } = string.Empty;

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

            if (!TelefonoValido(Telefono))
                throw new ArgumentException(MensajeTelefonoInvalido, nameof(Telefono));
        }

        private const string MensajeTelefonoInvalido = "El teléfono solo puede tener números, espacios, guiones, paréntesis y '+', con al menos 6 dígitos.";

        /// <summary>El teléfono es opcional; si se carga, admite prefijos y separadores pero no letras.</summary>
        public static bool TelefonoValido(string? telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono)) return true;
            return Regex.IsMatch(telefono.Trim(), @"^\+?[0-9\s\-()]+$") && telefono.Count(char.IsDigit) >= 6;
        }

        public void SetNom(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetNombre(string nombre) => SetNom(nombre);

        public void SetApe(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es obligatorio.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetApellido(string apellido) => SetApe(apellido);

        public void SetDni(int dni)
        {
            if (dni <= 0)
                throw new ArgumentException("El DNI debe ser un número entero mayor a cero.", nameof(dni));
            Dni = dni;
        }

        public void SetTel(string telefono)
        {
            if (!TelefonoValido(telefono))
                throw new ArgumentException(MensajeTelefonoInvalido, nameof(telefono));
            Telefono = telefono?.Trim() ?? string.Empty;
        }
        public void SetTelefono(string telefono) => SetTel(telefono);

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
        public void SetDomicilio(string domicilio) => SetDom(domicilio);
    }
}
