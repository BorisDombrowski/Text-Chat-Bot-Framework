namespace ChatBotFramework.Abstract
{
    /// <summary>
    /// Base class for command data.
    /// </summary>
    public abstract class CommandDataBase
    {
        /// <summary>
        /// The ID of the chat the command send from.
        /// </summary>
        public string SenderId { get; }
        /// <summary>
        /// String, that contains received command.
        /// </summary>
        public string Command { get; }
        /// <summary>
        /// Method to send response to the command.
        /// </summary>
        private Action<string, string> _sendResponceMethod;

        public CommandDataBase(string senderId, string command, Action<string, string> sendResponceMethod)
        {
            SenderId = senderId;
            Command = command;
            _sendResponceMethod += sendResponceMethod ?? throw new ArgumentNullException(nameof(sendResponceMethod));
        }

        /// <summary>
        /// Sending response to the command
        /// </summary>
        /// <param name="message">Text of the response</param>
        public void SendResponse(string message)
        {
            _sendResponceMethod?.Invoke(SenderId, message);
        }

        /// <summary>
        /// Check is current command received from group chat.
        /// </summary>
        /// <returns>Always false in default implementation</returns>
        public virtual bool IsCommandFromGroupChat()
        {
            return false;
        }
    }
}
