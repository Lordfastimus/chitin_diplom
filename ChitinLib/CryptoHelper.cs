using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ChitinLib
{
    public static class CryptoHelper
    {
        public static string GetHashMD5(byte[] body)
        {
            var md5 = MD5.Create();
            return ConvertByteTo64String(md5.ComputeHash(body));
        }

        private static string ConvertByteTo64String(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }

        public static ICollection<IFileAnalyzeInfo> CalculateMD5ForFiles(ICollection<IFileAnalyzeInfo> files)
        {
            Parallel.ForEach(files, new Action<IFileAnalyzeInfo>(file =>
            {
                var fileInfo = new FileInfo(file.FullName);
                file.Size = fileInfo.Length;
                var fileBody = File.ReadAllBytes(fileInfo.FullName);
                file.MD5 = GetHashMD5(fileBody);
            }));

            return files;
        }
    }
}
