using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotBuilder;

namespace TelegramBotBuilder
{
    public abstract class BotControllerBase : IBotController
    {
        protected ITelegramBotClient? botClient { get; set; }
        protected string _tempPath { get; set; }
        protected string _token { get; set; }
        protected string _nameJSON { get; set; }
        public BotControllerBase(string path, string token, string nameJSON)
        {
            _tempPath = Path.Combine(path, nameJSON);
            _token = token;
            _nameJSON = nameJSON;
        }

        public virtual void TelegramConfig()
        {
            if (!File.Exists(_tempPath) && _token != null)
            {
                ConfigGenerator config = new ConfigGenerator(_tempPath, _token);
            }
        }

        public virtual void TelegramStart()
        {
            BotConnect();
            if (botClient != null) { BotConfigurateBase botCfg = new BotConfigurate(botClient); }
        }

        // Connect Telegram Bot
        public virtual void BotConnect()
        {
            if (_tempPath != null)
            {
                BotSetup telegram = new BotSetup(_tempPath);
                TelgramBot? _bot = telegram.bot;

                if (_bot != null && _bot.Token != null)
                {
                    botClient = new TelegramBotClient(_bot.Token);
                }
            }
        }

    }
}
