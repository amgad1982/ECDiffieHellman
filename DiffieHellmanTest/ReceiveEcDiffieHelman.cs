using System;
using System.Security.Cryptography;

namespace DiffieHellmanTest
{
    public class ReceiveEcDiffieHelman
    {
        public ReceiveEcDiffieHelman()
        {
            ecDiffieHellman = new ECDiffieHellmanOpenSsl();
            ReceiverPublicKey = ecDiffieHellman.PublicKey;
        }

        public void SetSenderPublicKey(ECDiffieHellmanPublicKey senderPublicKey)
        {
            ReceiverPrivateKey=ecDiffieHellman.DeriveKeyMaterial(senderPublicKey);
            ecDiffieHellman.Dispose();
        }

        private readonly ECDiffieHellmanOpenSsl ecDiffieHellman;
        public ECDiffieHellmanPublicKey ReceiverPublicKey { get; private set; }
        
        private byte[] ReceiverPrivateKey;

        public string Receive(byte[] encryptedMessage)
        {
            byte[] iv = new byte[16];
            Array.Copy(encryptedMessage,encryptedMessage.Length-16 ,iv, 0, 16);

            byte[] message = new byte[encryptedMessage.Length - 16];
            Array.Copy(encryptedMessage,0,message,0,encryptedMessage.Length-16);
            return CryptoUtilities.Decrypt(ReceiverPrivateKey, message, iv);
            
        }

       
    }
}