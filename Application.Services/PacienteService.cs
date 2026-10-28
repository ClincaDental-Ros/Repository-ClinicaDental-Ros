using Data;
using Domain.Model;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public interface IPacienteService
    {
        Task<PacienteDTO?> GetAsync(int id);
        Task<IEnumerable<PacienteDTO>> GetAllAsync();
        Task<IEnumerable<PacienteDTO>> GetByCriteriaAsync(PacienteCriteriaDTO criteriaDTO);
        Task<PacienteDTO> AddAsync(PacienteDTO dto);
        Task<bool> UpdateAsync(PacienteDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> ToggleHabilitacionAsync(int id, bool habilitar);
    }

    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TurnoMolarDbContext _context;

    public PacienteService(IPacienteRepository pacienteRepository, IUsuarioRepository usuarioRepository, TurnoMolarDbContext context)
        {
            _pacienteRepository = pacienteRepository;
            _usuarioRepository = usuarioRepository;
           _context = context;
         }

        public async Task<PacienteDTO?> GetAsync(int id)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return null;

            var dto = MapToDTO(paciente);
            var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
            if (usuario != null)
                dto.Username = usuario.Username;
            return dto;
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            var dtos = pacientes.Select(MapToDTO).ToList();

            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                var userLookup = usuarios
                    .Where(u => u.Rol != null && u.Rol.Equals("Paciente", StringComparison.OrdinalIgnoreCase) && u.EntidadId.HasValue)
                    .ToLookup(u => u.EntidadId!.Value);

                foreach (var dto in dtos)
                {
                    var u = userLookup[dto.Id].FirstOrDefault();
                    if (u != null)
                        dto.Username = u.Username;
                }
            }
            catch
            {
                
            }

            return dtos;
        }

        public async Task<IEnumerable<PacienteDTO>> GetByCriteriaAsync(PacienteCriteriaDTO criteriaDTO)
        {
            var criteria = new PacienteCriteria(criteriaDTO.Texto, criteriaDTO.SoloHabilitados);
            var pacientes = await _pacienteRepository.GetByCriteriaAsync(criteria);
            var dtos = pacientes.Select(MapToDTO).ToList();

            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                var userLookup = usuarios
                    .Where(u => u.Rol != null && u.Rol.Equals("Paciente", StringComparison.OrdinalIgnoreCase) && u.EntidadId.HasValue)
                    .ToLookup(u => u.EntidadId!.Value);

                foreach (var dto in dtos)
                {
                    var u = userLookup[dto.Id].FirstOrDefault();
                    if (u != null)
                        dto.Username = u.Username;
                }
            }
            catch
            {

            }

            return dtos;
        }

        public async Task<PacienteDTO> AddAsync(PacienteDTO dto)
        {
            if (await _pacienteRepository.DniExistsAsync(dto.Dni))
            {
                throw new InvalidOperationException($"Ya existe un paciente registrado con el DNI {dto.Dni}.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Mail) && await _pacienteRepository.EmailExistsAsync(dto.Mail))
            {
                throw new InvalidOperationException($"Ya existe un paciente registrado con el email {dto.Mail}.");
            }

            var paciente = new Paciente(
                0,
                dto.Nombre,
                dto.Apellido,
                dto.Dni,
                dto.Telefono,
                dto.Mail,
                dto.Domicilio,
                dto.EstadoHabilitado,
                dto.ObraSocialId,
                dto.NumeroAfiliado
            );

            await _pacienteRepository.AddAsync(paciente);

            string createdUsername = "";
            string defaultPassword = "paciente123";


            string baseUsername = !string.IsNullOrWhiteSpace(dto.Mail) && dto.Mail.Contains("@")
            ? dto.Mail.Split('@')[0].ToLower()
             : $"{dto.Nombre.ToLower().Replace(" ", "")}{dto.Dni}";

            string username = baseUsername;

            int counter = 1;

         while (await _usuarioRepository.GetByUsernameAsync(username) != null)
          username = $"{baseUsername}{counter++}";
          createdUsername = username;
     
      using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        await _pacienteRepository.AddAsync(paciente);
        var usuario = new Usuario(
            0, username, PasswordHasher.Hash(defaultPassword),
            "Paciente", $"{dto.Nombre} {dto.Apellido}",
            dto.Mail ?? $"{username}@turnomolar.com",
            dto.EstadoHabilitado, paciente.Id
        );
        await _usuarioRepository.AddAsync(usuario);
        await transaction.CommitAsync();
      }
      catch
      {
        await transaction.RollbackAsync();
        throw;
      }
      var resultDto = MapToDTO(paciente);
      resultDto.Username = createdUsername;
      resultDto.PasswordDefault = defaultPassword;
      return resultDto;
    }


        public async Task<bool> UpdateAsync(PacienteDTO dto)
        {
            if (await _pacienteRepository.DniExistsAsync(dto.Dni, dto.Id))
            {
                throw new InvalidOperationException($"Ya existe otro paciente registrado con el DNI {dto.Dni}.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Mail) && await _pacienteRepository.EmailExistsAsync(dto.Mail, dto.Id))
            {
                throw new InvalidOperationException($"Ya existe otro paciente registrado con el email {dto.Mail}.");
            }

            var paciente = new Paciente(
                dto.Id,
                dto.Nombre,
                dto.Apellido,
                dto.Dni,
                dto.Telefono,
                dto.Mail,
                dto.Domicilio,
                dto.EstadoHabilitado,
                dto.ObraSocialId,
                dto.NumeroAfiliado
            );

            var updated = await _pacienteRepository.UpdateAsync(paciente);

           
            try
            {
                var usuario = await _usuarioRepository.GetByEntidadIdAsync(dto.Id, "Paciente");
                if (usuario != null)
                {
                    usuario.SetNombreCompleto($"{dto.Nombre} {dto.Apellido}");
                    usuario.SetEmail(dto.Mail ?? usuario.Email);
                    usuario.SetActivo(dto.EstadoHabilitado);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch { }

            return updated;
        }

    public async Task<bool> DeleteAsync(int id)
    {
      
      var tieneTurnos = await _pacienteRepository.TieneRegistrosAsociadosAsync(id);
      if (tieneTurnos)
        throw new InvalidOperationException("No se puede eliminar el paciente porque tiene turnos, consultas o facturas registradas.");
              
      using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
        if (usuario != null)
          await _usuarioRepository.DeleteAsync(usuario.Id);
        await _pacienteRepository.DeleteAsync(id);
        await transaction.CommitAsync();
        return true;
      }
      catch
      {
        await transaction.RollbackAsync();
        throw;
      }
    }

    public async Task<bool> ToggleHabilitacionAsync(int id, bool habilitar)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return false;

            paciente.SetEstadoHabilitado(habilitar);
            var ok = await _pacienteRepository.UpdateAsync(paciente);

            try
            {
                var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
                if (usuario != null)
                {
                    usuario.SetActivo(habilitar);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch { }

            return ok;
        }

        private static PacienteDTO MapToDTO(Paciente p)
        {
            return new PacienteDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                Telefono = p.Telefono,
                Mail = p.Mail,
                Domicilio = p.Domicilio,
                EstadoHabilitado = p.EstadoHabilitado,
                ObraSocialId = p.ObraSocialId,
                ObraSocialNombre = p.ObraSocial != null ? $"{p.ObraSocial.Nombre} ({p.ObraSocial.Plan})" : "Particular",
                NumeroAfiliado = p.NumeroAfiliado
            };
        }
    }
}
