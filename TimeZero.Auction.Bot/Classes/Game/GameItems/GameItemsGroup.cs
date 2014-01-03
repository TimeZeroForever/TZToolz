using System;
using System.Collections.Generic;
using System.ComponentModel;
using TimeZero.Auction.Bot.Classes.Common;

namespace TimeZero.Auction.Bot.Classes.Game.GameItems
{
    [Serializable]
    public sealed class GameItemsGroup
    {

#region Private fields

        private SerializableDictionary<string, GameItemsSubGroup> _subGroups;

#endregion

#region Properties

        [Category("Common settings"), DisplayName("ID"), ReadOnly(true)]
        public string ID { get; set; }

        [Category("Common settings"), DisplayName("Name"), ReadOnly(true)]
        public string Name { get; set; }

        [Category("Shopping"), DisplayName(@"Ignore for shopping")]
        public bool IgnoreForShopping { get; set; }

        [Browsable(false)]
        public IEnumerable<GameItemsSubGroup> SubGroups { get { return _subGroups.Values; } }

#endregion

#region Class methods

        public GameItemsGroup()
        {
            _subGroups = new SerializableDictionary<string, GameItemsSubGroup>();
        }

        public GameItemsGroup(string id, string name) : this()
        {
            ID = id;
            Name = name;
        }

        public GameItemsSubGroup GetSubGroup(string id, string type)
        {
            string ident = GameItemsSubGroup.GetSubGroupIdent(id, type);
            return _subGroups.ContainsKey(ident) ? _subGroups[ident] : null;
        }

        public void AddSubGroup(GameItemsSubGroup subGroup)
        {
            _subGroups.Add(subGroup.Ident, subGroup);
        }

        public GameItemsSubGroup AppendSubGroup(string id, string type, string name, 
                                                string level)
        {
            string ident = GameItemsSubGroup.GetSubGroupIdent(id, type);

            if (_subGroups.ContainsKey(ident))
            {
                return _subGroups[ident];
            }

            GameItemsSubGroup subGroup = new GameItemsSubGroup(id, type, name, level);
            _subGroups.Add(ident, subGroup);
            return subGroup;
        }

        public GameItem GetItem(string subGroupId, string subGroupType, string itemText, 
                                string level)
        {
            string ident = GameItemsSubGroup.GetSubGroupIdent(subGroupId, subGroupType);
            return _subGroups.ContainsKey(ident)
                ? _subGroups[ident].GetItem(itemText, level)
                : null;
        }

        public GameItem AddItem(string subGroupId, string subGroupType, string subGroupName,
            string subGrouplevel, string text,  string level, float massa)
        {
            return AppendSubGroup(subGroupId, subGroupType, subGroupName, subGrouplevel).
                   AddItem(text, level, massa, subGroupId, subGroupType);
        }

        public void ClearSubGroups()
        {
            _subGroups.Clear();
        }

        public void RemoveSubGroup(GameItemsSubGroup subGroup)
        {
            if (subGroup != null)
            {
                RemoveSubGroup(subGroup.ID, subGroup.Type);
            }
        }

        public void RemoveSubGroup(string subGroupId, string subGroupType)
        {
            string ident = GameItemsSubGroup.GetSubGroupIdent(subGroupId, subGroupType);
            _subGroups.Remove(ident);
        }

        public void ReorderSubGroups(List<string> subGroupsOrderList)
        {
            SerializableDictionary<string, GameItemsSubGroup> newSubGroups = 
                new SerializableDictionary<string, GameItemsSubGroup>();

            foreach (string ident in subGroupsOrderList)
            {
                if (_subGroups.ContainsKey(ident) && !newSubGroups.ContainsKey(ident)) 
                {
                    GameItemsSubGroup subGroup = _subGroups[ident];
                    newSubGroups.Add(ident, subGroup);
                    _subGroups.Remove(ident);
                }
            }

            foreach (string orphantIdent in _subGroups.Keys)
            {
                if (!newSubGroups.ContainsKey(orphantIdent))
                {
                    GameItemsSubGroup subGroup = _subGroups[orphantIdent];
                    newSubGroups.Add(orphantIdent, subGroup);
                }
            }

            _subGroups = newSubGroups;
            
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", ID, Name);
        }

#endregion

    }
}
