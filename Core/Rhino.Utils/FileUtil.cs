using System.IO;

namespace Rhino.Utils
{
    public static class FileUtil
    {
        public static bool IsImage(this string file)
        {
            if (string.IsNullOrEmpty(file)) { return false; }

            var extension = Path.GetExtension(file);
            if (string.IsNullOrEmpty(extension)) { return false; }

            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    return true;
            }

            return false;
        }
    }
}