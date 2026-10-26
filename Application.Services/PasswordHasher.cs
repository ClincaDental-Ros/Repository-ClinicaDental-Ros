using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{

    /// Hash de contraseñas con HMACSHA256 y salt aleatorio.
    /// Formato almacenado: "salt_base64:hash_base64".

    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            using var hmac = new HMACSHA256(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        public static bool Verify(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            try
            {
                var salt = Convert.FromBase64String(parts[0]);
                var expectedHash = Convert.FromBase64String(parts[1]);

                using var hmac = new HMACSHA256(salt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return CryptographicOperations.FixedTimeEquals(computedHash, expectedHash);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
