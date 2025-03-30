using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace TelegramBotBuilder
{
    public class BotConrtoller
    {
        private static ITelegramBotClient? botClient;
        private static string _tempPath = @"D:\Git\TelegramBotBuilder\bot_settings.json";
        private static string _token = "YOUR_TOKEN";

        public BotConrtoller(string path, string token)
        {
            _tempPath = path;
            _token = token;
        }

        static async Task Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "/genconfig")
            {
                TelegramConfig();
                return;
            }
            TelegramStart();

            await Task.Delay(-1);
        }

        public static void TelegramConfig()
        {
            if (!File.Exists(_tempPath))
            {
                ConfigGenerator config = new("bot_settings.json", _token);
            }
        }

        public static void TelegramStart()
        { 
            BotConnect();
            if (botClient != null) { BotConfigurate botCfg = new BotConfigurate(botClient); }
        }

        // Connect Telegram Bot
        private static void BotConnect() 
        {
#if DEBUG
            BotSetup telegram = new BotSetup(@"D:\\Git\\TelegramBotBuilder\bot_settings.json");
#else
            //BotSetup telegram = new BotSetup("bot_settings.json");
            BotSetup telegram = new BotSetup(_tempPath);
#endif
            TelgramBot? _bot = telegram.bot;

            if (_bot != null && _bot.Token != null)
            {
                botClient = new TelegramBotClient(_bot.Token);
            }
        }
    }
}
