using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes
{
    public sealed class ChatBotConversation
    {

#region Public fields

        public string Sender;
        public List<ChatMessage> Messages;
        public bool SenderInIgnore;

        public int ProcessedPhrasesCount;
        public Dictionary<Phrase_Base, int> PhrasesObjects;

        public DateTime LastUpdateTime;

#endregion

#region Class methods

        public ChatBotConversation(string sender)
        {
            Sender = sender;
            Messages = new List<ChatMessage>();
            PhrasesObjects = new Dictionary<Phrase_Base, int>();
            LastUpdateTime = DateTime.Now;
        }

        public ChatMessage Add(string sender, ChatMessageType type, 
            ChatMessageDirection direction, string message)
        {
            ChatMessage chatMessage = new ChatMessage(sender, type, 
                direction,  message, this);
            Messages.Add(chatMessage);
            LastUpdateTime = DateTime.Now;
            return chatMessage;
        }

        public override string ToString()
        {
            return Sender;
        }

#endregion

    }
}
