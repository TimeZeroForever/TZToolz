using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes
{
    public sealed class ChatBotConversationList : Dictionary<string, ChatBotConversation>
    {

#region Constants

        private const int INCOMING_MESSAGES_LIMIT = 5   ;
        private const int TTL_OF_CONVERSATION_MIN = 120 ; //In minutes, 1 hours

#endregion

#region Class methods

        public ChatMessage AddMessage(string sender, ChatMessageType type,
            ChatMessageDirection direction, string message)
        {
            //Refresh conversations list
            Refresh();

            //Get/create a conversation
            ChatBotConversation conversation;
            if (!ContainsKey(sender))
            {
                conversation = new ChatBotConversation(sender);
                Add(sender, conversation);
            }
            else
            {
                conversation = this[sender];
            }

            //Check if converstaion's sender in ignore or has limit of messages
            if (direction == ChatMessageDirection.In &&
                (conversation.SenderInIgnore ||
                 conversation.ProcessedPhrasesCount == INCOMING_MESSAGES_LIMIT))
            {
                return null;
            }

            //Add conversation message
            return conversation.Add(sender, type, direction, message);
        }

        public void Refresh()
        {
            DateTime now = DateTime.Now;
            List<string> toRemove = new List<string>();

            //Searching for outdated conversations
            foreach (string sender in this.Keys)
            {
                ChatBotConversation cbc = this[sender];
                DateTime lastUpdateTime = cbc.LastUpdateTime;
                TimeSpan timeDiff = now.Subtract(lastUpdateTime);
                if (timeDiff.TotalMinutes >= TTL_OF_CONVERSATION_MIN)
                {
                    toRemove.Add(sender);
                }
            }

            //Remove old records
            foreach (string sender in toRemove)
            {
                Remove(sender);
            }
        }

#endregion

    }
}
