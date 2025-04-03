using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotBuilder
{
    public abstract class ConfigGeneratorBase
    {
        protected string path;

        public ConfigGeneratorBase(string _path, string _token)
        {
            path = _path;
            GenerateBaseConfig(_token);
        }

        // Create the configuration file for the bot
        protected virtual void GenerateBaseConfig(string _token)
        {
            TelgramBotTest bot = new TelgramBotTest { Token = _token }; // attributes of the bot
            RootBotTest rootBot = new RootBotTest { botConfig = bot }; // root of the bot

            JObject config = JObject.FromObject(rootBot);

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, json); // write the configuration to the file
        }
    }
}
