using System.Text;

namespace Sacristan.Utils
{
    public static class HashingUtils
    {
        public static string MD5Sum(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(str);
            var sha = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return System.BitConverter.ToString(sha.ComputeHash(bytes));
        }

        public static string Sha1Sum(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(str);
            var sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return System.BitConverter.ToString(sha.ComputeHash(bytes));
        }

        public static string Sha256Sum(string str)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] cryptedBytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));

            for(int i = 0; i < cryptedBytes.Length; i++)
            {
                byte cryptedByte = cryptedBytes[i];
                hash.Append(cryptedByte.ToString("x2"));
            }

            return hash.ToString().ToLower();
        }

    }

}