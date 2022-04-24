using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rhino.Utils
{
    public static class MD5Util
    {
        public static string GetMD5FromStream(Stream inputStream)
        {
            if (inputStream == null) { return ""; }

            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = md5.ComputeHash(inputStream);
                inputStream.Close();

                return Format(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetMD5FromFile(this string fileName)
        {
            return GetMD5FromStream(new FileStream(fileName, FileMode.Open));
        }

        private static string Format(byte[] data)
        {
            if (data == null) { return ""; }

            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.Append(item.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}