using Data;
using Domain.Model;
using DTOs;

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

        public PacienteService(IPacienteRepository pacienteRepository, IUsuarioRepository usuarioRepository)
        {
            _pacienteRepository = pacienteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<PacienteDTO?> GetAsync(int id)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return null;

            var dto = MapToDTO(paciente);
            var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
            if (usuario != null)
            {
                dto.Username = usuario.Username;
                dto.PasswordDefault = usuario.PasswordHash;
            }
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
                    {
                        dto.Username = u.Username;
                        dto.PasswordDefault = u.PasswordHash;
                    }
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
                    {
                        dto.Username = u.Username;
                        dto.PasswordDefault = u.PasswordHash;
                    }
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

            try
            {
                string baseUsername = !string.IsNullOrWhiteSpace(dto.Mail) && dto.Mail.Contains("@")
                    ? dto.Mail.Split('@')[0].ToLower()
                    : $"{dto.Nombre.ToLower().Replace(" ", "")}{dto.Dni}";

                string username = baseUsername;
                int counter = 1;
                while (await _usuarioRepository.GetByUsernameAsync(username) != null)
                {
                    username = $"{baseUsername}{counter++}";
                }

                createdUsername = username;

                var usuario = new Usuario(
                    0,
                    username,
                    defaultPassword, 
                    "Paciente",
                    $"{dto.Nombre} {dto.Apellido}",
                    dto.Mail ?? $"{username}@turnomolar.com",
                    dto.EstadoHabilitado,
                    paciente.Id
                );

                await _usuarioRepository.AddAsync(usuario);
            }
            catch
            {
                
            }

            var resultDto = MapToDTO(paciente);
            resultDto.Username = string.IsNullOrEmpty(createdUsername) ? dto.Username : createdUsername;
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
                    usuario.NombreCompleto = $"{dto.Nombre} {dto.Apellido}";
                    usuario.Email = dto.Mail ?? usuario.Email;
                    usuario.Activo = dto.EstadoHabilitado;
                    await _usuarioRepository.UpdateAsync(usuario);
                }
            }
            catch { }

            return updated;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
                if (usuario != null)
                {
                    await _usuarioRepository.DeleteAsync(usuario.Id);
                }
            }
            catch { }

            return await _pacienteRepository.DeleteAsync(id);
        }

        public async Task<bool> ToggleHabilitacionAsync(int id, bool habilitar)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return false;

            paciente.EstadoHabilitado = habilitar;
            var ok = await _pacienteRepository.UpdateAsync(paciente);

            try
            {
                var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
                if (usuario != null)
                {
                    usuario.Activo = habilitar;
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
