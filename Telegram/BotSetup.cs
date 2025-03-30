using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBotBuilder
{
    // Classes for the configuration of the bot
    public class TelgramBot
    {
        public string? Token { get; set; }
    }
    public class RootBot
    {
        public TelgramBot? botConfig;
    }

    public class BotSetup
    {
        public TelgramBot? bot;
        private string configPath;

        public BotSetup(string _path)
        {
            configPath = _path;
            bot = new TelgramBot();

            if (File.Exists(configPath))
            {
                LoadConfiguration();
            }
        }

        // Getting the configuration from the json file
        public void LoadConfiguration()
        {
            string? json = File.ReadAllText(configPath);
            RootBot? root = JsonConvert.DeserializeObject<RootBot>(json);

            if (root != null)
            {
                bot = root.botConfig;
            }
        }
    }
}
