using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.Constants;
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
            networkClient.SendLogMessage("Starting chat...");

            //Get chat info
            string getInfo = Packet.BuildPacket(FromClient.CHAT, Chat.START);
            networkClient.SendData(getInfo);

            //Start chat
            Packet chat = networkClient.InputQueue.Pop(FromServer.CHAT);
            if (chat != null)
            {
                string chatServer = chat["@server"];
                string sessionId = (string)client.AdditionalData[ObjectPropertyName.SESSION_ID][0];
                chatStarted = networkClient.StartChat(chatServer, sessionId);
                if (chatStarted)
                {
                    //1: Session ID, 2: Login
                    string chatAuth = Packet.BuildPacket(FromClient.CHAT, Chat.AUTH, 
                        sessionId, client.Login);
                    networkClient.SendChatData(chatAuth);
                }
            }

            if (!chatStarted)
            {
                networkClient.SendLogMessage("WARNING: chat wasn`t started");
            }
            else
            {
                networkClient.SendLogMessage("Chat was successfully started");
            }

            return true;
        }

        public void Reset() {}

    }
}
