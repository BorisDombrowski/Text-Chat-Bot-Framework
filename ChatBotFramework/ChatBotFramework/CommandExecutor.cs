using ChatBotFramework.Abstract;

namespace ChatBotFramework
{
    /// <summary>
    /// Simple Command Executor.<br/> 
    /// Checks an input string to conformity with granted in comstructor commands.<br/>
    /// If it has a suitable command, it returns its result. Else it returns a message, that command not found.
    /// </summary>
    public class CommandExecutor : ICommandExecutor
    {
        private Command[] _commands;
        private string _commandNotFoundMessage;
        
        /// <param name="commandNotFoundMessage">Message that will be returned, if received command is not valid</param>
        /// <param name="commands">List of commands, that this executor will contain</param>
        public CommandExecutor(string commandNotFoundMessage, params Command[] commands)
        {
            _commandNotFoundMessage = commandNotFoundMessage;
            _commands = commands;
        }        
        
        /// <returns>If command is valid - result of the comand, else - command is not valid message</returns>
        public string ExecuteCommand(string command)
        {
            var cmd = _commands.FirstOrDefault(x => x.CheckStringConformity(command));
            return cmd?.Execute(command) ?? _commandNotFoundMessage;
        }
    }
}
