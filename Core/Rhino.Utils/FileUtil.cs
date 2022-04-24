using System.IO;

namespace Rhino.Utils
{
    public static class FileUtil
    {
        private const string _imageExtensions = ".jpg;.png;.jpeg;.gif;.bmp;";

        public static bool IsImage(this string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return false; }

            return _imageExtensions.Contains(Path.GetExtension(fileName));
        }
    }
}