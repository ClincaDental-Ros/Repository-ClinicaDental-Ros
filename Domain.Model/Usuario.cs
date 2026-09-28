namespace Domain.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; 
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int? EntidadId { get; set; } 

        public Usuario() { }

        public Usuario(int id, string username, string passwordHash, string rol, string nombreCompleto, string email, bool activo = true, int? entidadId = null)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Rol = rol;
            NombreCompleto = nombreCompleto;
            Email = email;
            Activo = activo;
            EntidadId = entidadId;
            Validate();
        }

        public void Validate()
        {
            if (Id < 0)
                throw new ArgumentException("El ID del usuario no puede ser negativo.", nameof(Id));

            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(Username));

            if (string.IsNullOrWhiteSpace(PasswordHash))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(PasswordHash));

            if (string.IsNullOrWhiteSpace(Rol))
                throw new ArgumentException("El rol del usuario es obligatorio.", nameof(Rol));

            if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
                throw new ArgumentException("El formato del correo electrónico es inválido.", nameof(Email));

            if (EntidadId.HasValue && EntidadId.Value <= 0)
                throw new ArgumentException("El ID de la entidad debe ser mayor a cero.", nameof(EntidadId));
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("El nombre de usuario es obligatorio.", nameof(username));
            Username = username;
        }

        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(passwordHash));
            PasswordHash = passwordHash;
        }

        public void SetRol(string rol)
        {
            if (string.IsNullOrWhiteSpace(rol))
                throw new ArgumentException("El rol del usuario es obligatorio.", nameof(rol));
            Rol = rol;
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El ID del usuario no puede ser negativo.", nameof(id));
            Id = id;
        }
    }
}
