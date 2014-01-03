using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Constants
{
    public static class Locations
    {
        //Format: X: + Y: + BuildingId
        public static readonly HashSet<string> Shops = new HashSet<string>
            {
                //Moscow: auction
                "1:" + "359:" + "56"
            };

        //Format: X: + Y: + BuildingId
        public static readonly HashSet<string> Auctions = new HashSet<string>
            {
                //Moscow: auction
                "1:" + "359:" + "56"
            };
    }
}
