using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes
{
    public sealed class ShoppingItemsSeller
    {

#region Private fields

        private int _numberOfPurchasedItems;

#endregion

#region Public fields

        public string Owner;
        public DateTime LastUpdateTime;

#endregion

#region Properties

        public int NumberOfPurchasedItems
        {
            get { return _numberOfPurchasedItems; }
            set
            {
                _numberOfPurchasedItems = value;
                LastUpdateTime = DateTime.Now;
            }
        }

#endregion

#region Class methods

        public ShoppingItemsSeller(string owner)
        {
            Owner = owner;
            NumberOfPurchasedItems = 1;
        }

        public override string ToString()
        {
            return Owner;
        }

#endregion

    }
}
