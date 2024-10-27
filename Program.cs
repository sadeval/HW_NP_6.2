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
            // Настройки для подключения к POP3 серверу
            string pop3Server = "pop.gmail.com"; // Адрес POP3 сервера
            int pop3Port = 995; // Порт для POP3 с SSL
            string pop3User = "sadeval2011@gmail.com"; // Ваш почтовый адрес
            string pop3Pass = "qhcg nazh mesm bapv"; // Пароль приложения (или основной пароль)

            try
            {
                using (var client = new Pop3Client())
                {
                    // Подключаемся к серверу POP3
                    client.Connect(pop3Server, pop3Port, true); // true для SSL

                    // Аутентификация на сервере
                    client.Authenticate(pop3User, pop3Pass);

                    // Получаем количество сообщений
                    int messageCount = client.Count;
                    Console.WriteLine($"Total messages: {messageCount}");

                    // Получаем все сообщения
                    for (int i = 0; i < messageCount; i++)
                    {
                        MimeMessage message = client.GetMessage(i);
                        Console.WriteLine($"Subject: {message.Subject}");
                        Console.WriteLine($"From: {message.From}");
                        Console.WriteLine($"Body: {message.TextBody}\n");
                    }

                    // Отключаемся от сервера
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
