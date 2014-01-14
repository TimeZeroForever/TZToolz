using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;

namespace TimeZero.Auction.Bot.Classes.Game.GameItems
{
    [Serializable]
    public class GameItem
    {

#region Static private fields

        private static readonly Regex _regexItemModif;

#endregion

#region Private fields

        private string _text;

#endregion

#region Properties

        [Category("Common settings"), ReadOnly(true)]
        public string Modification { get; set; }

        [Category("Common settings"), DisplayName(@"Required level"), ReadOnly(true)]
        public string Level { get; set; }

        [Category("Common settings"), ReadOnly(true)]
        public float Massa { get; set; }

        [Category("Common settings"), DisplayName(@"Name"), ReadOnly(true)]
        public string Text
        {
            get { return _text; }
            set
            {
                Modification = GetModificationString(value);
                _text = GetPureItemText(value, Modification);
            }
        }

        [Category("Shopping"), DisplayName(@"Factory cost"), ReadOnly(true)]
        public float FactoryCost { get; set; }

        [Category("Shopping"), DisplayName(@"Instant purchase cost")]
        public float InstantPurchaseCost { get; set; }

        [Category("Shopping"), DisplayName(@"Ignore for shopping")]
        public bool IgnoreForShopping { get; set; }

        [Category("Selling"), DisplayName(@"Ignore for selling")]
        public bool IgnoreForSelling { get; set; }

        [Browsable(false)]
        public string Ident
        {
            get { return GetItemIdent(Text, Modification, Level); }
        }

        [Browsable(false)]
        public string SubGroupID { get; set; }

        [Browsable(false)]
        public string SubGroupType { get; set; }

        [Browsable(false)]
        public bool HasReviewed { get; set; }

        [Browsable(false)]
        public DateTime LastReviewDate { get; set; }

#endregion

#region Static methods

        static GameItem()
        {
            Type type = typeof(GameItemModificationType);
            IEnumerable<FieldInfo> fieldInfo = type.GetFields(BindingFlags.Public |
                                                              BindingFlags.Static).
                Where(fi => fi.IsLiteral && !fi.IsInitOnly);
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo fi in fieldInfo)
            {
                if (sb.Length > 0)
                {
                    sb.Append('|');
                }
                sb.Append(fi.GetValue(null));
            }
            string expr = string.Format("(?<=^(.(?!\\())+? )({0})(?= |$)", sb);
            _regexItemModif = new Regex(expr);
        }

        public static string GetModificationString(string itemText)
        {
            string modification = string.Empty;
            Match match = _regexItemModif.Match(itemText ?? string.Empty);
            bool addSpace = false;
            while (match.Success)
            {
                modification = string.Format("{0}{1}{2}", modification,
                     addSpace ? " " : "", match.Value);
                match = match.NextMatch();
                addSpace = true;
            }
            return modification;
        }

        public static string GetPureItemText(string itemText)
        {
            string modification = GetModificationString(itemText);
            int tradeMark = !string.IsNullOrEmpty(modification)
                ? itemText.IndexOf(modification)
                : itemText.IndexOf(" (");
            return (tradeMark != -1 ? itemText.Remove(tradeMark) : itemText).TrimEnd();
        }

        public static string GetPureItemText(string itemText, string modification)
        {
            int tradeMark = !string.IsNullOrEmpty(modification)
                ? itemText.IndexOf(modification)
                : itemText.IndexOf(" (");
            return (tradeMark != -1 ? itemText.Remove(tradeMark) : itemText).TrimEnd();
        }

        public static string GetItemIdent(string itemText, string modification, string level)
        {
            return string.Format("{0}:{1}:{2}", itemText, modification, level);
        }

#endregion

#region Class methods

        public GameItem() 
        {
            LastReviewDate = DateTime.Now;
        }

        public GameItem(string text, string modification, string level, float massa,
            string subGroupID, string subGroupType) : this()
        {
            _text = text;
            Modification = modification;
            Level = level;
            Massa = massa;
            SubGroupID = subGroupID;
            SubGroupType = subGroupType;
        }

        public GameItem(string text, string level, float massa, string subGroupID, 
                        string subGroupType) : this()
        {
            Text = text;
            Level = level;
            Massa = massa;
            SubGroupID = subGroupID;
            SubGroupType = subGroupType;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Text, Modification).TrimEnd();
        }

#endregion

    }
}
