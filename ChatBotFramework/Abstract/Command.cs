namespace ChatBotFramework.Abstract
{
    /// <summary>
    /// Base class for bot commands.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Check is input string contains this command.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>true - if contains, else - false</returns>
        public abstract bool CheckStringConformity(string inputString);

        /// <summary>
        /// Execute an input string as this command. Throws an exception, if input string is not containing this command.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Command execution result</returns>
        /// <exception cref="ArgumentException"></exception>
        public string Execute(string inputString)
        {
            if (!CheckStringConformity(inputString))
            {
                throw new ArgumentException();
            }

            return CommandExecution(inputString);
        }

        /// <summary>
        /// Method that should contain the command execution logic.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Command execution result</returns>
        protected abstract string CommandExecution(string inputString);
    }
}
