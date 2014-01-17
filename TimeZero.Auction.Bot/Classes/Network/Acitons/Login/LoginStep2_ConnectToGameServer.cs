using System.Collections.Generic;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Login
{
    public sealed class LoginStep2_ConnectToGameServer : IActionStep
    {
        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            //Get game servers list
            List<object> gameServersList = client.AdditionalData[ObjectPropertyName.GAME_SERVER];

            //If servers list is available
            if (gameServersList != null)
            {
                //Connect to the game server
                while (gameServersList.Count > 0)
                {
                    //Pop a first game server in the list
                    string server = (string) gameServersList[0];
                    gameServersList.Remove(server);

                    //Out log message
                    networkClient.OutLogMessage(string.Format("Connecting to the game server: {0}...", server));

                    //Try to connect
                    bool isConnected = networkClient.ConnectToGameServer(server);
                    if (isConnected)
                    {
                        if (networkClient.DoAuthorization())
                        {
                            return true;
                        }
                    }
                }
            }

            //Connection failed
            networkClient.Disconnect();
            return false;
        }

        public void Reset() { }
    }
}
