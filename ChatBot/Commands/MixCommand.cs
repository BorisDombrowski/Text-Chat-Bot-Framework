using ChatBotFramework.Abstract;
using System.Text.RegularExpressions;

namespace ChatBot.Commands
{
    internal class MixCommand : Command
    {
        public override bool CheckStringConformity(string inputString)
        {
            var exp = @"^(mix|\/mix|микс|\/микс) ( |\S)+ ([1-9][0-9]{0,2}|1000)$";
            var regExp = new Regex(exp, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            return regExp.IsMatch(inputString);
        }

        protected override string CommandExecution(string inputString)
        {
            var split = inputString.Split(' ');
            var repeatsCount = int.Parse(split[split.Length - 1]);

            var firstIndex = inputString.IndexOf(' ');
            var lastIndex = inputString.LastIndexOf(' ');
            var phrase = inputString.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

            var res = string.Empty;
            for (int i = 0; i < repeatsCount; i++)
            {
                res += MixWords(phrase.Split(' ')) + " ";
            }

            return res.TrimEnd();
        }

        private Random _rnd = new Random(Environment.TickCount);
        private string MixWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var r = _rnd.Next(words.Length);
                words[i] = words[r];
                words[r] = word;
            }
            return string.Join(" ", words);
        }
    }
}
