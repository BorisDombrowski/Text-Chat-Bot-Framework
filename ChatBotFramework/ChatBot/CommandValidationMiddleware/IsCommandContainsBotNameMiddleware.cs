using ChatBotFramework.Abstract;

namespace ChatBot.CommandValidationMiddleware
{
    internal class IsCommandContainsBotNameMiddleware : CommandValidationMiddlewareBase
    {
        private BotNameValidator _botNameValidator;

        public IsCommandContainsBotNameMiddleware(ICommandExecutor executor, BotNameValidator botNameValidator) 
            : base(executor) 
        {
            _botNameValidator = botNameValidator;
        }

        public override void OnCommandReceived(CommandDataBase commandData)
        {
            var command = commandData.Command.Trim();
            var startsByBotName = IsCommandStartsByBotName(command);

            if (commandData.IsCommandFromGroupChat() && !startsByBotName)
            {
                return;
            }

            if (startsByBotName)
            {
                command = RemoveBotNameFromCommand(command);
            }

            var commandResult = SendCommandForExecution(command);
            commandData.SendResponse(commandResult);
        }

        private bool IsCommandStartsByBotName(string command)
        {
            var split = command.Split(' ');
            return _botNameValidator.IsBotName(split[0]);
        }

        private string RemoveBotNameFromCommand(string command)
        {
            var split = command.Split(' ').ToList();
            split.RemoveAt(0);
            return string.Join(' ', split);
        }
    }
}
