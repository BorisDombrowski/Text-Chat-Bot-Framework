namespace ChatBotFramework.Abstract
{
    /// <summary>
    /// Interface for Command Executors.
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Execute input string as a command.
        /// </summary>
        /// <param name="command">String, that contains a command</param>
        /// <returns>Command execution result</returns>
        string ExecuteCommand(string command);
    }
}
