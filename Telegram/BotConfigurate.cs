using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBotBuilder
{
    public class BotConfigurate
    {
        public ITelegramBotClient botClient;
        ReceiverOptions receiverOptions;
        public BotConfigurate(ITelegramBotClient _bot)
        {
            botClient = _bot;
            receiverOptions = new ReceiverOptions();
            SetBotSettings();
        }
        
        public virtual async void SetBotSettings()
        {
            using var cts = new CancellationTokenSource();

            receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // Allowed updates
            };

            botClient.StartReceiving(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync), receiverOptions, cts.Token);


            await Task.Delay(1);
        }

        public virtual async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;

            long chatId = message.Chat.Id;

            Console.WriteLine("Bot get the massage from user!");

            string responseText = messageText switch
            {
                "/start" => "Hi, i'm bot 😊",
                "Hello" => "Hi, how are u?",
                _ => "I don't have answer on this... 🤔"
            };

            await client.SendMessage(chatId, responseText, cancellationToken: token);
        }


        public virtual async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
