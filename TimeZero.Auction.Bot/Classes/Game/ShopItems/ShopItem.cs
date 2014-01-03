using TimeZero.Auction.Bot.Classes.Game.GameItems;
using System;
using TimeZero.Auction.Bot.Classes.Game.InventoryItems;

namespace TimeZero.Auction.Bot.Classes.Game.ShopItems
{
    public sealed class ShopItem
    {

#region Public fields

        public string ID;
        public int Count;
        public float Cost;
        public float Quality;
        public float MaxQuality;
        public bool IsSingle;
        public string Owner;

        public GameItem Parent;

#endregion

#region Properties

        public string Text { get { return Parent.Text; } }
        public float Massa { get { return Parent.Massa; } }
        public string Level { get { return Parent.Level; } }
        public string Modification { get { return Parent.Modification; } }
        public float FactoryCost { get { return Parent.FactoryCost; } }
        public float InstantPurchaseCost { get { return Parent.InstantPurchaseCost; } }
        public string Ident { get { return Parent.Ident; } }
        public string SubGroupID { get { return Parent.SubGroupID; } }
        public string SubGroupType { get { return Parent.SubGroupType; } }

#endregion

#region Static methods

        public static ShopItem FromInventoryItem(GameItem parent, InventoryItem inventoryItem,
                                                 string owner)
        {
            return new ShopItem
                (
                    parent, inventoryItem.ID, inventoryItem.Count, inventoryItem.Quality,
                    inventoryItem.MaxQuality, inventoryItem.IsSingle, float.MaxValue, owner
                );
        }

#endregion

#region Class methods

        public ShopItem() { }

        public ShopItem(GameItem parent, string id, int count, float quality,
            float maxQuality, bool isSingle, float cost, string owner)
        {
            Parent = parent;
            ID = id;
            Count = count;
            Quality = quality;
            MaxQuality = maxQuality;
            IsSingle = isSingle;
            Cost = cost;
            Owner = owner;
        }

        public bool IsOwnItem(string userName)
        {
            return userName.Equals(Owner, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} [{2}x{3}]", Text, Modification, Count, Cost);
        }

#endregion

    }
}
