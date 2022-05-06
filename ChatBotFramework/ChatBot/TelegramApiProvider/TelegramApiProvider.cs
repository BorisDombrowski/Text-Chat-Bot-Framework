using ChatBotFramework.Abstract;
using Telegram.Bot;

namespace ChatBot.TelegramApiProvider
{
    internal class TelegramApiProvider : UserIOProviderBase
    {
        private readonly TelegramBotClient _bot;

        public TelegramApiProvider(CommandValidationMiddlewareBase commandsValidationMiddleware) 
            : base(commandsValidationMiddleware)
        {
            var dataLoader = new TelegramApiProviderDataLoader();
            var token = dataLoader.GetApiToken();

            _bot = new TelegramBotClient(token);
            _bot.OnMessage += OnCommandReceived;
        }

        public override void Start()
        {
            _bot.StartReceiving();
        }

        public override void Stop()
        {
            _bot.StopReceiving();
        }

        private void OnCommandReceived(object? sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var command = e.Message.Text;
            var senderId = e.Message.Chat.Id;

            if(!string.IsNullOrEmpty(command))
            {
                var data = new TelegramCommandData(senderId.ToString(), command, SendResponce);
                CommandReceived.Invoke(data);
            }
        }

        public override void SendResponce(string toId, string message)
        {
            if(message.Length > 4096)
            {
                var msg = "Результат слишком длинный, не могу отправить.";
                _bot.SendTextMessageAsync(long.Parse(toId), msg);
                return;
            }

            _bot.SendTextMessageAsync(long.Parse(toId), message);
        }
    }
}
