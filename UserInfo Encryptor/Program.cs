using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UserInfoEncryptionTool
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Specify the path to the XML file
                string filePath = "UserInfo.txt";

                // Read XML data from file
                string xmlData = File.ReadAllText(filePath);

                // Encrypt and save to file
                byte[] encryptedBytes = Encrypt(Encoding.UTF8.GetBytes(xmlData));
                File.WriteAllBytes("userinfo.dat", encryptedBytes);

                Console.WriteLine("Encrypted data has been written to userinfo.dat");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static byte[] Encrypt(byte[] unencryptedBytes)
        {
            return ProtectedData.Protect(unencryptedBytes, null, DataProtectionScope.CurrentUser);
        }
    }
}
