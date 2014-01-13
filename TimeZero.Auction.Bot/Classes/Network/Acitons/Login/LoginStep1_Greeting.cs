using System.Collections.Generic;
using System.Text;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Login
{
    public sealed class LoginStep1_Greeting : IActionStep
    {
        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            networkClient.OutLogMessage("Getting a servers list...");

            //Send greeting
            string greeting = Packet.BuildPacket(FromClient.GREETING);
            networkClient.SendData(greeting);

            //Get response
            Packet packet = networkClient.InputQueue.Pop();

            if (packet != null)
            {
                //Get available servers
                List<string> servers = packet.GetValues("S/@host");

                //Log message
                StringBuilder sServers = new StringBuilder();

                //Store available servers
                foreach (string server in servers)
                {
                    sServers.AppendFormat("{0}{1}", sServers.Length > 0 ? ", " : "", server);
                    client.AdditionalData.Add(ObjectPropertyName.GAME_SERVER, server);
                }

                networkClient.OutLogMessage(sServers.Insert(0, "Available servers: ").ToString());
                return true;
            }

            networkClient.ThrowError("Failed to getting a servers list or the connection was terminated");
            return false;
        }

        public void Reset() { }
    }
}
