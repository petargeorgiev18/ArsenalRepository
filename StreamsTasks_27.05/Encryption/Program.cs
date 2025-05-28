using System.Security.Cryptography;

namespace Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] key;
            byte[] iv;
            using (FileStream readStream = new FileStream("../../../textFile.txt", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../encryptedTextFile.enc", FileMode.Create))
                {
                    using (Aes aes = Aes.Create())
                    {
                        key = aes.Key;
                        iv = aes.IV;
                        ICryptoTransform encryptor = aes.CreateEncryptor();
                        using (CryptoStream cryptoStream = new CryptoStream(writeStream, encryptor, CryptoStreamMode.Write))
                        {
                            readStream.CopyTo(cryptoStream);
                        }
                    }
                }
            }
            using (FileStream decryptedStream = new FileStream("../../../decryptedTextFile.txt", FileMode.Create, FileAccess.Write))
            {
                using (FileStream encryptedStream = new FileStream("../../../encryptedTextFile.enc", FileMode.Open, FileAccess.Read))
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = key;
                        aes.IV = iv;
                        ICryptoTransform decryptor = aes.CreateDecryptor();
                        using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(decryptedStream);
                        }
                    }
                }
            }
        }
    }
}
