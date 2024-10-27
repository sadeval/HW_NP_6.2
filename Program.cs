using System;
using MailKit.Net.Pop3;
using MailKit;
using MimeKit;

namespace POP3MailReceiver
{
    class Program
    {
        static void Main()
        {
            string pop3Server = "pop.gmail.com";
            int pop3Port = 995; 
            string pop3User = "sadeval2011@gmail.com"; 
            string pop3Pass = "qhcg nazh mesm bapv"; 

            try
            {
                using (var client = new Pop3Client())
                {
                    client.Connect(pop3Server, pop3Port, true); 

                    client.Authenticate(pop3User, pop3Pass);

                    int messageCount = client.Count;
                    Console.WriteLine($"Total messages: {messageCount}");

                    for (int i = 0; i < messageCount; i++)
                    {
                        MimeMessage message = client.GetMessage(i);
                        Console.WriteLine($"Subject: {message.Subject}");
                        Console.WriteLine($"From: {message.From}");
                        Console.WriteLine($"Body: {message.TextBody}\n");
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
