using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.Constants;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.GameSystem
{
    public sealed class GameSystemStep_Errors : IActionStep
    {
        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            Packet[] packets = networkClient.InputQueue.PopAll(FromServer.ERROR);
            foreach (Packet packet in packets)
            {
                string errorCode = packet["@code"];
                string errorMessage = Errors.GameError.GetErrorMessage(errorCode);
                switch (errorCode)
                {
                    case Errors.GameError.E_USER_HAS_DROPPED:
                    case Errors.GameError.E_PLAYER_ON_ANOTHER_SERVER:
                    case Errors.GameError.E_CONNECTION_ERROR:
                        {
                            networkClient.ThrowError(errorMessage);
                            break;
                        }
                    default:
                        {
                            networkClient.OutLogMessage(string.Format("ERROR: {0}", errorMessage));
                            break;
                        }
                }
            }
            return true;
        }

        public void Reset() { }
    }
}