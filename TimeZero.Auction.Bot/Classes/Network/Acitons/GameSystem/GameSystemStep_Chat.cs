using System;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using System.Text.RegularExpressions;
using System.Media;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.GameSystem
{
    public sealed class GameSystemStep_Chat : IActionStep
    {

#region Static private fields

        private static readonly Regex _regexChatSender =
            new Regex(@"^.+? \[(?<SENDER>.+?)\]", RegexOptions.ExplicitCapture);
        private static readonly Regex _regexChatUsers = 
            new Regex(@"((?<PRIVATE>private)|(?<PERSONAL>to)) \[(?<USER>.+?)\]",
                      RegexOptions.ExplicitCapture);
        private static readonly Regex _regexChatMessage =
            new Regex(@"\](?!.+\]) (?<MESSAGE>.+?)$", RegexOptions.ExplicitCapture);
        private static readonly Regex _regexChatFullMessage =
            new Regex(@"^.+? (?<MESSAGE>\[.+?$)", RegexOptions.ExplicitCapture);

#endregion

#region Private fields

        private readonly SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.private_message);

#endregion

#region Properties

        public bool IsReadyForAction { get { return true; } }

#endregion

#region Class methods

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            Packet[] packets = networkClient.InputQueue.PopAll(FromServer.CHAT_MESSAGE);

            if (!networkClient.OutChatMessages || packets.Length == 0)
            {
                return false;
            }

            foreach (Packet packet in packets)
            {
                //Get chat message data
                string messageData = packet["@text"];

                if (string.IsNullOrEmpty(messageData) || packet["@html"] == "1")
                {
                    continue;
                }

                //Get sender name
                string sender = _regexChatSender.Match(messageData).Groups["SENDER"].Value;

                //Check if the message is private or personal
                bool isPrivateMessage = false, isPersonalMessage = false;
                MatchCollection matchesUsers = _regexChatUsers.Matches(messageData);
                foreach (Match matchUser in matchesUsers)
                {
                    string user = matchUser.Groups["USER"].Value;
                    if (user.Equals(client.Login, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isPrivateMessage |= matchUser.Groups["PRIVATE"].Success;
                        isPersonalMessage |= matchUser.Groups["PERSONAL"].Success;
                    }
                }

                //Out only private or personal messages
                if (isPrivateMessage || isPersonalMessage)
                {
                    //Play notification for private message
                    if (isPrivateMessage)
                    {
                        _soundPlayer.Play();
                    }

                    //Get chat message content
                    string message = _regexChatMessage.Match(messageData).Groups["MESSAGE"].Value;

                    //Get full chat message content
                    string fullMessage = _regexChatFullMessage.Match(messageData).Groups["MESSAGE"].Value;

                    //Out full chat message
                    networkClient.SendChatMessage(fullMessage);
                }
            }

            return true;
        }

        public void Reset() {}

#endregion

    }
}
