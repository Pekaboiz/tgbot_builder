using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotBuilder
{
    public abstract class TelgramBotBase
    {
        public string? Token { get; set; }
    }
    public abstract class RootBotBase
    {
        public TelgramBotBase? botConfig;
    }
}
