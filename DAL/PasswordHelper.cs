using System.Security.Cryptography;
using System.Text;

namespace SmartMedPharmacy.DAL
{
    
    public static class PasswordHelper
    {
        public static string Hash(string plainTextPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool Verify(string plainTextPassword, string storedHash)
        {
            string hashOfInput = Hash(plainTextPassword);
            return hashOfInput == storedHash;
        }
    }
}
