using System;
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
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            botClient.OnMessage += async (sender, e) =>
                 {
                     if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                     {
                         switch (e.Message.Text)
                         {
                             case "/start":
                                 {
                                     await botClient.SendTextMessageAsync(e.Message.Chat, $"Наразі я підтримую лише дві команди: /hello та /rnd"); break;
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

        //static async void Bot_OnMessage(object sender, MessageEventArgs e)
        //{
        //    if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
        //    {
        //        switch (e.Message.Text)
        //        {
        //            case "/start":
        //                {
        //                    await botClient.SendTextMessageAsync(e.Message.Chat, $"Наразі я підтримую лише дві команди: /hello та /rnd"); break;
        //                }
        //            case "/hello":
        //                {
        //                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"Вітаю, {e.Message.From.FirstName}"); break;
        //                }
        //            case "/rnd":
        //                {
        //                    await botClient.SendTextMessageAsync(e.Message.Chat.Id, $"{new Random().Next(0, 10)}"); break;
        //                }
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}