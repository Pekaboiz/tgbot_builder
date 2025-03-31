using Telegram.Bot;

namespace TelegramBotBuilder
{
    public interface IBotConroller
    {
        public void TelegramConfig();

        public void TelegramStart();

        public void BotConnect();

    }
}
