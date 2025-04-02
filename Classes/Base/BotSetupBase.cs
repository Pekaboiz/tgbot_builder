using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotBuilder
{
    public abstract class BotSetupBase
    {
        public TelgramBotBase? bot;
        protected string configPath;

        public BotSetupBase(string _path, TelgramBotBase _bot)
        {
            configPath = _path;
            bot = _bot;

            if (File.Exists(configPath))
            {
                LoadConfiguration();
            }
        }

        // Getting the configuration from the json file
        public virtual void LoadConfiguration()
        {
            string? json = File.ReadAllText(configPath);
            RootBotBase? root = JsonConvert.DeserializeObject<RootBotBase>(json);

            if (root != null)
            {
                bot = root.botConfig;
            }
        }
    }
}
