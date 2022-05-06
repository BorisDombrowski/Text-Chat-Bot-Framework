using ChatBotFramework.Abstract;

namespace ChatBotFramework
{
    /// <summary>
    /// Simple command validation middleware.<br/>
    /// Actually not contains any specific validation logic, 
    /// just sends the command right to the Command Executor, and then sends command result as response.
    /// </summary>
    public class CommandValidationMiddleware : CommandValidationMiddlewareBase
    {
        public CommandValidationMiddleware(ICommandExecutor executor) : base(executor) { }

        public override void OnCommandReceived(CommandDataBase commandData)
        {
            var command = commandData.Command;
            var result = SendCommandForExecution(command);
            commandData.SendResponse(result);
        }
    }
}
