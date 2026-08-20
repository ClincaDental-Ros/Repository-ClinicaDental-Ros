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

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<PacienteDTO?> GetAsync(int id)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            return paciente == null ? null : MapToDTO(paciente);
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return pacientes.Select(MapToDTO).ToList();
        }

        public async Task<IEnumerable<PacienteDTO>> GetByCriteriaAsync(PacienteCriteriaDTO criteriaDTO)
        {
            var criteria = new PacienteCriteria(criteriaDTO.Texto, criteriaDTO.SoloHabilitados);
            var pacientes = await _pacienteRepository.GetByCriteriaAsync(criteria);
            return pacientes.Select(MapToDTO).ToList();
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
            return MapToDTO(paciente);
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

            return await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _pacienteRepository.DeleteAsync(id);
        }

        public async Task<bool> ToggleHabilitacionAsync(int id, bool habilitar)
        {
            var paciente = await _pacienteRepository.GetAsync(id);
            if (paciente == null) return false;

            paciente.EstadoHabilitado = habilitar;
            return await _pacienteRepository.UpdateAsync(paciente);
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