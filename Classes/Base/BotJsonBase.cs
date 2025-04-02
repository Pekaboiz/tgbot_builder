using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotBuilder
{
    public class TelgramBotBase
    {
        public string? Token { get; set; }
    }
    public class RootBotBase
    {
        public TelgramBotBase? botConfig;
    }
}
