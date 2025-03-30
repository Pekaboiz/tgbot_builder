using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TelegramBotBuilder
{
    public class ConfigGenerator
    {
        private string path;

        public ConfigGenerator(string _path, string _token)
        {
            path = _path;   
            GenerateBaseConfig(_token);
        }

        // Create the configuration file for the bot
        private void GenerateBaseConfig(string _token)
        {
            TelgramBot bot = new TelgramBot { Token = _token }; // attributes of the bot
            RootBot rootBot = new RootBot { botConfig = bot }; // root of the bot

            JObject config = JObject.FromObject(rootBot);

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(path, json); // write the configuration to the file
        }
    }

}

