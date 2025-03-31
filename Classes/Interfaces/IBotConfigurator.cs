using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBotBuilder
{
    public interface IBotConfigurator
    {
        public void SetBotSettings();
        public Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token);
        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token);
    }
}
