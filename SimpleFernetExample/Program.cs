using System;
using System.IO;
using Fernet;

namespace SimpleFernetExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedFilePath = "C:\\Users\\claud\\Desktop\\SimpleFernetExample\\SimpleFernetExample\\CryptedFile\\ags_1";
            string decryptedFilePath = "C:\\Users\\claud\\Desktop\\Decrypt\\";
            string key = "9P7A4PfoWql4EuwYukX89kVVSmSEMHRVRE7gEY9H6MI=";

            try
            {
                string encryptedData = File.ReadAllText(encryptedFilePath);
                byte[] keyBytes = Convert.FromBase64String(key);

                var decoded64 = SimpleFernet.Decrypt(keyBytes, encryptedData, out var timestamp);
                var decoded = decoded64.UrlSafe64Encode().FromBase64String();

                string decryptedText = decoded.ToString(); // Obter o conteúdo como uma string

                string outputFilePath = Path.Combine(decryptedFilePath, "decrypted_output.txt");

                File.WriteAllText(outputFilePath, decryptedText); // Criar um arquivo com o conteúdo descriptografado

                Console.WriteLine("Conteúdo descriptografado salvo no arquivo: " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }

            Console.WriteLine("Processo concluído.");
        }
    }
}
