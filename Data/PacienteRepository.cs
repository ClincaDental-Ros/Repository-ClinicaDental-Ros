using Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly TurnoMolarDbContext _context;

        public PacienteRepository(TurnoMolarDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> GetAsync(int id)
        {
            return await _context.Pacientes
                .Include(p => p.ObraSocial)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes
                .Include(p => p.ObraSocial)
                .OrderBy(p => p.Apellido)
                .ThenBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Paciente>> GetByCriteriaAsync(PacienteCriteria criteria)
        {
            try
            {
                var connectionString = _context.Database.GetConnectionString();
                if (!string.IsNullOrEmpty(connectionString))
                {
                    var sql = @"
                        SELECT p.Id, p.Nombre, p.Apellido, p.Dni, p.Telefono, p.Mail, p.Domicilio, 
                               p.EstadoHabilitado, p.ObraSocialId, p.NumeroAfiliado,
                               o.Nombre AS ObraSocialNombre, o.[Plan] AS ObraSocialPlan, o.PorcentajeCobertura
                        FROM Pacientes p
                        LEFT JOIN ObrasSociales o ON p.ObraSocialId = o.Id
                        WHERE 1 = 1";

                    if (!string.IsNullOrWhiteSpace(criteria.Texto))
                    {
                        sql += @" AND (p.Nombre LIKE @SearchTerm 
                                     OR p.Apellido LIKE @SearchTerm 
                                     OR p.Mail LIKE @SearchTerm 
                                     OR CAST(p.Dni AS VARCHAR(20)) LIKE @SearchTerm)";
                    }

                    if (criteria.SoloHabilitados.HasValue && criteria.SoloHabilitados.Value)
                    {
                        sql += " AND p.EstadoHabilitado = 1";
                    }

                    sql += " ORDER BY p.Apellido, p.Nombre";

                    var pacientesAdo = new List<Paciente>();
                    using var connection = new SqlConnection(connectionString);
                    using var command = new SqlCommand(sql, connection);

                    if (!string.IsNullOrWhiteSpace(criteria.Texto))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{criteria.Texto.Trim()}%");
                    }

                    await connection.OpenAsync();
                    using var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var id = reader.GetInt32(0);
                        var nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        var apellido = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        var dni = reader.GetInt32(3);
                        var telefono = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        var mail = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        var domicilio = reader.IsDBNull(6) ? "" : reader.GetString(6);
                        var habilitado = reader.GetBoolean(7);
                        int? obraSocialId = reader.IsDBNull(8) ? null : reader.GetInt32(8);
                        var numAfiliado = reader.IsDBNull(9) ? null : reader.GetString(9);

                        var pac = new Paciente(id, nombre, apellido, dni, telefono, mail, domicilio, habilitado, obraSocialId, numAfiliado);

                        if (obraSocialId.HasValue && !reader.IsDBNull(10))
                        {
                            var osNombre = reader.GetString(10);
                            var osPlan = reader.IsDBNull(11) ? "" : reader.GetString(11);
                            var osCob = reader.IsDBNull(12) ? 0.50m : reader.GetDecimal(12);
                            pac.ObraSocial = new ObraSocial(obraSocialId.Value, osNombre, osPlan, osCob);
                        }

                        pacientesAdo.Add(pac);
                    }

                    return pacientesAdo;
                }
            }
            catch
            {
            }

            var query = _context.Pacientes
                .Include(p => p.ObraSocial)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(criteria.Texto))
            {
                var text = criteria.Texto.Trim();
                query = query.Where(p =>
                    (p.Nombre != null && EF.Functions.Like(p.Nombre, $"%{text}%")) ||
                    (p.Apellido != null && EF.Functions.Like(p.Apellido, $"%{text}%")) ||
                    (p.Mail != null && EF.Functions.Like(p.Mail, $"%{text}%")) ||
                    EF.Functions.Like(p.Dni.ToString(), $"%{text}%"));
            }

            if (criteria.SoloHabilitados.HasValue && criteria.SoloHabilitados.Value)
            {
                query = query.Where(p => p.EstadoHabilitado);
            }

            return await query.OrderBy(p => p.Apellido).ThenBy(p => p.Nombre).ToListAsync();
        }

        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> UpdateAsync(Paciente paciente)
        {
            var existing = await _context.Pacientes.FindAsync(paciente.Id);
            if (existing == null)
                return false;

            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.Dni = paciente.Dni;
            existing.Telefono = paciente.Telefono;
            existing.Mail = paciente.Mail;
            existing.Domicilio = paciente.Domicilio;
            existing.EstadoHabilitado = paciente.EstadoHabilitado;
            existing.ObraSocialId = paciente.ObraSocialId;
            existing.NumeroAfiliado = paciente.NumeroAfiliado;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
                return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            return await _context.Pacientes.AnyAsync(p =>
                p.Mail.ToLower() == email.ToLower() &&
                (!excludeId.HasValue || p.Id != excludeId.Value));
        }

        public async Task<bool> DniExistsAsync(int dni, int? excludeId = null)
        {
            return await _context.Pacientes.AnyAsync(p =>
                p.Dni == dni &&
                (!excludeId.HasValue || p.Id != excludeId.Value));
        }
    }
}
