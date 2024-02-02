using System;
using System.IO;
using System.Security.Cryptography;

namespace YourNamespace
{
    // Your Security class
    public class Security
    {
        public static byte[] Encrypt(byte[] unencryptedBytes)
        {
            return ProtectedData.Protect(unencryptedBytes, null, DataProtectionScope.CurrentUser);
        }

        public static byte[] Decrypt(byte[] encryptedBytes)
        {
            return ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
        }

        // Method to load encrypted data from file
        public static byte[] LoadEncryptedData(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Load encrypted data from file
            byte[] loadedEncryptedData = Security.LoadEncryptedData("userinfo.dat");

            if (loadedEncryptedData != null)
            {
                // Decrypt loaded data
                byte[] decryptedData = Security.Decrypt(loadedEncryptedData);

                if (decryptedData != null)
                {
                    // Display the decrypted data
                    string decryptedString = System.Text.Encoding.UTF8.GetString(decryptedData);
                    Console.WriteLine("Decrypted Data: " + decryptedString);
                }
            }

            Console.ReadLine();
        }
    }
}
