using TimeZero.Auction.Bot.Game.GameClients;
using TimeZero.Auction.Bot.Game.GameItems;
using TimeZero.Auction.Bot.Common;
using TimeZero.Auction.Bot.Network;

namespace TimeZero.Auction.Bot.ObjectInstances
{
    public static class Instance
    {
        //GameItemsGroups
        public static GameItemsGroupList GameItemsGroups
        {
            get { return Singletone<GameItemsGroupList>.Instance; }
            set { Singletone<GameItemsGroupList>.Instance = value; }
        }

        //NetworkClient
        public static NetworkClient NetworkClient
        {
            get { return Singletone<NetworkClient>.Instance; }
        }

        //GameClient
        public static GameClient GameClient
        {
            get { return Singletone<GameClient>.Instance; }
        }
    }
}
