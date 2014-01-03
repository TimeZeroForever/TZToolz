using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TimeZero.Auction.Bot.Classes.Network.ProtoPacket
{
    public sealed class ProtoPacketsQueue
    {

#region Private fields

        private volatile bool _waiting;
        private volatile bool _terminated;

        private readonly object _popSync = new object();
        private readonly object _pushSync = new object();
        private readonly List<Packet> _list = new List<Packet>();
        private readonly Semaphore _queueSemaphore = new Semaphore(0, int.MaxValue);
        private readonly ManualResetEvent _terminatedEvent = new ManualResetEvent(false);
        private readonly WaitHandle[] _waitEventHandles;

        private readonly Dictionary<string, ManualResetEvent> _typedPacketEvents = 
            new Dictionary<string, ManualResetEvent>(10);

#endregion

#region Class methods

        public ProtoPacketsQueue()
        {
            _waitEventHandles = new WaitHandle[] { _queueSemaphore, _terminatedEvent };
        }

        private bool WaitForData()
        {
            _waiting = true;
            try
            {
                WaitHandle.WaitAny(_waitEventHandles);
                return !_terminated;
            }
            finally
            {
                _waiting = false;
            }
        }

        //Pop a first packet

        public Packet Pop()
        {
            lock (_popSync)
            {
                if (WaitForData())
                {
                    lock (_pushSync)
                    {
                        Packet packet = _list[_list.Count - 1];
                        _list.Remove(packet);
                        return packet;
                    }
                }
                return null;
            }
        }

        //Pop typed single packet

        private Packet PopPacket(string packetType)
        {
            Packet packet = _list.Find(p => p.Type == packetType);
            if (packet != null)
            {
                _list.Remove(packet);
            }
            return packet;
        }

        public Packet Pop(string packetType)
        {
            return Pop(packetType, true);
        }

        public Packet Pop(string packetType, bool waitForData)
        {
            Packet packet;
            ManualResetEvent waitEvent = null;

            lock (_popSync) lock (_pushSync)
            {
                packet = PopPacket(packetType);
                if (packet == null && waitForData)
                {
                    if (!_typedPacketEvents.ContainsKey(packetType))
                    {
                        _typedPacketEvents.Add(packetType, waitEvent = new ManualResetEvent(false));
                    }
                    else
                    {
                        waitEvent = _typedPacketEvents[packetType];
                        waitEvent.Reset();
                    }
                }
            }

            if (waitEvent != null)
            {
                waitEvent.WaitOne();
                if (!_terminated)
                {
                    lock (_popSync) lock (_pushSync)
                    {
                        packet = PopPacket(packetType);
                    }
                }
            }

            return packet;
        }

        //Pop anyone of typed single packets

        private Packet PopPacket(IEnumerable<string> packetTypes)
        {
            Packet packet = _list.Find(p => packetTypes.Contains(p.Type));
            if (packet != null)
            {
                _list.Remove(packet);
            }
            return packet;
        }

        public Packet PopAny(IEnumerable<string> packetTypes)
        {
            return PopAny(packetTypes, true);
        }

        public Packet PopAny(IEnumerable<string> packetTypes, bool waitForData)
        {
            Packet packet;
            List<ManualResetEvent> waitEventsList = null;

            lock (_popSync) lock (_pushSync)
            {
                packet = PopPacket(packetTypes);
                if (packet == null && waitForData)
                {
                    waitEventsList = new List<ManualResetEvent>(packetTypes.Count());
                    foreach (string packetType in packetTypes)
                    {
                        ManualResetEvent waitEvent;
                        if (!_typedPacketEvents.ContainsKey(packetType))
                        {
                            _typedPacketEvents.Add(packetType, waitEvent = new ManualResetEvent(false));
                        }
                        else
                        {
                            waitEvent = _typedPacketEvents[packetType];
                            waitEvent.Reset();
                        }
                        waitEventsList.Add(waitEvent);
                    }
                }
            }

            if (waitEventsList != null)
            {
                WaitHandle.WaitAny(waitEventsList.ToArray());
                if (!_terminated)
                {
                    lock (_popSync) lock (_pushSync)
                    {
                        packet = PopPacket(packetTypes);
                    }
                }
            }

            return packet;
        }

        //Pop all packets

        public Packet[] PopAll(string packetType)
        {
            lock (_popSync) lock (_pushSync)
            {
                Packet[] packets = _list.Where(p => p.Type == packetType).ToArray();
                foreach (Packet packet in packets)
                {
                    _list.Remove(packet);
                }
                for (int i = 0; i < packets.Length - 1; i++)
                {
                    _queueSemaphore.WaitOne();
                }
                return packets;
            }
        }

        //Peak all packets

        public Packet[] PeakAll(string packetType)
        {
            lock (_popSync) lock (_pushSync)
            {
                Packet[] packets = _list.Where(p => packetType == null || 
                                               p.Type == packetType).ToArray();
                return packets;
            }
        }

        //Remove each packet from list

        public void RemoveAll(IEnumerable<Packet> packets)
        {
            lock (_pushSync) lock (_popSync)
            {
                foreach (Packet packet in packets)
                {
                    _list.Remove(packet);
                }
            }            
        }

        //Push packet to queue

        public void Push(Packet packet)
        {
            if (packet != null)
            {
                lock (_pushSync)
                {
                    _list.Insert(0, packet);
                    _queueSemaphore.Release();
                    if (_typedPacketEvents.ContainsKey(packet.Type))
                    {
                        _typedPacketEvents[packet.Type].Set();
                    }
                }
            }
        }

        //Terminate waiting

        public void Terminate()
        {
            if (_waiting)
            {
                _terminated = true;
                _terminatedEvent.Set();
                foreach (ManualResetEvent re in _typedPacketEvents.Values)
                {
                    re.Set();
                }
                _typedPacketEvents.Clear();
            }
        }

#endregion

    }
}
