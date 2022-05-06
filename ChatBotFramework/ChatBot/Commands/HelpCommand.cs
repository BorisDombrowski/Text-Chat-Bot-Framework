using ChatBotFramework.Abstract;
using System.Text.RegularExpressions;

namespace ChatBot.Commands
{
    internal class HelpCommand : Command
    {
        public override bool CheckStringConformity(string inputString)
        {
            var exp = @"^(help|/help)$";
            var regExp = new Regex(exp, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return regExp.IsMatch(inputString);
        }

        protected override string CommandExecution(string inputString)
        {
            return
            "При использовании бота в беседе добавлейте перед командой ура/ura\n" +
            "\n" +
            "\n" +
            "• ген/gen <число_слов> [+] - генерация текста УРА ДА ДАВАЙ\n" +
            "-- <число_слов> - количество слов, которое должен содержать текст (от 1 до 300)\n" +
            "-- [+] - необязательный параметр, добавьте его, если все слова текста должны быть в верхнем регистре\n" +
            "\n" +
            "\n" +
            "• повтор/repeat <слово> <число_повторов>\n" +
            "• повтор/repeat <слова через пробел> <число_повторов> - генерация текста из повторяющейся фразы/слова\n" +
            "-- <слово> - слово, которое нужно повторять\n" +
            "-- <слова через пробел> - фраза, которую нужно повторять\n" +
            "-- <число_повторов> - сколько раз нужно повторить слово (от 1 до 1000)";
        }
    }
}
