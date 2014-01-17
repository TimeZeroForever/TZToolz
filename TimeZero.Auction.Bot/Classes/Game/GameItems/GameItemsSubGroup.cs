using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace TimeZero.Auction.Bot.Classes.Game.GameItems
{
    [Serializable]
    public sealed class GameItemsSubGroup
    {

#region Private fields

        private readonly Dictionary<string, GameItem> _gameItems;

#endregion

#region Properties

        [Category("Common settings"), DisplayName(@"ID"), ReadOnly(true)]
        public string ID { get; set; }

        [Category("Common settings"), DisplayName(@"Name"), ReadOnly(true)]
        public string Name { get; set; }

        [Category("Common settings"), DisplayName(@"Type"), ReadOnly(true)]
        public string Type { get; set; }

        [Category("Shopping"), DisplayName(@"Limit of pages to view")]
        public byte ShopPagesLimit { get; set; }

        [Category("Shopping"), DisplayName(@"Ignore for shopping")]
        public bool IgnoreForShopping { get; set; }

        [Category("Selling"), DisplayName(@"Ignore for selling")]
        public bool IgnoreForSelling { get; set; }

        [Browsable(false)]
        public int ItemsCount { get { return _gameItems.Count; } }

        [Browsable(false)]
        public string Level { get; set; }

        [Browsable(false)]
        public string Ident
        {
            get { return GetSubGroupIdent(ID, Type); }
        }

        [Browsable(false)]
        public IEnumerable<GameItem> Items { get { return _gameItems.Values; } }

        [Browsable(false)]
        public GameItem this[string itemIdent] { get { return GetItem(itemIdent); } }

#endregion

#region Static methods

        public static string GetSubGroupIdent(string id, string type)
        {
            return string.Format("{0}:{1}", id, type);
        }

#endregion

#region Class methods

        public GameItemsSubGroup()
        {
            ShopPagesLimit = 1;
            IgnoreForShopping = true;
            _gameItems = new Dictionary<string, GameItem>();
        }

        public GameItemsSubGroup(string id, string type, string name, string level)
            : this()
        {
            ID = id;
            Name = name;
            Type = type;
            Level = level;
        }

        private GameItem GetItemByBrokenIdent(string itemIdent)
        {
            itemIdent = itemIdent.Replace("��", "?").Replace("&amp;", "?");
            int identLength = itemIdent.Length;

            HashSet<string> itemsIdentsWithFirstError = new HashSet<string>();
            List<string> itemsIdents = new List<string>
                (
                    _gameItems.Keys.Where(i => i.Length == identLength)
                );

            if (itemsIdents.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < identLength; i++)
            {
                char srcC = itemIdent[i];
                
                int pairIdx = 0;
                while (pairIdx < itemsIdents.Count)
                {
                    string destIdent = itemsIdents[pairIdx];
                    char destC = destIdent[i];
                    if (destC != srcC)
                    {
                        if (srcC != '?' || itemsIdentsWithFirstError.Contains(destIdent))
                        {
                            itemsIdents.RemoveAt(pairIdx);
                            continue;
                        }
                        itemsIdentsWithFirstError.Add(destIdent);
                    }
                    pairIdx++;
                }
            }

            return itemsIdents.Count > 0 ? _gameItems[itemsIdents[0]] : null;
        }

        public GameItem GetItem(string itemIdent)
        {
            if (!string.IsNullOrEmpty(itemIdent))
            {
                GameItem gameItem = _gameItems.ContainsKey(itemIdent)
                    ? _gameItems[itemIdent]
                    : null;
                if (gameItem == null && 
                    (itemIdent.Contains('�') || itemIdent.Contains("&amp;")))
                {
                    gameItem = GetItemByBrokenIdent(itemIdent);
                }
                return gameItem;
            }
            return null;
        }

        public GameItem GetItem(string itemText, string level)
        {
            string modification = GameItem.GetModificationString(itemText);
            itemText = GameItem.GetPureItemText(itemText, modification);
            string itemIdent = GameItem.GetItemIdent(itemText, modification, level);
            return GetItem(itemIdent);
        }

        public GameItem AddItem(string text, string level, float massa, string subGroupID,
                                string subGroupType)
        {
            GameItem item = new GameItem(text, level, massa, subGroupID, subGroupType);
            return AddItem(item);
        }

        public GameItem AddItem(string text, string modification, string level,
                                float massa, string subGroupID, string subGroupType)
        {
            GameItem item = new GameItem(text, modification, level, massa, 
                                         subGroupID, subGroupType);
            return AddItem(item);
        }

        public GameItem AddItem(GameItem item)
        {
            string itemIdent = item.Ident;
            if (_gameItems.ContainsKey(itemIdent))
            {
                throw new Exception("Item is exists in the group");
            }
            _gameItems.Add(itemIdent, item);
            return item;
        }

        public void RemoveItem(GameItem item)
        {
            if (item != null)
            {
                string ident = item.Ident;
                if (!string.IsNullOrEmpty(ident) && _gameItems.ContainsKey(ident))
                {
                    _gameItems.Remove(ident);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", ID, Name);
        }

#endregion

    }
}
