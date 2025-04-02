using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TelegramBotBuilder
{
    public class ConfigGeneratorTest : ConfigGeneratorBase
    {
        public ConfigGeneratorTest(string _path, string _token) : base(_path, _token) { }

        // Create the configuration file for the bot
        protected override void GenerateBaseConfig(string _token)
        {
            TelgramBotTest bot = new TelgramBotTest { Token = _token }; // attributes of the bot
            RootBotTest rootBot = new RootBotTest { botConfig = bot }; // root of the bot

            JObject config = JObject.FromObject(rootBot);

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, json); // write the configuration to the file
        }
    }

}

