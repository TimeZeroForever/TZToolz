using System.Text.RegularExpressions;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;
using TimeZero.Auction.Bot.Classes.Network.Helpers;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Login
{
    public sealed class LoginStep4_GetMe : IActionStep
    {
        private static readonly Regex _regexLocationInfo =
            new Regex(@"^.((hz=""(?<B>\d+)"")|.)+?(X=""(?<X>\d+)"").+(Y=""(?<Y>\d+)"").+Ploc_time=.+[ ](id1=""(?<ID1>[\d|\.]+)"").+(id2=""(?<ID2>[\d|\.]+)"")");

        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            networkClient.SendLogMessage("Getting my information...");

            //Get my information
            string getInfo = Packet.BuildPacket(FromClient.GET_MY_INFO);
            networkClient.SendData(getInfo);

            //Read and store current location information
            Packet myInfo = networkClient.InputQueue.Pop(FromServer.MY_INFO);
            if (myInfo != null)
            {
                string data = myInfo.Data;

                //Store game client additional info
                Match locationInfo = _regexLocationInfo.Match(data);
                client.AdditionalData.Add(ObjectPropertyName.LOCATION_BUILDING,
                    locationInfo.Groups["B"].Value);
                client.AdditionalData.Add(ObjectPropertyName.LOCATION_X,
                    locationInfo.Groups["X"].Value);
                client.AdditionalData.Add(ObjectPropertyName.LOCATION_Y,
                    locationInfo.Groups["Y"].Value);
                client.AdditionalData.Add(ObjectPropertyName.ID1,
                    locationInfo.Groups["ID1"].Value);
                client.AdditionalData.Add(ObjectPropertyName.ID2,
                    locationInfo.Groups["ID2"].Value);
                client.AdditionalData.Add(ObjectPropertyName.I1, "0");

                //Update inventory
                client.InventoryItems = Helper.ParseInventoryItems(data);

                return true;
            }

            networkClient.ThrowError("Failed to getting my info or the connection was terminated");
            return false;
        }

        public void Reset() { }
    }
}
