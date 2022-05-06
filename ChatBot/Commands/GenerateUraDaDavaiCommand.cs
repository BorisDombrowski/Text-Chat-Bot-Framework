using ChatBotFramework.Abstract;
using System.Text.RegularExpressions;

namespace ChatBot.Commands
{
    internal class GenerateUraDaDavaiCommand : Command
    {
        private static string[] _words =
        {
            "УРА", "ДА", "ДАВАЙ", "ДАВАААЙ", "ДАААА", "УРААА", "ДАВАААААЙ"
        };

        public override bool CheckStringConformity(string inputString)
        {
            var exp = @"^(gen|ген) (300|[1-2][0-9]{0,2}|[1-9][0-9]{0,1})( \+)?$";
            var regex = new Regex(exp, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return regex.IsMatch(inputString);
        }

        protected override string CommandExecution(string inputString)
        {
            var split = inputString.Split(' ');
            var wordsCount = int.Parse(split[1]);

            var upperOnly = false;
            if (split.Length > 2)
            {
                upperOnly = (split[2] == "+");
            }

            var res = string.Empty;
            var rnd = new Random(Environment.TickCount);
            for (int i = 0; i < wordsCount; i++)
            {
                var word = _words[rnd.Next(_words.Length)];

                if (!upperOnly)
                {
                    if (rnd.Next(-10, 10) > 0)
                    {
                        word = word.ToLower();
                    }
                }

                var seperetor = (rnd.Next(-2, 10) > 0) ? " " : "!! ";
                res += word + seperetor;
            }

            return res.TrimEnd();
        }
    }
}
