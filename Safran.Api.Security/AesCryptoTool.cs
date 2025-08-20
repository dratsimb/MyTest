using System.Security.Cryptography;
using System.Text;

namespace Safran.Api.Security
{
    public class AesCryptoTool:ICryptoTool
    {
        const int KeySize = 256;
        const int IVLength = 16;

        private byte[] _aesKey;

        /// <summary>
        /// Initializes a new instance of the class
        /// </summary>
        /// <param name="salt">the salt value</param>
        public AesCryptoTool(string key) 
        {
            _aesKey = new byte[32]; 
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32)), _aesKey, 32);
        }

        public byte[] Cypher(string value)
        {
            using var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.Key = _aesKey;
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, IVLength);

                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using var sw = new StreamWriter(cs);
                    sw.Write(value);
                }
                return ms.ToArray();
            }
        }

        public string Decypher(byte[] value)
        {
            using var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.Key = _aesKey;

            // Extrait le IV (16 premiers octets)
            byte[] iv = new byte[IVLength];
            Array.Copy(value, 0, iv, 0, IVLength);
            aes.IV = iv;

            var result = "";
            // Le reste est le texte chiffré
            using (var ms = new MemoryStream(value, IVLength, value.Length - IVLength))
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
            using (var sr = new StreamReader(cs))

                result = sr.ReadToEnd();

            return result;
        }

    }
}
