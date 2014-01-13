using System;
using System.Collections.Generic;
using System.Linq;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.ChatBot.Phrases;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using System.Media;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.GameSystem
{
    public sealed class GameSystemStep_ChatBot : IActionStep
    {

#region Static private fields

        private static readonly ChatBotConversationList _conversations = new ChatBotConversationList();
        private static readonly List<ChatMessage> _outChatMessages = new List<ChatMessage>();
        private readonly SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.private_message);

        private static readonly HashSet<string> _blackList = new HashSet<string>
        {
             "Дочка_пенопласта"
        };

#endregion

#region Properties

        public bool IsReadyForAction { get { return true; } }

#endregion

#region Static methods

        public static void AppendIncomingMessage(string sender, bool isPrivateMessage,
            bool isPersonalMessage, bool isMultiUserMessage, string message)
        {
            if (!_blackList.Contains(sender) && !isMultiUserMessage)
            {
                ChatMessageType type = isPrivateMessage
                    ? ChatMessageType.Pivate
                    : ChatMessageType.Personal;
                ChatMessage inMessage = _conversations.AddMessage(sender, type, 
                    ChatMessageDirection.In, message);
                if (inMessage != null)
                {
                    string answer = PhrasesFactory.ProcessChatMessageForAnswer(inMessage);
                    if (!string.IsNullOrEmpty(answer))
                    {
                        ChatMessage outMessage = _conversations.AddMessage(sender, type,
                            ChatMessageDirection.Out, answer);
                        _outChatMessages.Add(outMessage);


                    }
                }
            }
        }

#endregion

#region Class methods

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            DateTime now = DateTime.Now;
            ChatMessage[] outChatMessages = _outChatMessages.Where(cm => cm.MessageTime <= now ).ToArray();

            if (outChatMessages.Length > 0)
            {
                foreach (ChatMessage chatMessage in outChatMessages)
                {
                    _outChatMessages.Remove(chatMessage);

                    //1: From, 2: To, 3: Type, 4: Message
                    string message = Packet.BuildPacket(FromClient.CHAT_MESSAGE,
                        Chat.POST, client.Login, chatMessage.Sender, chatMessage.Type,
                        chatMessage.Message);
                    networkClient.SendChatData(message);

                    //Play notification for private message
                    _soundPlayer.Play();

                    //Out chat message
                    string logMessage = string.Format("[{0}] {1} [{2}] {3}",
                        client.Login,
                        chatMessage.Type == ChatMessageType.Pivate ? "private" : "to",
                        chatMessage.Sender, chatMessage.Message);
                    networkClient.OutChatMessage(logMessage);
                }
                return true;
            }

            return false;
        }

        public void Reset() 
        {
            _conversations.Clear();
        }

#endregion

    }
}
