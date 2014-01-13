using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Login
{
    public sealed class LoginStep5_StartChat : IActionStep
    {
        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            bool chatStarted = false;
            networkClient.OutLogMessage("Starting chat...");

            //Get chat info
            string getInfo = Packet.BuildPacket(FromClient.CHAT_CTRL, Chat.START);
            networkClient.SendData(getInfo);

            //Start chat
            Packet chat = networkClient.InputQueue.Pop(FromServer.CHAT_CTRL);
            if (chat != null)
            {
                string chatServer = chat["@server"];
                string sessionId = (string)client.AdditionalData[ObjectPropertyName.SESSION_ID][0];
                chatStarted = networkClient.StartChat(chatServer, sessionId);
                if (chatStarted)
                {
                    //1: Session ID, 2: Login
                    string chatAuth = Packet.BuildPacket(FromClient.CHAT_CTRL, Chat.AUTH, 
                        sessionId, client.Login);
                    networkClient.SendChatData(chatAuth);
                }
            }

            networkClient.OutLogMessage(!chatStarted 
                ? "WARNING: chat wasn`t started" 
                : "Chat was successfully started");

            return true;
        }

        public void Reset() {}

    }
}
