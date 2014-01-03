using System;
using System.Collections.Generic;
using System.ComponentModel;
using TimeZero.Auction.Bot.Classes.Common;

namespace TimeZero.Auction.Bot.Classes.Game.GameItems
{
    [Serializable]
    public sealed class GameItemsGroupList
    {

#region Static fields

        public static readonly KeyValuePair<string, string>[] DefaultGroups = new[]
            {
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_COLD,   "Холодное оружие"),
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_PISTOL, "Пистолеты"),
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_RIFLE,  "Винтовки/автоматы"),
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_HEAVY,  "Тяжёлое оружие"),
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_ENERGY, "Энергетическое оружие"),
                new KeyValuePair<string, string>(GameItemsGroupID.WEAPONS_THROW,  "Метательное оружие"),
                new KeyValuePair<string, string>(GameItemsGroupID.COMBAT_DEVICES, "Боевые устройства"),
                new KeyValuePair<string, string>(GameItemsGroupID.AMMO,           "Патроны"),
                new KeyValuePair<string, string>(GameItemsGroupID.ENERGOMODULES,  "Энергомодули"),
                new KeyValuePair<string, string>(GameItemsGroupID.HELMETS,        "Каски/береты"),
                new KeyValuePair<string, string>(GameItemsGroupID.VESTS,          "Куртки/бронежилеты"),
                new KeyValuePair<string, string>(GameItemsGroupID.SLEEVES,        "Нарукавники"),
                new KeyValuePair<string, string>(GameItemsGroupID.TROUSERS,       "Брюки"),
                new KeyValuePair<string, string>(GameItemsGroupID.SHOES,          "Обувь"),
                new KeyValuePair<string, string>(GameItemsGroupID.CIVIL,          "Гражданская одежда"),
                new KeyValuePair<string, string>(GameItemsGroupID.PLANT_PACKS,    "Комплекты"),
                new KeyValuePair<string, string>(GameItemsGroupID.INSERTIONS,     "Встройки"),
                new KeyValuePair<string, string>(GameItemsGroupID.EQUIPMENTS,     "Оборудование"),
                new KeyValuePair<string, string>(GameItemsGroupID.MEDICINES,      "Медицина"),
                new KeyValuePair<string, string>(GameItemsGroupID.RESOURCES,      "Ресурсы"),
                new KeyValuePair<string, string>(GameItemsGroupID.CRAFT_REAGENTS, "Крафт-реагенты"),
                new KeyValuePair<string, string>(GameItemsGroupID.DOCUMENTS,      "Документы"),
                new KeyValuePair<string, string>(GameItemsGroupID.OTHER,          "Прочее"),
                new KeyValuePair<string, string>(GameItemsGroupID.IMPLANTS,       "Импланты"),
            };

#endregion

#region Private fields

        private readonly SerializableDictionary<string, GameItemsGroup> _groups = 
            new SerializableDictionary<string, GameItemsGroup>();

#endregion

#region Properties

        [Browsable(false)]
        public bool Empty { get { return _groups.Count == 0; } }

        [Browsable(false)]
        public IEnumerable<GameItemsGroup> Groups
        {
            get { return _groups.Values; }
        }

        [Browsable(false)]
        public SerializableDictionary<string, string> SubGroupIdentToGroup { get; set; }

        [Browsable(false)]
        public GameItemsGroup this[string id]
        {
            get { return _groups.ContainsKey(id) ? _groups[id] : null; }
        }

#endregion

#region Class methods
            
        public void InitializeDefaults()
        {
            _groups.Clear();
            foreach (KeyValuePair<string, string> groupData in DefaultGroups)
            {
                _groups.Add(groupData.Key, new GameItemsGroup(groupData.Key, groupData.Value));
            }
        }

        public void ClearSubGroupToGroupIDList()
        {
            if (SubGroupIdentToGroup != null)
            {
                SubGroupIdentToGroup.Clear();
            }
        }

        public void StoreSubGroupIDToGroupRelation(string groupId, string subGroupId, 
                                                   string subGroupType)
        {
            if (SubGroupIdentToGroup == null)
            {
                SubGroupIdentToGroup = new SerializableDictionary<string, string>();
            }
            string ident = GameItemsSubGroup.GetSubGroupIdent(subGroupId, subGroupType);
            if (!SubGroupIdentToGroup.ContainsKey(ident))
            {
                SubGroupIdentToGroup.Add(ident, groupId);
            }
        }

        public string SubGroupToGroupId(string subGroupId, string subGroupType)
        {
            if (SubGroupIdentToGroup != null)
            {
                string ident = GameItemsSubGroup.GetSubGroupIdent(subGroupId, subGroupType);
                if (SubGroupIdentToGroup.ContainsKey(ident))
                {
                    return SubGroupIdentToGroup[ident];
                }
            }
            return null;
        }

        public GameItem GetItem(string groupId, string subGroupId, string subGroupType, 
                                string itemText, string level)
        {
            return _groups.ContainsKey(groupId)
                ? _groups[groupId].GetItem(subGroupId, subGroupType, itemText, level)
                : null;
        }

        public GameItem AddItem(string groupId, string subGroupId, string subGroupType,
            string subGroupName, string subGrouplevel, string text, string level, 
            float massa)
        {
            return _groups.ContainsKey(groupId)
                ? _groups[groupId].AddItem(subGroupId, subGroupType, subGroupName, subGrouplevel,
                                           text, level, massa)
                : null;
        }

#endregion

    }
}
