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
    [Serializable]
    public class RootBotTest : RootBotBase
    {
        public new TelgramBotTest? botConfig { get; set; }
    }

    public class TelgramBotTest : TelgramBotBase
    {
        public new string? Token { get; set; }
    }

    public class BotSetupTest : BotSetupBase
    {
        public BotSetupTest(string _path, TelgramBotBase _bot) : base(_path, _bot) { }

        // Getting the configuration from the json file
        public override void LoadConfiguration()
        {
            string? json = File.ReadAllText(configPath);
            RootBotTest? root = JsonConvert.DeserializeObject<RootBotTest>(json);

            if (root != null)
            {
                bot = root.botConfig;
            }
        }
    }
}
