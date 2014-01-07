using System;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.GameSystem
{
    public sealed class GameSystemStep_Ping : IActionStep
    {
        private const int PING_DELAY_MS = 45000; //In milliseconds, 45 sec

        private int _prewPingTime;
        private bool _firstTime = true;

        public bool IsReadyForAction { get { return true; } }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            int curTickCount = Environment.TickCount;

            //Just started
            if (_prewPingTime == 0)
            {
                _prewPingTime = curTickCount;
                return false;
            }

            if (curTickCount - _prewPingTime >= PING_DELAY_MS)
            {
                //Query params: 0: is a first time ping?, [1]: I1, [2]: ID2, [3]: ID1
                string ping = Packet.BuildPacket(FromClient.PING,
                    _firstTime,
                    client.AdditionalData[ObjectPropertyName.I1][0],
                    client.AdditionalData[ObjectPropertyName.ID2][0],
                    client.AdditionalData[ObjectPropertyName.ID1][0]);
                networkClient.SendData(ping);
                networkClient.SendChatData(ping);

                _firstTime = false;
                _prewPingTime = Environment.TickCount;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _firstTime = true;
            _prewPingTime = 0;
        }
    }
}
