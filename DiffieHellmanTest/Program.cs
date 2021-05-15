using System;
using System.Text;

namespace DiffieHellmanTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var sendecdh = new SendEcDiffieHelman();
            var receiveecdh = new ReceiveEcDiffieHelman();
            var message = "this is som random text.....";
            
            sendecdh.SetReceiverPublicKey(receiveecdh.ReceiverPublicKey);
            var encryptedMessag = sendecdh.Send(message);
            Console.WriteLine(encryptedMessag);
            
            
            receiveecdh.SetSenderPublicKey(sendecdh.SenderPublicKey);
            Console.WriteLine(receiveecdh.Receive(Convert.FromBase64String(encryptedMessag)));

            Console.ReadLine();

        }
    }
}