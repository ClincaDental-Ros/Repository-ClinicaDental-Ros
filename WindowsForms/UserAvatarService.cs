using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
                    return new Bitmap(ms);
                }
            }
            catch
            {
            }
            return null;
        }

        public static void SaveAvatar(string username, Image image)
        {
            try
            {
                var path = GetAvatarPath(username);
                using var bmp = new Bitmap(image);
                bmp.Save(path, ImageFormat.Png);
            }
            catch
            {
            }
        }

        public static void DeleteAvatar(string username)
        {
            try
            {
                var path = GetAvatarPath(username);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch
            {
            }
        }
    }
}
