namespace ChatBotFramework.Abstract
{
    /// <summary>
    /// Base class for command validation middlewares.
    /// </summary>
    public abstract class CommandValidationMiddlewareBase
    {
        /// <summary>
        /// The Command Executor that the validator interacts with 
        /// </summary>
        private ICommandExecutor _commandsExecutor;

        /// <summary>
        /// Sets the Command Executor, that will be used to execute valid commands.<br/>
        /// Throws exception, if granted executor is null.
        /// </summary>
        /// <param name="executor"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CommandValidationMiddlewareBase(ICommandExecutor executor)
        {
            _commandsExecutor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        /// <summary>
        /// This method is calling from UserIOProvider, when CommandReceived event invokes.
        /// </summary>
        public abstract void OnCommandReceived(CommandDataBase commandData);

        /// <summary>
        /// Send command to the current Command Executor. 
        /// </summary>
        /// <returns>Command execution result</returns>
        protected string SendCommandForExecution(string command)
        {
            return _commandsExecutor.ExecuteCommand(command);
        }
    }
}
