using ChatBotFramework.Abstract;
using VkBotFramework;

namespace ChatBot.VkApiProvider
{
    internal class VkApiProvider : UserIOProviderBase
    {
        private readonly VkBot _bot;

        public VkApiProvider(CommandValidationMiddlewareBase commandsValidationMiddleware) 
            : base(commandsValidationMiddleware)
        {
            var dataLoader = new VkApiProviderDataLoader();
            var token = dataLoader.GetApiToken();   
            var url = dataLoader.GetGroupUrl();

            _bot = new VkBot(token, url);
            _bot.OnMessageReceived += OnCommandReceived;
        }

        public override void Start()
        {
            _bot.StartAsync();
        }

        public override void Stop()
        {
            _bot.Dispose();
        }

        private void OnCommandReceived(object? sender, VkBotFramework.Models.MessageReceivedEventArgs e)
        {
            var command = e.Message.Text;
            var senderId = e.Message.PeerId;

            var data = new VkCommandData(senderId.ToString(), command, SendResponce);
            CommandReceived.Invoke(data);
        }

        public override void SendResponce(string toId, string message)
        {
            var peerId = long.Parse(toId);

            try
            {
                SendMessage(peerId, message);
            }
            catch (VkNet.Exception.MessageIsTooLongException)
            {
                var errorMsg = "Результат слишком длинный, не могу отправить.";
                SendMessage(peerId, errorMsg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникло исключение: {e.GetType()}");
            }
        }

        private void SendMessage(long? peer, string responseMessage)
        {
            _bot.Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                Message = responseMessage,
                PeerId = peer,
                RandomId = Environment.TickCount
            });
        }
    }
}