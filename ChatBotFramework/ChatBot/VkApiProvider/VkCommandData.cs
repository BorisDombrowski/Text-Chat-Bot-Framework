using ChatBotFramework.Abstract;

namespace ChatBot.VkApiProvider
{
    internal class VkCommandData : CommandDataBase
    {
        public VkCommandData(string senderId, string command, Action<string, string> sendResponceMethod)
            : base(senderId, command, sendResponceMethod) { }

        public override bool IsCommandFromGroupChat()
        {
            var id = long.Parse(SenderId);
            return id >= 2000000000;
        }
    }
}
