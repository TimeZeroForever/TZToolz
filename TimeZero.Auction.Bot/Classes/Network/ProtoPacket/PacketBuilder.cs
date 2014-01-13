using System;
using TimeZero.Auction.Bot.Classes.Network.Acitons.Classes;

namespace TimeZero.Auction.Bot.Classes.Network.ProtoPacket
{
    public sealed partial class Packet
    {
        private static string BuildPacketGreeting()
        {
            return string.Format("<{0} l=\"qwerty\" />", FromClient.GREETING);
        }

        private static string BuildPacketLoginData(params object[] p)
        {
            return string.Format("<{0} v3=\"{1}\" lang=\"ru\" v2=\"{2}\" v=\"{3}\" p=\"{4}\" l=\"{5}\" />",
                FromClient.LOGIN_DATA, p[0], p[1], p[2], p[3], p[4]);
        }

        //0: is a first time ping?, [1]: I1, [2]: ID2, [3]: ID1
        private static string BuildPacketPing(params object[] p)
        {
            return (bool)p[0]
                ? string.Format("<{0} i1=\"{1}\" id2=\"{2}\" id1=\"{3}\" />",
                                FromClient.PING, p[1], p[2], p[3])
                : string.Format("<{0} />", FromClient.PING);
        }

        private static string BuildPacketGetMyInfo()
        {
            return string.Format("<{0} />", FromClient.GET_MY_INFO);
        }

        private static string BuildPacketShopFull()
        {
            return string.Format("<{0} full=\"1\"/>", FromClient.SHOP);
        }

        //1: item group ID, 2: filter, 3: page number, 4: is auction?
        private static string BuildPacketShopGroups(params object[] p)
        {
            return string.Format("<{0} c=\"{1}\" s=\"{2}\" p=\"{3}\" {4}/>",
                FromClient.SHOP, p[1], p[2], p[3], (bool)p[4] ? "au=\"1\"" : "");
        }

        //1: item ID, 2: count, 3: cost
        private static string BuildPacketShopBuy(params object[] p)
        {
            return string.Format("<{0} buy=\"{1}\" count=\"{2}\" cost=\"{3}\" />",
                FromClient.SHOP, p[1], p[2], p[3]);
        }

        //1: item ID
        private static string BuildPacketShopGetOwn(params object[] p)
        {
            return string.Format("<{0} get=\"{1}\" />",
                FromClient.SHOP, p[1]);
        }

        //1: item ID, 2: cost, [3]: count
        private static string BuildPacketShopSell(params object[] p)
        {
            string count = p.Length > 3 && p[3] != null
                ? string.Format("count=\"{0}\"", p[3])
                : string.Empty;
            return string.Format("<{0} put=\"{1}\" cost=\"{2}\" {3} />",
                FromClient.SHOP, p[1], p[2], count);
        }

        private static string BuildPacketShop(params object[] p)
        {
            if (p.Length == 0)
            {
                throw new Exception("SHOP command should call with additional command");
            }
            string cmd = p[0].ToString().ToLower();
            try
            {
                switch (cmd)
                {
                    case Shop.ITEMS_GET_FULL:
                        return BuildPacketShopFull();
                    case Shop.ITEMS_GET_LIST:
                        return BuildPacketShopGroups(p);
                    case Shop.ITEMS_BUY:
                        return BuildPacketShopBuy(p);
                    case Shop.ITEM_GET_OWN:
                        return BuildPacketShopGetOwn(p);
                    case Shop.ITEM_SELL:
                        return BuildPacketShopSell(p);
                    default:
                        throw new Exception(string.Format("Unrecognized SHOP command: {0}", cmd));
                }
            }
            catch
            {
                throw new Exception(string.Format("Invalid parameters list for SHOP command: {0}", cmd));
            }
        }

        private static string BuildPacketClearIMS()
        {
            return string.Format("<{0} />", FromClient.CLEAR_IMS);
        }

        //1: Item1 ID, 2: Item2 ID
        private static string BuildPacketJoinInventory(object[] p)
        {
            return string.Format("<{0} id1=\"{1}\" id2=\"{2}\" />",
                FromClient.JOIN_INVENTORY, p[0], p[1]);
        }

        private static string BuildPacketChatStart()
        {
            return string.Format("<{0} />", FromClient.CHAT_CTRL);
        }

        //1: Session ID, 2: Login
        private static string BuildPacketChatAuth(object[] p)
        {
            return string.Format("<{0} ses=\"{1}\" l=\"{2}\" />",
                FromClient.CHAT_CTRL, p[1], p[2]);
        }

        private static string BuildPacketChatCtrl(object[] p)
        {
            if (p.Length == 0)
            {
                throw new Exception("CHAT_CTRL command should call with additional command");
            }
            string cmd = p[0].ToString().ToLower();
            try
            {
                switch (cmd)
                {
                    case Chat.START:
                        return BuildPacketChatStart();
                    case Chat.AUTH:
                        return BuildPacketChatAuth(p);
                    default:
                        throw new Exception(string.Format("Unrecognized CHAT_CTRL command: {0}", cmd));
                }
            }
            catch
            {
                throw new Exception(string.Format("Invalid parameters list for CHAT_CTRL command: {0}", cmd));
            }
        }

        //1: To, 2: Type, 3: Message
        private static string BuildPacketChatPost(object[] p)
        {
            string type = ((ChatMessageType)p[3]) == ChatMessageType.Pivate ? "private" : "to";
            string message = string.Format("{0} [{1}] {2}", type, p[2], p[4]);
            return string.Format("<{0} t=\"{1}\" />", FromClient.CHAT_MESSAGE, message);
        }
        
        private static string BuildPacketChatMessage(object[] p)
        {
            if (p.Length == 0)
            {
                throw new Exception("CHAT_MESSAGE command should call with additional command");
            }
            string cmd = p[0].ToString().ToLower();
            try
            {
                switch (cmd)
                {
                    case Chat.POST:
                        return BuildPacketChatPost(p);
                    default:
                        throw new Exception(string.Format("Unrecognized CHAT_MESSAGE command: {0}", cmd));
                }
            }
            catch
            {
                throw new Exception(string.Format("Invalid parameters list for CHAT_MESSAGE command: {0}", cmd));
            }
        }

        public static string BuildPacket(string packetType, params object[] p)
        {
            switch (packetType)
            {
                case FromClient.GREETING:
                    return BuildPacketGreeting();
                case FromClient.LOGIN_DATA:
                    return BuildPacketLoginData(p);
                case FromClient.PING:
                    return BuildPacketPing(p);
                case FromClient.GET_MY_INFO:
                    return BuildPacketGetMyInfo();
                case FromClient.SHOP:
                    return BuildPacketShop(p);
                case FromClient.CLEAR_IMS:
                    return BuildPacketClearIMS();
                case FromClient.JOIN_INVENTORY:
                    return BuildPacketJoinInventory(p);
                case FromClient.CHAT_CTRL:
                    return BuildPacketChatCtrl(p);
                case FromClient.CHAT_MESSAGE:
                    return BuildPacketChatMessage(p);
            }
            return null;
        }
    }
}
