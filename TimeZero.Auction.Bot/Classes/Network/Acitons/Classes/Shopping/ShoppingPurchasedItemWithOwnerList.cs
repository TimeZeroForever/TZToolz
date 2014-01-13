using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeZero.Auction.Bot.Classes.Game.GameItems;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Classes
{
    public sealed class ShoppingPurchasedItemWithOwnerList : List<ShoppingPurchasedItemWithOwner>
    {

#region Constants

        private const int TTL_OF_RECORD_MIN = 120 ; //In minutes, 2 hours

#endregion

#region Class methods

        private ShoppingPurchasedItemWithOwner Get(GameItem gameItem, string owner)
        {
            string item = gameItem.ToString();
            return this.Find
                (
                    piwo => piwo.Item == item && piwo.Owner == owner
                );
        }

        private ShoppingPurchasedItemWithOwner Append(GameItem gameItem, string owner)
        {
            ShoppingPurchasedItemWithOwner piwo = Get(gameItem, owner);
            if (piwo == null)
            {
                piwo = new ShoppingPurchasedItemWithOwner(gameItem, owner);
                Add(piwo);
            }
            return piwo;
        }

        public bool Check(GameItem gameItem, string owner)
        {
            //Get/create a record
            ShoppingPurchasedItemWithOwner piwo = Append(gameItem, owner);

            //Check on last update time
            DateTime lastUpdateTime = piwo.LastUpdateTime;
            TimeSpan timeDiff = DateTime.Now.Subtract(lastUpdateTime);
            return timeDiff.TotalMinutes < TTL_OF_RECORD_MIN;
        }

        public void Refresh()
        {
            DateTime now = DateTime.Now;
            List<ShoppingPurchasedItemWithOwner> toRemove = 
                new List<ShoppingPurchasedItemWithOwner>();

            //Searching for old records
            foreach (ShoppingPurchasedItemWithOwner piwo in this)
            {
                DateTime lastUpdateTime = piwo.LastUpdateTime;
                TimeSpan timeDiff = now.Subtract(lastUpdateTime);
                if (timeDiff.TotalMinutes >= TTL_OF_RECORD_MIN)
                {
                    toRemove.Add(piwo);
                }
            }

            //Remove old records
            foreach (ShoppingPurchasedItemWithOwner piwo in toRemove)
            {
                Remove(piwo);
            }
        }

#endregion

    }
}
