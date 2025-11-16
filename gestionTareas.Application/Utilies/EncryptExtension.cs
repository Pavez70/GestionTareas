using gestionTareas.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Utilies
{
    public class EncryptExtension : IEncryptExtension
    {
        private readonly IConfiguration _configuration;

        public EncryptExtension(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Encrypt(string _cadenaAencriptar)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration["Aes:Key"].Substring(0, 32));

            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = Encoding.UTF8.GetBytes(_configuration["Aes:IV"].Substring(0, 16));

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(_cadenaAencriptar);
                        }
                    }
                    byte[] bytes = msEncrypt.ToArray();
                    return ByteArrayToHexString(bytes);
                }
            }
        }

        public string Decrypt(string _cadenaADesencriptar)
        {
            byte[] inputBytes = HexStringToByteArray(_cadenaADesencriptar);
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration["Aes:Key"].Substring(0, 32));
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = Encoding.UTF8.GetBytes(_configuration["Aes:IV"].Substring(0, 16));

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream(inputBytes))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srEncrypt = new StreamReader(csEncrypt))
                        {
                            return srEncrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");

            byte[] buffer = new byte[s.Length / 2];

            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);

            return buffer;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString();
        }
    }
}
