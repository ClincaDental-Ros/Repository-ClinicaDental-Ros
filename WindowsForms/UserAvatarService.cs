using System.Drawing.Imaging;

namespace WindowsForms
{
    public static class UserAvatarService
    {
        private static string GetAvatarDirectory()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ClinicaDental", "Avatars");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GetAvatarPath(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                username = "usuario_default";

            var clean = string.Concat(username.Split(Path.GetInvalidFileNameChars())).ToLowerInvariant().Trim();
            return Path.Combine(GetAvatarDirectory(), $"{clean}.png");
        }

        public static Image? LoadAvatar(string username)
        {
            try
            {
                var path = GetAvatarPath(username);
                if (File.Exists(path))
                {
                    byte[] bytes = File.ReadAllBytes(path);
                    using var ms = new MemoryStream(bytes);
                    using var original = new Bitmap(ms);
                    // Copia independiente del stream: GDI+ necesita que el stream siga abierto mientras viva el Bitmap
                    return new Bitmap(original);
                }
            }
            catch (Exception ex) when (ex is IOException or ArgumentException or UnauthorizedAccessException)
            {
                // Archivo dañado o inaccesible: se muestran las iniciales en lugar de la foto
            }
            return null;
        }

        // Save y Delete propagan los errores para que la pantalla de perfil los informe
        public static void SaveAvatar(string username, Image image)
        {
            var path = GetAvatarPath(username);
            using var bmp = new Bitmap(image);
            bmp.Save(path, ImageFormat.Png);
        }

        public static void DeleteAvatar(string username)
        {
            var path = GetAvatarPath(username);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
