using System.ComponentModel;

namespace TimeZero.Auction.Bot.Classes.Game.InventoryItems
{
    public sealed class InventoryItem
    {

#region Properties

        [Category("Common settings"), ReadOnly(true)]
        public string ID { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public string SubGroupID { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public string SubGroupType { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public string Name { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public string Level { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public int Count { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public float Massa { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public float Quality { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public float MaxQuality { get; set; }

        [Category("Common settings"), DisplayName(@"Total weight"), ReadOnly(true)]
        public float TotalWeight
        {
            get { return Massa * Count; }
        }

        [Browsable(false)]
        public bool IsPublic
        {
            get { return Name.EndsWith("(Public Factory)"); }
        }

        [Browsable(false)]
        public bool IsSingle { get; set; }

        [Browsable(false)]
        public string PureName
        {
            get { return GetItemPureName(Name); }
        }

        [Browsable(false)]
        public string Ident
        {
            get { return GetItemIdent(PureName, SubGroupID, SubGroupType, Level, IsPublic); }
        }

#endregion

#region Static methods

        public static string GetItemPureName(string itemName)
        {
            int tradeMark = itemName.IndexOf(" (");
            return (tradeMark != -1 ? itemName.Remove(tradeMark) : itemName).TrimEnd();
        }

        public static string GetItemIdent(string pureName, string group, string type,
                                          string level, bool isPublic)
        {
            return string.Format("{0}:{1}:{2}:{3}:{4}", pureName, group, type, 
                                 level, isPublic);
        }

#endregion

#region Class methods

        public InventoryItem() { }

        public InventoryItem(string id, string subGroupID, string subGroupType, string name,
                             string level, int count, float massa, float quality,
                             float maxQuality, bool isSingle) : this()
        {
            ID = id;
            SubGroupID = subGroupID;
            SubGroupType = subGroupType;
            Name = name;
            Level = level;
            Count = count;
            Massa = massa;
            Quality = quality;
            MaxQuality = maxQuality;
            IsSingle = isSingle;
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Name, Count);
        }

#endregion

    }
}
