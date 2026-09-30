using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Data;
using Domain.Model;
using DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request);
        Task<UsuarioDTO?> GetUsuarioActualAsync(int userId);
        Task<UsuarioDTO> RegistrarUsuarioAsync(UsuarioDTO dto, string password);
        Task<bool> CambiarPasswordAsync(int userId, string passwordActual, string passwordNueva);
        Task<LoginResponseDTO?> RefreshTokenAsync(string token);
    }

    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        private string SecretKey => _configuration["JwtSettings:SecretKey"]
            ?? "TurnoMolarSuperSecretSecurityKeyForJWTAuthentication2026";
        private string Issuer => _configuration["JwtSettings:Issuer"] ?? "TurnoMolarAPI";
        private string Audience => _configuration["JwtSettings:Audience"] ?? "TurnoMolarClients";
        private int ExpirationMinutes => int.TryParse(_configuration["JwtSettings:ExpirationMinutes"], out var min) ? min : 120;

        public async Task<LoginResponseDTO?> LoginAsync(LoginRequestDTO request)
        {
            var user = await _usuarioRepository.GetByUsernameAsync(request.Username);
            if (user == null || !user.Activo)
                return null;

            // Soporta tanto passwords hasheados como texto plano (compatibilidad con seed data)
            if (!VerifyPassword(request.Password, user.PasswordHash))
            {
                return null;
            }

            // Si la password está en texto plano, migrarla a hash
            if (!user.PasswordHash.Contains(':'))
            {
                user.PasswordHash = HashPassword(request.Password);
                await _usuarioRepository.UpdateAsync(user);
            }

            return GenerateTokenResponse(user);
        }

        public async Task<LoginResponseDTO?> RefreshTokenAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SecretKey);

                // Validar el token (permitir expirado para refresh)
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = false // Permitir token expirado
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // Verificar que no haya expirado hace más de 24 horas
                if (jwtToken.ValidTo < DateTime.UtcNow.AddHours(-24))
                    return null;

                var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                    return null;

                var user = await _usuarioRepository.GetByIdAsync(userId);
                if (user == null || !user.Activo)
                    return null;

                return GenerateTokenResponse(user);
            }
            catch
            {
                return null;
            }
        }

        public async Task<UsuarioDTO?> GetUsuarioActualAsync(int userId)
        {
            var user = await _usuarioRepository.GetByIdAsync(userId);
            if (user == null) return null;

            return new UsuarioDTO
            {
                Id = user.Id,
                Username = user.Username,
                Rol = user.Rol,
                NombreCompleto = user.NombreCompleto,
                Email = user.Email,
                Activo = user.Activo,
                EntidadId = user.EntidadId
            };
        }

        public async Task<UsuarioDTO> RegistrarUsuarioAsync(UsuarioDTO dto, string password)
        {
            var user = new Usuario(
                0,
                dto.Username,
                HashPassword(password),
                dto.Rol,
                dto.NombreCompleto,
                dto.Email,
                true,
                dto.EntidadId
            );

            await _usuarioRepository.AddAsync(user);
            dto.Id = user.Id;
            return dto;
        }

        public async Task<bool> CambiarPasswordAsync(int userId, string passwordActual, string passwordNueva)
        {
            var user = await _usuarioRepository.GetByIdAsync(userId);
            if (user == null || !user.Activo)
                return false;

            if (!VerifyPassword(passwordActual, user.PasswordHash))
                return false;

            user.PasswordHash = HashPassword(passwordNueva);
            return await _usuarioRepository.UpdateAsync(user);
        }

        private LoginResponseDTO GenerateTokenResponse(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Rol),
                    new Claim("NombreCompleto", user.NombreCompleto),
                    new Claim("Email", user.Email),
                    new Claim("EntidadId", user.EntidadId?.ToString() ?? "")
                }),
                Expires = expiration,
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new LoginResponseDTO
            {
                Token = tokenString,
                Username = user.Username,
                Rol = user.Rol,
                NombreCompleto = user.NombreCompleto,
                UserId = user.Id,
                EntidadId = user.EntidadId,
                Expiration = expiration
            };
        }

        /// <summary>
        /// Genera un hash de la contraseña usando HMACSHA256 con salt aleatorio.
        /// Formato almacenado: "salt_base64:hash_base64"
        /// </summary>
        private static string HashPassword(string password)
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var hmac = new HMACSHA256(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Verifica la contraseña contra el hash almacenado.
        /// Soporta tanto hashes (formato salt:hash) como texto plano para compatibilidad.
        /// </summary>
        private static bool VerifyPassword(string password, string storedHash)
        {
            // Si no contiene ':', es texto plano (compatibilidad con datos semilla)
            if (!storedHash.Contains(':'))
            {
                return storedHash == password;
            }

            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            var salt = Convert.FromBase64String(parts[0]);
            var expectedHash = Convert.FromBase64String(parts[1]);

            using var hmac = new HMACSHA256(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return CryptographicOperations.FixedTimeEquals(computedHash, expectedHash);
        }
    }
}
