using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

//http://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
namespace TeachMeArabic.Utilities
{
    public static class Encrypt
    {
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string InitVector = "Ikr@B!$m!R@bb!k@";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int Keysize = 256;
        private const string Salt = "N00nW@lK@l@m!";
        private const string Secret = "L@!1@h@!11@A11@h0u";
        //Encrypt
        public static string EncryptString(string plainText)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var saltBytes = Encoding.UTF8.GetBytes(Salt);
            var password = new Rfc2898DeriveBytes(Secret, saltBytes);
            var keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString(string cipherText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var saltBytes = Encoding.UTF8.GetBytes(Salt);
            var password = new Rfc2898DeriveBytes(Secret, saltBytes);
            var keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}