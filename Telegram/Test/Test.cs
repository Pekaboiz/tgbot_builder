using Telegram.Bot;

namespace TelegramBotBuilder
{
    public class BotControllerTests : BotControllerBase
    {
        public BotControllerTests(string path, string token, string nameJSON) : base(path, token, nameJSON) { }

    }

    public class BotConfigurateTests : BotConfigurateBase
    {
        public BotConfigurateTests(ITelegramBotClient _bot) : base(_bot) { }
    }
}
