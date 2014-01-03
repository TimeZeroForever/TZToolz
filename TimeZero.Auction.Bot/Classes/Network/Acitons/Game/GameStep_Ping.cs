using System;
using TimeZero.Auction.Bot.Game;

namespace TimeZero.Auction.Bot.Network.Acitons.Game
{
    public sealed class GameStep_Ping : IActionStep
    {
        private const int PING_DELAY_MS = 45000; //In milliseconds, 45 sec

        private int _prewPingTime;

        public void DoStep(NetworkClient networkClient, Client client)
        {
            int curTickCount = Environment.TickCount;
            if (_prewPingTime == 0 || curTickCount - _prewPingTime >= PING_DELAY_MS)
            {
                _prewPingTime = curTickCount;
                const string ping = "<N />";
                networkClient.SendData(ping);
            }
        }
    }
}
