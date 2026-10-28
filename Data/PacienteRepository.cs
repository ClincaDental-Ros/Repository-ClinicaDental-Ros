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

        /// <summary>
        /// Búsqueda de pacientes por criterio con ADO.NET (SqlConnection, SqlCommand y SqlDataReader).
        /// Si la consulta falla, la excepción se propaga: la API la registra y responde 500, no se oculta.
        /// </summary>
        public async Task<IEnumerable<Paciente>> GetByCriteriaAsync(PacienteCriteria criteria)
        {
            var connectionString = _context.Database.GetConnectionString()
                ?? throw new InvalidOperationException("No hay cadena de conexión configurada para la búsqueda de pacientes.");

            var sql = @"
                SELECT p.Id, p.Nombre, p.Apellido, p.Dni, p.Telefono, p.Mail, p.Domicilio,
                       p.EstadoHabilitado, p.ObraSocialId, p.NumeroAfiliado,
                       o.Nombre AS ObraSocialNombre, o.Descripcion AS ObraSocialPlan, o.PorcentajeCobertura
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

            if (criteria.SoloHabilitados == true)
            {
                sql += " AND p.EstadoHabilitado = 1";
            }

            sql += " ORDER BY p.Apellido, p.Nombre";

            var pacientes = new List<Paciente>();
            await using var connection = new SqlConnection(connectionString);
            await using var command = new SqlCommand(sql, connection);

            if (!string.IsNullOrWhiteSpace(criteria.Texto))
            {
                command.Parameters.AddWithValue("@SearchTerm", $"%{criteria.Texto.Trim()}%");
            }

            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
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

                var paciente = new Paciente(id, nombre, apellido, dni, telefono, mail, domicilio, habilitado, obraSocialId, numAfiliado);

                if (obraSocialId.HasValue && !reader.IsDBNull(10))
                {
                    var osNombre = reader.GetString(10);
                    var osPlan = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    var osCobertura = reader.IsDBNull(12) ? 0m : reader.GetDecimal(12);
                    paciente.SetObraSocial(new ObraSocial(obraSocialId.Value, osNombre, osPlan, osCobertura));
                }

                pacientes.Add(paciente);
            }

            return pacientes;
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

            existing.SetNombre(paciente.Nombre);
            existing.SetApellido(paciente.Apellido);
            existing.SetDni(paciente.Dni);
            existing.SetTelefono(paciente.Telefono);
            existing.SetMail(paciente.Mail);
            existing.SetDomicilio(paciente.Domicilio);
            existing.SetEstadoHabilitado(paciente.EstadoHabilitado);
            existing.SetObraSocial(paciente.ObraSocialId, paciente.NumeroAfiliado);

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

        public async Task<List<string>> GetRelacionesAsync(int id)
        {
            var relaciones = new List<string>();

            var turnos = await _context.Turnos.CountAsync(t => t.PacienteId == id);
            if (turnos > 0) relaciones.Add($"{turnos} turno(s)");

            if (await _context.HistoriasClinicas.AnyAsync(h => h.PacienteId == id))
                relaciones.Add("historia clínica");

            var multas = await _context.Multas.CountAsync(m => m.PacienteId == id);
            if (multas > 0) relaciones.Add($"{multas} multa(s)");

            var facturas = await _context.Facturas.CountAsync(f => f.PacienteId == id);
            if (facturas > 0) relaciones.Add($"{facturas} factura(s)");

            return relaciones;
        }
    }
}
