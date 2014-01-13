using System;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot
{
    public sealed class ChatMessage
    {

#region Public fields

        public string Sender;
        public string Message;
        public ChatMessageType Type;
        public ChatMessageDirection Direction;
        public DateTime MessageTime;

        public ChatBotConversation Conversation;

#endregion

#region Class methods

        public ChatMessage(string sender, ChatMessageType type,
            ChatMessageDirection direction, string message,
            ChatBotConversation conversation)
        {
            Sender = sender;
            Type = type;
            Direction = direction;
            Message = message;
            Conversation = conversation;
            MessageTime = direction == ChatMessageDirection.In
                ? DateTime.Now
                : DateTime.Now.AddSeconds(message.Length / 2 + 5);
        }

        public override string ToString()
        {
            return string.Format("[{0} {1}] {2}",
                Type == ChatMessageType.Pivate ? "PRIVATE" : "PERSONAL", 
                Direction == ChatMessageDirection.In ? "IN" : "OUT",
                Message);
        }

#endregion

    }
}
