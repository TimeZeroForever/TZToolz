using TimeZero.Auction.Bot.Classes.Common;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.GameItems;
using TimeZero.Auction.Bot.Classes.Network;

namespace TimeZero.Auction.Bot.ClassesInstances
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
