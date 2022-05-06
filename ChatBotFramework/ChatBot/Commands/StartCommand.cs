using ChatBotFramework.Abstract;
using System.Text.RegularExpressions;

namespace ChatBot.Commands
{
    internal class StartCommand : Command
    {
        public override bool CheckStringConformity(string inputString)
        {
            var exp = @"^(start|/start)$";
            var regExp = new Regex(exp, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return regExp.IsMatch(inputString);
        }

        protected override string CommandExecution(string inputString)
        {
            return "Приветствую! Отправь команду /help, чтобы узнать подробности.";
        }
    }
}
