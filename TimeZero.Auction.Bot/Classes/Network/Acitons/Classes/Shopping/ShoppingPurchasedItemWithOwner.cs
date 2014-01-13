using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using TimeZero.Auction.Bot.Classes.Game.GameItems;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes
{
    public sealed class ShoppingPurchasedItemWithOwner
    {

#region Public fields

        public string Item;
        public string Owner;
        public DateTime LastUpdateTime;

#endregion

#region Class methods

        public ShoppingPurchasedItemWithOwner(GameItem gameItem, string owner)
        {
            Item = gameItem.ToString();
            Owner = owner;
            LastUpdateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Item, Owner);
        }

#endregion

    }
}
