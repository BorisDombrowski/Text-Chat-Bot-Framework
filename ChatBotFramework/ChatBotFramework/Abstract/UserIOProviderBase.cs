using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotFramework.Abstract
{
    /// <summary>
    /// Base class for your API providers.<br/> 
    /// Use it to implement receiving the calls from API, you chose for your bot.
    /// </summary>
    public abstract class UserIOProviderBase
    {
        /// <summary>
        /// Event you should to invoke, when command received.
        /// </summary>
        protected Action<CommandDataBase> CommandReceived;

        /// <summary>
        /// Adds an commandsValidationMiddleware.OnCommandReceived() method to CommandReceived event.<br/>
        /// Throws an exception, if granted middleware is null.
        /// </summary>
        /// <param name="commandsValidationMiddleware">Middleware, that should process received commands</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserIOProviderBase(CommandValidationMiddlewareBase commandsValidationMiddleware)
        {
            if (commandsValidationMiddleware == null)
            {
                throw new ArgumentNullException(nameof(commandsValidationMiddleware));
            }

            CommandReceived += commandsValidationMiddleware.OnCommandReceived;
        }

        /// <summary>
        /// Method to start receiving calls from your API (if it's necessary).
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Method to stop receiving calls from your API (if it's necessary).
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// Method to send responce to the received command.<br/>
        /// Pass this method to CommandData constructor.
        /// </summary>
        /// <param name="toId">The ID of the chat to send the response to</param>
        /// <param name="message">Response message</param>
        public abstract void SendResponce(string toId, string message);
    }
}
