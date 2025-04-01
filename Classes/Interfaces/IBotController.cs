using Telegram.Bot;

namespace TelegramBotBuilder
{
    public interface IBotController
    {
        public void TelegramConfig();

        public void TelegramStart();

        public void BotConnect();

    }
}
