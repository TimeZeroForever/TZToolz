using TimeZero.Auction.Bot.Classes.Game.InventoryItems;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.ObjectProperties;
using System;
using TimeZero.Auction.Bot.Classes.Game.ShopItems;
using System.Xml;
using TimeZero.Auction.Bot.Classes.Game.GameItems;

namespace TimeZero.Auction.Bot.Classes.Network.Helpers
{
    public static class Helper
    {

#region Shop item

        public static ShopItem ParseShopItem(XmlNode item, GameItemsGroupList gameItemsGroups)
        {
            //If it`s valid node
            if (item.Attributes != null)
            {
                XmlAttribute name = item.Attributes["name"];
                XmlAttribute txt = item.Attributes["txt"];
                XmlAttribute type = item.Attributes["type"];
                XmlAttribute lvl = item.Attributes["lvl"];
                XmlAttribute owner = item.Attributes["owner"];
                if (name != null && txt != null && owner != null)
                {
                    //Get item data
                    string sTxt = txt.InnerText;
                    string subGroupId = name.InnerText;
                    string subGroupType = type.InnerText.Replace(".", "");
                    string sLvl = lvl != null ? lvl.InnerText : "";
                    string groupId = gameItemsGroups.SubGroupToGroupId(subGroupId, subGroupType);
                    string sOwner = owner.InnerText;

                    //Get parent item
                    GameItem gameItem = gameItemsGroups.GetItem(groupId, subGroupId, 
                        subGroupType, sTxt, sLvl);

                    //Process game item
                    if (gameItem != null)
                    {
                        XmlAttribute id = item.Attributes["id"];
                        XmlAttribute count = item.Attributes["count"];
                        XmlAttribute quality = item.Attributes["quality"];
                        XmlAttribute maxQuality = item.Attributes["maxquality"];
                        XmlAttribute cost = item.Attributes["cost"];

                        //Create shop item
                        if (id != null && cost != null)
                        {
                            string sId = id.InnerText;
                            float fCost = float.Parse(cost.InnerText);
                            bool isSingle = count == null;
                            int iCount = !isSingle 
                                ? int.Parse(count.InnerText)
                                : 1;
                            float fQuality = quality != null 
                                ? float.Parse(quality.InnerText) 
                                : 0f;
                            float fMaxQuality = maxQuality != null 
                                ? float.Parse(maxQuality.InnerText) 
                                : 0f;

                            return new ShopItem(gameItem, sId, iCount, fQuality, fMaxQuality,
                                                isSingle, fCost, sOwner);
                        }
                    }
                }
            }
            return null;
        }

#endregion
        
#region Inventory

        private static readonly Regex _regexInventoryItems = new Regex(@"(\x03| E|<ADD_ONE>)(?<ID>[\d.]+)""(?<SUBGROUPID>[\w\d-]+)""[\x07 ](?<NAME>[\w\d&()#-. /]+)"".*?(?= E|/>)");
        private static readonly Regex _regexInventoryAddOne = new Regex(@"<ADD_ONE[>.](?<ID>[\d.]+)""(?<SUBGROUPID>[\w\d-]+)"".(?<NAME>[\w\d&()#-. /]+)(?=(.m[\d]*\.|"")).*?(/>)");

        private static readonly Regex _regexInventoryItemCheck = new Regex(@".(X=""[\d.]+"")+?");
        private static readonly Regex _regexInventoryItemCheckPers = new Regex(@"(?-i).(( X\w"")|dt=""\d+"")+?");

        private static readonly Regex _regexInventoryType = new Regex(@"(?-i).((type=""|A)(?<SUBGROUPTYPE>[\d\.]+)"")+?");
        private static readonly Regex _regexInventoryLevel = new Regex(@".((lvl=""|\.F)(?<LEVEL>\d+)[.""])+?");
        private static readonly Regex _regexInventoryMassa1 = new Regex(@".((massa=""(?<MASSA>[\d.]+)[.""])|.)*");
        private static readonly Regex _regexInventoryMassa2 = new Regex(@".((.m(?<MASSA>[\d.]*)[.""])|.)*");
        private static readonly Regex _regexInventoryCount = new Regex(@".((](?<COUNT>[\d]+)[.""])|.)*");
        private static readonly Regex _regexInventoryQuality = new Regex(@".(((quality=""|l)(?<QUALITY>[\d]+)[.""])|.)*");
        private static readonly Regex _regexInventoryMaxQuality = new Regex(@".(((maxquality=""|n)(?<MAXQUALITY>[\d]+)[.""])|.)*");

        private static InventoryItem ParseInventoryItem(Match matchItem)
        {
            string sName = matchItem.Groups["NAME"].Value;
            if (string.IsNullOrEmpty(sName))
            {
                return null;
            }

            string itemRecord = matchItem.Value;
            if ((_regexInventoryItemCheck.Match(itemRecord).Success &&
                !_regexInventoryItemCheckPers.Match(itemRecord).Success) || sName == "Coins")
            {
                string sId = matchItem.Groups["ID"].Value;
                string sSubGroupID = matchItem.Groups["SUBGROUPID"].Value;

                Match matchData = _regexInventoryType.Match(itemRecord);
                string sSubGroupType = matchData.Groups["SUBGROUPTYPE"].Value.Replace(".", "");

                matchData = _regexInventoryLevel.Match(itemRecord);
                string sLevel = matchData.Groups["LEVEL"].Value;

                float fMassa = 0f;
                matchData = _regexInventoryMassa1.Match(itemRecord);
                if (matchData.Groups["MASSA"].Success)
                {
                    string massa = matchData.Groups["MASSA"].Value;
                    fMassa = float.Parse(massa);
                }
                else
                {
                    matchData = _regexInventoryMassa2.Match(itemRecord);
                    if (matchData.Success)
                    {
                        string massa = matchData.Groups["MASSA"].Value;
                        fMassa = float.Parse("1" + massa);
                    }
                }

                matchData = _regexInventoryQuality.Match(itemRecord);
                string quality = matchData.Groups["QUALITY"].Value;
                float fQuality = !string.IsNullOrEmpty(quality)
                    ? float.Parse(quality)
                    : 0f;

                matchData = _regexInventoryMaxQuality.Match(itemRecord);
                string maxQuality = matchData.Groups["MAXQUALITY"].Value;
                float fMaxQuality = !string.IsNullOrEmpty(maxQuality)
                    ? float.Parse(maxQuality)
                    : 0f;

                matchData = _regexInventoryCount.Match(itemRecord);
                string count = matchData.Groups["COUNT"].Value;
                bool bIsSingle = string.IsNullOrEmpty(count);
                int iCount = !bIsSingle ? int.Parse(count) : 1;

                if (!bIsSingle && 
                    (itemRecord.Contains("calibre=") ||
                     itemRecord.Contains("shot=")))
                {
                    iCount *= 100;
                }

                return new InventoryItem(sId, sSubGroupID, sSubGroupType, sName, 
                    sLevel, iCount, fMassa, fQuality, fMaxQuality, bIsSingle);
            }

            return null;
        }

        public static InventoryItemList ParseInventoryItems(string data)
        {
            data = data.Replace("\x08", "b");
            InventoryItemList inventoryItemList = new InventoryItemList();
            MatchCollection matches = _regexInventoryItems.Matches(data);
            foreach (Match matchItem in matches)
            {
                InventoryItem inventoryItem = ParseInventoryItem(matchItem);
                if (inventoryItem != null)
                {
                    inventoryItemList.Add(inventoryItem);
                }
            }
            return inventoryItemList;
        }

        public static InventoryItem ParseInventoryItem(string data)
        {
            data = data.Replace("\x08", "b");
            Match matchItem = _regexInventoryAddOne.Match(data);
            InventoryItem item = ParseInventoryItem(matchItem);
            if (item == null)
            {
                matchItem = _regexInventoryItems.Match(data);
                item = ParseInventoryItem(matchItem);
            }
            return item;
        }

#endregion

#region Game client

        public static string GetCurrentLocationIdent(GameClient client)
        {
            //Format: X: + Y: + BuildingId
            return (string)client.AdditionalData[ObjectPropertyName.LOCATION_X][0] + ":" +
                   (string)client.AdditionalData[ObjectPropertyName.LOCATION_Y][0] + ":" +
                   (string)client.AdditionalData[ObjectPropertyName.LOCATION_BUILDING][0];
        }

#endregion

#region General

        public static IEnumerable<KeyValuePair<string, string>> SplitStringItems(string data,
            string pairSeparator, string itemsSeparator)
        {
            List<KeyValuePair<string, string>> pairsList = new List<KeyValuePair<string, string>>();
            string[] items = data.Split(new[] { itemsSeparator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                string[] pair = item.Split(new[] { pairSeparator }, StringSplitOptions.None);
                if (pair.Length == 2)
                {
                    pairsList.Add(new KeyValuePair<string, string>(pair[0], pair[1]));
                }
            }
            return pairsList;
        }

        public static string RemoveMilliseconds(string time)
        {
            int dotIdx = time.IndexOf('.');
            return dotIdx > -1 ? time.Remove(dotIdx) : time;
        }

#endregion

    }
}
