using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

namespace ChitinLib
{
    public static class CryptoHelper
    {
        public static string GetHashMD5(byte[] body)
        {
            var md5 = MD5.Create();
            return ConvertByteTo64String(md5.ComputeHash(body));
        }

        public static string GetHashMD5ForHashes(IEnumerable<string> hashes)
        {
            var md5 = MD5.Create();
            return ConvertByteTo64String(md5.ComputeHash(Encoding.UTF8.GetBytes(string.Join(null, hashes.ToArray()))));
        }

        private static string ConvertByteTo64String(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }
    }
}
