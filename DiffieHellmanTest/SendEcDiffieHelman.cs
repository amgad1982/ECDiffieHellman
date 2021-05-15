using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DiffieHellmanTest
{
    
    public class SendEcDiffieHelman
    {
        public SendEcDiffieHelman()
        {
            ecDiffieHellman = new ECDiffieHellmanOpenSsl();
            SenderPublicKey = ecDiffieHellman.PublicKey;
        }

        public void SetReceiverPublicKey(ECDiffieHellmanPublicKey receiverPublicKey)
        {
            SenderPrivateKey = ecDiffieHellman.DeriveKeyMaterial(receiverPublicKey);
            ecDiffieHellman.Dispose();
        }
        private readonly ECDiffieHellmanOpenSsl ecDiffieHellman ;
        public ECDiffieHellmanPublicKey SenderPublicKey { get; set; }
        private  byte[] SenderPrivateKey;
   
        public string Send(string message)
        {
            byte[] iv = null;

            var ecryptedmessage = CryptoUtilities.Encrypt(SenderPrivateKey, message, out iv);
            
            return Convert.ToBase64String(ecryptedmessage.Concat(iv).ToArray());
        }

       
    }
}