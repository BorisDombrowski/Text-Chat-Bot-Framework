using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.CommandValidationMiddleware
{
    internal class BotNameValidator
    {
        private string[] _botNames;

        public BotNameValidator(string[] botNames)
        {
            _botNames = botNames;
        }

        public bool IsBotName(string inputString)
        {
            return _botNames.Contains(inputString);
        }
    }
}
