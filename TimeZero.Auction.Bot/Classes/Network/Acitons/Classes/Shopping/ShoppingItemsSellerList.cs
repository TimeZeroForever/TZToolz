using System;
using System.Collections.Generic;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes.Shopping
{
    public sealed class ShoppingItemsSellerList : List<ShoppingItemsSeller>
    {

#region Constants

        private const int MAX_NUMBER_OF_PURCHASED_ITEMS = 2   ;
        private const int TTL_OF_RECORD_MIN             = 120 ;  //In minutes, 2 hours

#endregion

#region Class methods

        private ShoppingItemsSeller Get(string owner)
        {
            return Find(sis => sis.Owner == owner);
        }

        private ShoppingItemsSeller Append(string owner)
        {
            ShoppingItemsSeller sis = Get(owner);
            if (sis == null)
            {
                sis = new ShoppingItemsSeller(owner);
                Add(sis);
            }
            return sis;
        }

        public bool Check(string owner)
        {
            //Get/create an owner record
            ShoppingItemsSeller sis = Append(owner);

            //Check on max number of purchased items
            if (sis.NumberOfPurchasedItems == MAX_NUMBER_OF_PURCHASED_ITEMS)
            {
                return false;
            }

            //Increase number of purchased items
            sis.NumberOfPurchasedItems++;
            return true;
        }

        public void Refresh()
        {
            DateTime now = DateTime.Now;
            List<ShoppingItemsSeller> toRemove = new List<ShoppingItemsSeller>();

            //Searching for old records
            foreach (ShoppingItemsSeller sis in this)
            {
                DateTime lastUpdateTime = sis.LastUpdateTime;
                TimeSpan timeDiff = now.Subtract(lastUpdateTime);
                if (timeDiff.TotalMinutes >= TTL_OF_RECORD_MIN)
                {
                    toRemove.Add(sis);
                }
            }

            //Remove old records
            foreach (ShoppingItemsSeller sis in toRemove)
            {
                Remove(sis);
            }
        }

#endregion

    }
}
