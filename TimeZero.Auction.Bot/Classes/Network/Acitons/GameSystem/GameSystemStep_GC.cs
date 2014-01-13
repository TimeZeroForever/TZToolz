using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using System.Reflection;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameSystemStep_GC : IActionStep
    {

#region Constants

        private const int TTL_OF_PACKER_SEC   = 300   ; //In seconds, 5 min
        private const int GC_COLLECT_DELAY_MS = 10000 ; //In milliseconds, 10 sec

#endregion

#region Static private fields

        private static readonly HashSet<string> _sysPackets = new HashSet<string>();

#endregion

#region Private fields

        private int _prewGCCollectTime;

#endregion

#region Properties

        public bool IsReadyForAction
        {
            get
            {
                int curTickCount = Environment.TickCount;
                return _prewGCCollectTime == 0 || curTickCount - _prewGCCollectTime >= GC_COLLECT_DELAY_MS;
            }
        }

#endregion

#region Static methods

        static GameSystemStep_GC()
        {
            Type type = typeof(FromServer);
            IEnumerable<FieldInfo> fieldInfo = type.GetFields(BindingFlags.Public |
                                                              BindingFlags.Static).
                Where(fi => fi.IsLiteral && !fi.IsInitOnly);
            foreach (FieldInfo fi in fieldInfo)
            {
                string packetType = fi.GetValue(null).ToString();
                if (!_sysPackets.Contains(packetType))
                {
                    _sysPackets.Add(packetType);
                }
            }
        }

#endregion

#region Class methods

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            if (IsReadyForAction)
            {
                DateTime now = DateTime.Now;

                //Collect garbage
                IEnumerable<Packet> packets = networkClient.InputQueue.PeakAll(null).
                    Where(p => now.Subtract(p.ReceiveTime).TotalSeconds >= TTL_OF_PACKER_SEC);
                networkClient.InputQueue.RemoveAll(packets);

                //Generate list of unknown packets
                Packet[] unkPackets = packets.Where(p => !_sysPackets.Contains(p.Type)).ToArray();
                if (unkPackets.Length > 0)
                {
                    //Generate log message
                    StringBuilder message = new StringBuilder();
                    foreach (Packet packet in unkPackets)
                    {
                        message.AppendFormat("{0}{1}", message.Length == 0 ? "" : ", ",
                            packet.Type);
                    }
                    message.Insert(0, "GC -> unknown packets: ");

                    //Send log message
                    networkClient.OutLogMessage(message.ToString());
                }

                _prewGCCollectTime = Environment.TickCount;
            }
            return true;
        }

        public void Reset() 
        {
            _prewGCCollectTime = 0;
        }

#endregion

    }
}
