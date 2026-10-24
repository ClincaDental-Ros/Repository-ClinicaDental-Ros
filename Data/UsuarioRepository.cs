using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TurnoMolarDbContext _context;

        public UsuarioRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username.ToLower() == username.Trim().ToLower());
        }

        public async Task<Usuario?> GetByEntidadIdAsync(int entidadId, string rol)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.EntidadId == entidadId && u.Rol.ToLower() == rol.Trim().ToLower());
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            var existing = await _context.Usuarios.FindAsync(usuario.Id);
            if (existing == null)
                return false;

            existing.SetNombreCompleto(usuario.NombreCompleto);
            existing.SetEmail(usuario.Email);
            existing.SetRol(usuario.Rol);
            existing.SetActivo(usuario.Activo);
            existing.SetPasswordHash(usuario.PasswordHash);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
