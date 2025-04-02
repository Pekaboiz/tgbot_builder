namespace TelegramBotBuilder
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            BotControllerTests conrtoller = new BotControllerTests(@"D:\Git\TelegramBotBuilder", "TOKEN", "CONFIG.json");

            if (args.Length > 0 && args[0] == "/genconfig")
            {
                conrtoller.TelegramConfig();
                return;
            }
            conrtoller.TelegramStart();

            await Task.Delay(-1);
        }
    }
}
