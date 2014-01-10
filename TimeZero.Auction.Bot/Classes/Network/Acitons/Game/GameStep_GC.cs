using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameStep_GC : IActionStep
    {
        private static readonly HashSet<string> _junkPackets = new HashSet<string>
                                                                   {
                                                                       FromServer.BOT_INFO,
                                                                       FromServer.MY_INFO,
                                                                       FromServer.ITEM_CHANGE_ONE,
                                                                       FromServer.DIALOG_DATA,
                                                                       FromServer.MY_SKILLS,
                                                                       FromServer.MY_BAFFS,
                                                                       FromServer.MY_PROF,
                                                                       FromServer.MY_SPECIALS,
                                                                       FromServer.MY_SPECIALS_A,
                                                                       FromServer.MY_SPECIALS_D,
                                                                       FromServer.CLIENT_STATUS,
                                                                       FromServer.LOL,
                                                                       FromServer.DM,
                                                                       FromServer.LB,
                                                                       FromServer.ID2,
                                                                       FromServer.ITEM_ADD_ONE,
                                                                       FromServer.UPDATE_VER,
                                                                       FromServer.SHOP_ERROR,
                                                                       FromServer.SHOP_OK,
                                                                       FromServer.CHAT_CTRL,
                                                                       FromServer.EXCHANGE,
                                                                       FromServer.EXCHANGE_CANCEL,
                                                                       FromServer.RELOADL
                                                                   };

        private const int GC_COLLECT_DELAY_MS = 10000; //In milliseconds, 10 sec

        private int _prewGCCollectTime;

        public bool IsReadyForAction
        {
            get
            {
                int curTickCount = Environment.TickCount;
                return _prewGCCollectTime == 0 || curTickCount - _prewGCCollectTime >= GC_COLLECT_DELAY_MS;
            }
        }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            if (IsReadyForAction)
            {
                //Garbage collection
                IEnumerable<Packet> packets = networkClient.InputQueue.PeakAll(null).
                    Where(p => _junkPackets.Contains(p.Type));
                networkClient.InputQueue.RemoveAll(packets);

                //Generate log message
                StringBuilder message = new StringBuilder();
                packets = networkClient.InputQueue.PeakAll(null);
                if (packets.Count() > 0) 
                {
                    networkClient.SendLogMessage("GC has started...");

                    foreach (Packet packet in packets)
                    {
                        message.AppendFormat("{0}{1}", message.Length == 0 ? "" : ", ",
                            packet.Type);
                    }
                    message.Insert(0, ". Packets that were not removed: ");

                    //Send log message
                    message.Insert(0, "GC has finished");
                    networkClient.SendLogMessage(message.ToString());
                }

                _prewGCCollectTime = Environment.TickCount;
            }
            return true;
        }

        public void Reset() 
        {
            _prewGCCollectTime = 0;
        }
    }
}
