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
        private const string PasswordInicialPaciente = "paciente123";

        private readonly IPacienteRepository _pacienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IObraSocialRepository _obraSocialRepository;
        private readonly ITransactionManager _transactionManager;

        public PacienteService(
            IPacienteRepository pacienteRepository,
            IUsuarioRepository usuarioRepository,
            IObraSocialRepository obraSocialRepository,
            ITransactionManager transactionManager)
        {
            _pacienteRepository = pacienteRepository;
            _usuarioRepository = usuarioRepository;
            _obraSocialRepository = obraSocialRepository;
            _transactionManager = transactionManager;
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
            return await ConUsuariosAsync(pacientes);
        }

        public async Task<IEnumerable<PacienteDTO>> GetByCriteriaAsync(PacienteCriteriaDTO criteriaDTO)
        {
            var criteria = new PacienteCriteria(criteriaDTO.Texto, criteriaDTO.SoloHabilitados);
            var pacientes = await _pacienteRepository.GetByCriteriaAsync(criteria);
            return await ConUsuariosAsync(pacientes);
        }

        /// <summary>Agrega a cada paciente el usuario de su portal, si tiene.</summary>
        private async Task<List<PacienteDTO>> ConUsuariosAsync(IEnumerable<Paciente> pacientes)
        {
            var dtos = pacientes.Select(MapToDTO).ToList();
            var usuariosPorPaciente = (await _usuarioRepository.GetAllAsync())
                .Where(u => string.Equals(u.Rol, "Paciente", StringComparison.OrdinalIgnoreCase) && u.EntidadId.HasValue)
                .ToLookup(u => u.EntidadId!.Value);

            foreach (var dto in dtos)
                dto.Username = usuariosPorPaciente[dto.Id].FirstOrDefault()?.Username;

            return dtos;
        }

        private async Task ValidarObraSocialAsync(int? obraSocialId)
        {
            if (obraSocialId.HasValue && await _obraSocialRepository.GetAsync(obraSocialId.Value) == null)
                throw new ArgumentException($"La obra social #{obraSocialId} no existe.");
        }

        public async Task<PacienteDTO> AddAsync(PacienteDTO dto)
        {
            if (await _pacienteRepository.DniExistsAsync(dto.Dni))
                throw new InvalidOperationException($"Ya existe un paciente registrado con el DNI {dto.Dni}.");

            if (!string.IsNullOrWhiteSpace(dto.Mail) && await _pacienteRepository.EmailExistsAsync(dto.Mail))
                throw new InvalidOperationException($"Ya existe un paciente registrado con el email {dto.Mail}.");

            await ValidarObraSocialAsync(dto.ObraSocialId);

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

            // El paciente y su usuario del portal se crean juntos: si falla uno, no queda ninguno.
            var username = await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                await _pacienteRepository.AddAsync(paciente);

                var baseUsername = !string.IsNullOrWhiteSpace(dto.Mail) && dto.Mail.Contains('@')
                    ? dto.Mail.Split('@')[0].ToLower()
                    : $"{dto.Nombre.ToLower().Replace(" ", "")}{dto.Dni}";

                var candidato = baseUsername;
                var contador = 1;
                while (await _usuarioRepository.GetByUsernameAsync(candidato) != null)
                    candidato = $"{baseUsername}{contador++}";

                var usuario = new Usuario(
                    0,
                    candidato,
                    PasswordHasher.Hash(PasswordInicialPaciente),
                    "Paciente",
                    $"{dto.Nombre} {dto.Apellido}",
                    string.IsNullOrWhiteSpace(dto.Mail) ? $"{candidato}@turnomolar.com" : dto.Mail,
                    dto.EstadoHabilitado,
                    paciente.Id
                );

                await _usuarioRepository.AddAsync(usuario);
                return candidato;
            });

            var resultDto = MapToDTO(paciente);
            resultDto.Username = username;
            resultDto.PasswordDefault = PasswordInicialPaciente;
            return resultDto;
        }

        public async Task<bool> UpdateAsync(PacienteDTO dto)
        {
            if (await _pacienteRepository.DniExistsAsync(dto.Dni, dto.Id))
                throw new InvalidOperationException($"Ya existe otro paciente registrado con el DNI {dto.Dni}.");

            if (!string.IsNullOrWhiteSpace(dto.Mail) && await _pacienteRepository.EmailExistsAsync(dto.Mail, dto.Id))
                throw new InvalidOperationException($"Ya existe otro paciente registrado con el email {dto.Mail}.");

            await ValidarObraSocialAsync(dto.ObraSocialId);

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

            // La ficha y el usuario del portal (nombre, mail y si está activo) se actualizan juntos.
            return await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                var updated = await _pacienteRepository.UpdateAsync(paciente);
                if (!updated) return false;

                var usuario = await _usuarioRepository.GetByEntidadIdAsync(dto.Id, "Paciente");
                if (usuario != null)
                {
                    usuario.SetNombreCompleto($"{dto.Nombre} {dto.Apellido}");
                    if (!string.IsNullOrWhiteSpace(dto.Mail)) usuario.SetEmail(dto.Mail);
                    usuario.SetActivo(dto.EstadoHabilitado);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
                return true;
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (await _pacienteRepository.GetAsync(id) == null) return false;

            // Se valida antes de borrar: un paciente con turnos, historia clínica, multas o facturas
            // no se elimina (se deshabilita). Así no queda un paciente sin usuario ni datos huérfanos.
            var relaciones = await _pacienteRepository.GetRelacionesAsync(id);
            if (relaciones.Count > 0)
            {
                throw new InvalidOperationException(
                    $"No se puede eliminar el paciente porque tiene {string.Join(", ", relaciones)}. " +
                    "Si ya no se atiende en la clínica, deshabilitalo.");
            }

            return await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
                if (usuario != null)
                    await _usuarioRepository.DeleteAsync(usuario.Id);

                return await _pacienteRepository.DeleteAsync(id);
            });
        }

        public async Task<bool> ToggleHabilitacionAsync(int id, bool habilitar)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return false;

            return await _transactionManager.EjecutarEnTransaccionAsync(async () =>
            {
                paciente.SetEstadoHabilitado(habilitar);
                var ok = await _pacienteRepository.UpdateAsync(paciente);

                var usuario = await _usuarioRepository.GetByEntidadIdAsync(id, "Paciente");
                if (usuario != null)
                {
                    usuario.SetActivo(habilitar);
                    await _usuarioRepository.UpdateAsync(usuario);
                }
                return ok;
            });
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
