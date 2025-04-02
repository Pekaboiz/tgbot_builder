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
        protected BotConfigurateBase? botCfg;

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
                ConfigGeneratorBase config = new ConfigGeneratorTest(_tempPath, _token);
            }
        }

        public virtual void TelegramStart()
        {
            BotConnect();
            if (botClient != null) { botCfg = new BotConfigurateTests(botClient); }
        }

        public virtual bool IsBotActive()
        {
            if (botCfg != null)
            {
                return botCfg.IsBotRunning;
            }
            else return false;
        }

        // Connect Telegram Bot
        public virtual void BotConnect()
        {
            if (_tempPath != null)
            {
                TelgramBotBase telgramBotBase = new TelgramBotTest();
                BotSetupBase telegram = new BotSetupTest(_tempPath, telgramBotBase);
                TelgramBotBase? _bot = telegram.bot;

                if (_bot != null && _bot.Token != null)
                {
                    botClient = new TelegramBotClient(_bot.Token);
                }
            }
        }

    }
}
