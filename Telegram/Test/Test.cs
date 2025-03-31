using Telegram.Bot;

namespace TelegramBotBuilder
{
    public class BotControllerTests : BotConrtollerBase
    {
        public BotControllerTests(string path, string token, string nameJSON) : base(path, token, nameJSON) { }

    }

    public class BotConfigurate : BotConfigurateBase
    {
        public BotConfigurate(ITelegramBotClient _bot) : base(_bot) { }
    }
}
