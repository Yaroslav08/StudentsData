using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("1312053961:AAHSoJatxCGgjFXOL-7DfWcNRDqq5HF6T4M");
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"Hello, i am bot {me.Id} and my name is {me.FirstName}");
            botClient.OnMessage += async (sender, e) =>
                 {
                     if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                     {
                         if (e.Message.Text.StartsWith("/student@"))
                         {
                             var users = UserManager.GetUsersByName(e.Message.Text.Split('@')[1]);
                             if (users == null || users.Count == 0)
                                 await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Жодного студента не знайдено");
                             string response = "Студентів знайдено:\n";
                             foreach (var user in users)
                             {
                                 response += $"Id: {user.Id} Ім'я: {user.Name}\n";
                             }
                             await botClient.SendTextMessageAsync(e.Message.Chat.Id, response);
                             return;
                         }
                         if (e.Message.Text.StartsWith("/student."))
                         {
                             int id = default;
                             int.TryParse(e.Message.Text.Split('.')[1], out id);
                             if (id == default)
                                 await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Номер не валідний");
                             var user = UserManager.GetUserById(id);
                             if (user == null)
                                 await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Студента не знайдено");
                             await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"Студента знайдено:\nId: {user.Id}\nІм'я: {user.Name}");
                             return;
                         }
                         switch (e.Message.Text)
                         {
                             case "/start":
                                 {
                                     await botClient.SendTextMessageAsync(e.Message.Chat, $"Наразі я підтримую лише чотири команди: /hello, /rnd, /student@ та /student."); break;
                                 }
                             case "/hello":
                                 {
                                     await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"Вітаю, {e.Message.From.FirstName}"); break;
                                 }
                             case "/rnd":
                                 {
                                     await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"{new Random().Next(0, 100)}"); break;
                                 }
                             default:
                                 break;
                         }
                     }
                 };
            botClient.StartReceiving();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            botClient.StopReceiving();
        }
    }

    public class TestUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class UserManager
    {
        private static List<TestUser> users = new List<TestUser>
            {
                new TestUser
                {
                    Id = 1,
                    Name = "Yaroslav Mudryk"
                },
                new TestUser
                {
                    Id = 2,
                    Name = "MishaBrekhov"
                },
                new TestUser
                {
                    Id = 3,
                    Name = "Mukuta Medko"
                },
                new TestUser
                {
                    Id = 4,
                    Name = "Oleksii Kuzh"
                },
                new TestUser
                {
                    Id = 5,
                    Name = "Olexandr Kuzh"
                },
            };

        public static TestUser GetUserById(int id)
        {
            return users.FirstOrDefault(d => d.Id == id);
        }

        public static List<TestUser> GetUsersByName(string name)
        {
            return users.Where(d => d.Name.Contains(name)).ToList();
        }
    }
}