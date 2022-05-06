using ChatBotFramework;
using ChatBot.Commands;
using ChatBot.CommandValidationMiddleware;
using ChatBot.TelegramApiProvider;
using ChatBot.VkApiProvider;

class Program
{
    private static void Main(string[] args)
    {
        var cmdNotFoundMsg = "Команда не найдена или указаны неверные аргументы.\nОтправьте /help, чтобы получить справку по командам.";
        var executor = new CommandExecutor(cmdNotFoundMsg,
                new StartCommand(),
                new HelpCommand(),
                new RepeatCommand(),
                new MixCommand(),
                new GenerateUraDaDavaiCommand());

        var botNameValidator = new BotNameValidator(new string[] {"ura", "ура", "@ura_da_davai_bot", "*ura_da_davai", "@ura_da_davai" });
        var middleware = new CheckCommandContainsBotNameMiddleware(executor, botNameValidator);

        var tgApiProvider = new TelegramApiProvider(middleware);
        var vkApiProvider = new VkApiProvider(middleware);

        tgApiProvider.Start();
        vkApiProvider.Start();

        Console.WriteLine("Bot started");

        while(true)
        {
            Thread.Sleep(1000);
        }
    }
}
