using System;
using System.Collections.Generic;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.GameItems;
using TimeZero.Auction.Bot.Classes.Network.Constants;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using TimeZero.Auction.Bot.ClassesInstances;
using System.Xml;
using System.Media;
using TimeZero.Auction.Bot.Classes.Network.Helpers;
using TimeZero.Auction.Bot.Classes.Game.InventoryItems;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameStep_Shopping : IActionStep
    {

#region Constants

        private const int SHOPPING_DELAY_SEC       = 600 ; //In seconds, 10 min
        private const int SHOPPING_FULL_UPDATE_MIN = 60  ; //In minutes, 1 hour

#endregion

#region Private fields

        private int _prewShoppingnTime;
        private int _prewFullUpdateTime;
        private GameItemsGroupList _gameItemsGroups;
        private readonly Dictionary<string, List<Packet>> _cachedGroupPages =
            new Dictionary<string, List<Packet>>();
        private readonly SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.buy_item);

#endregion

#region Properties

        public bool IsReadyForAction
        {
            get
            {
                int curTickCount = Environment.TickCount;
                return _prewShoppingnTime == 0 || curTickCount - _prewShoppingnTime >= SHOPPING_DELAY_SEC * 1000;
            }
        }

#endregion

#region Class methods

        private void InstantBuyItem(NetworkClient networkClient, GameClient client,
            string groupId, int groupPage, XmlNode item, GameItem gameItem)
        {
            if (item != null && item.Attributes != null)
            {
                XmlAttribute cost = item.Attributes["cost"];
                XmlAttribute made = item.Attributes["made"];
                if (cost != null && (made == null || made.InnerText != "Public Factory"))
                {
                    float qualityMdf = 1f;
                    float fCost = float.Parse(cost.InnerText);

                    //If InstantPurchaseCost isn`t very low, take into an item quality
                    if (gameItem.FactoryCost > 0 && gameItem.InstantPurchaseCost > 0 &&
                        gameItem.FactoryCost / gameItem.InstantPurchaseCost > 10f)
                    {
                        XmlAttribute quality = item.Attributes["quality"];
                        XmlAttribute maxQuality = item.Attributes["maxquality"];
                        if (quality != null && maxQuality != null)
                        {
                            float fQuality = float.Parse(quality.InnerText);
                            float fMaxQuality = float.Parse(maxQuality.InnerText);
                            qualityMdf = fQuality / fMaxQuality;
                        }
                    }

                    //If an item cost is lower than InstantPurchaseCost, let`s try to buy the item
                    if (fCost <= gameItem.InstantPurchaseCost * qualityMdf)
                    {
                        XmlAttribute id = item.Attributes["id"];
                        XmlAttribute count = item.Attributes["count"];
                        if (id != null && count != null)
                        {
                            string sId = id.InnerText;
                            int iCount = int.Parse(count.InnerText);

                            //Out log message
                            int totalCost = (int) Math.Ceiling(iCount * fCost);
                            string groupName = _gameItemsGroups[groupId].Name;
                            string message = 
                                string.Format("Trying to buy: {0}, group: {1}, page: {2}, count: {3}, cost: {4}, total cost: {5}...",
                                gameItem, groupName, groupPage + 1, iCount, fCost, totalCost);
                            networkClient.SendLogMessage(message);

                            //Try to buy the item
                            //Query params: 1: item ID, 2: count, 3: cost
                            string getGroupsItemsList = Packet.BuildPacket(FromClient.SHOP,
                                Shop.ITEMS_BUY, sId, iCount, fCost);
                            networkClient.SendData(getGroupsItemsList);

                            //Get a purchase result
                            string[] packetTypes = new[] {FromServer.ITEM_ADD_ONE, FromServer.SHOP_ERROR};
                            Packet purchaseResult = networkClient.InputQueue.PopAny(packetTypes);

                            //Check the purchase result
                            if (purchaseResult != null)
                            {
                                switch (purchaseResult.Type)
                                {
                                    //Purchasing is failed
                                    case FromServer.SHOP_ERROR:
                                        {
                                            string errorCode = purchaseResult["@code"];
                                            string errorMessage = Errors.ShopError.GetErrorMessage(errorCode);
                                            networkClient.ThrowError(errorMessage, false);
                                            break;
                                        }
                                    //Successful
                                    default:
                                        {
                                            //Add the item to the inventory or, if it`s bad, out log message
                                            InventoryItem inventoryItem = Helper.ParseInventoryItem(purchaseResult.Data);
                                            if (inventoryItem != null)
                                            {
                                                //Add inventory item record
                                                client.InventoryItems.Add(inventoryItem);

                                                //Join inventory items
                                                GameStep_JoinInventory.DoJoin(networkClient, client);
                                            }
                                            else
                                            {
                                                string errorMessage = string.Format("BUY: BAD INVENTORY ITEM: {0}", 
                                                    purchaseResult.Data);
                                                networkClient.ThrowError(errorMessage);
                                            }

                                            //Play alert
                                            _soundPlayer.Play();

                                            //Out log message
                                            networkClient.SendLogMessage("Successful");
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ProcessItem(NetworkClient networkClient, GameClient client, 
            string groupId, int groupPage, string subGroupId, string subGroupName,
            string subGroupType, string subGroupLevel, XmlNode item)
        {
            //If it`s valid node
            if (item.Attributes != null)
            {
                XmlAttribute txt = item.Attributes["txt"];
                XmlAttribute lvl = item.Attributes["lvl"];
                if (txt != null)
                {
                    //Get item data
                    string sTxt;
                    switch (groupId)
                    {
                        case GameItemsGroupID.PLANT_PACKS:
                            {
                                XmlNode txtNode = item.SelectSingleNode("O/@txt");
                                sTxt = txtNode != null
                                           ? string.Format("{0} {1}", subGroupName,
                                                           GameItem.GetModificationString(txtNode.InnerText)).TrimEnd()
                                           : subGroupName;
                                break;
                            }
                        default:
                            {
                                sTxt = txt.InnerText;
                                break;
                            }
                    }
                    string sLvl = lvl != null ? lvl.InnerText : "";

                    //Get item or create new one
                    GameItem gameItem = _gameItemsGroups.GetItem(groupId, subGroupId, subGroupType,
                                                                 sTxt, sLvl);
                    if (gameItem == null && item.Attributes != null)
                    {
                        XmlAttribute massa = item.Attributes["massa"];
                        float fMassa = massa == null ? 0 : float.Parse(massa.InnerText);
                        gameItem = _gameItemsGroups.AddItem(groupId, subGroupId, subGroupType,
                            subGroupName, subGroupLevel, sTxt, sLvl, fMassa);
                    }

                    //Process game item
                    if (gameItem != null && !gameItem.IgnoreForShopping && item.Attributes != null)
                    {
                        //Get maxcost
                        XmlAttribute maxCost = item.Attributes["max_p"];
                        if (maxCost != null && !string.IsNullOrEmpty(maxCost.InnerText))
                        {
                            gameItem.FactoryCost = float.Parse(maxCost.InnerText);
                        }

                        //Instant buy the item
                        InstantBuyItem(networkClient, client, groupId, groupPage, item, gameItem);
                    }
                }
            }
        }

        private void ProcessItemsList(NetworkClient networkClient, GameClient client,
            string groupId, int groupPage, string subGroupId, string subGroupName, 
            string subGroupType, string subGroupLevel, Packet itemsList)
        {
            //Get all nodes of items
            XmlNodeList items = itemsList.GetNodes("O");
            if (items != null)
            {
                //For each node of items
                foreach (XmlNode item in items)
                {
                    ProcessItem(networkClient, client, groupId, groupPage, subGroupId,
                                subGroupName, subGroupType, subGroupLevel, item);
                }
            }
        }

        private void ProcessSubGroupsList(NetworkClient networkClient, GameClient client,
            string groupId, int groupPage, bool isAuction, Packet groups, 
            List<string> subGroupsOrderList)
        {
            //Get all subgroups nodes
            XmlNodeList itemsAndSubGroups = groups.GetNodes("O");
            if (itemsAndSubGroups != null)
            {
                //For each subgroup node
                foreach (XmlNode itemOrSubGroup in itemsAndSubGroups)
                {
                    //If it`s valid node
                    if (itemOrSubGroup.Attributes != null)
                    {
                        XmlAttribute name;
                        switch (groupId)
                        {
                            case GameItemsGroupID.PLANT_PACKS:
                                name = itemOrSubGroup.Attributes["namef"];
                                break;
                            case GameItemsGroupID.DOCUMENTS:
                                name = itemOrSubGroup.Attributes["namef"] ??
                                       itemOrSubGroup.Attributes["name"];
                                break;
                            default:
                                name = itemOrSubGroup.Attributes["name"];
                                break;
                        }

                        XmlAttribute type = itemOrSubGroup.Attributes["type"];

                        //If the node doesn`t have own name, ignore this node
                        if (name == null || type == null)
                        {
                            continue;
                        }

                        string subGroupId = name.InnerText;
                        string subGroupType = type.InnerText.Replace(".", "");

                        //Store subgroup->group relation
                        _gameItemsGroups.StoreSubGroupIDToGroupRelation(groupId, subGroupId, subGroupType);

                        //If we in the full processing mode (subGroupsOrderList != null), 
                        //groupId should be stored in the appropriate list
                        if (subGroupsOrderList != null)
                        {
                            string ident = GameItemsSubGroup.GetSubGroupIdent(subGroupId, subGroupType);
                            subGroupsOrderList.Add(ident);
                        }

                        //Is this a subgroup of items?
                        XmlAttribute auc = itemOrSubGroup.Attributes["auc"];
                        if (auc != null)
                        {
                            //Check IgnoreForShopping flag
                            GameItemsSubGroup subGroup = _gameItemsGroups[groupId].GetSubGroup(subGroupId, subGroupType);
                            if (subGroup != null && subGroup.IgnoreForShopping)
                            {
                                continue;
                            }

                            //okay, now go inside the subgroup
                            XmlAttribute lvl = itemOrSubGroup.Attributes["lvl"];
                            XmlAttribute txt = itemOrSubGroup.Attributes["txt"];

                            //Verify parameters 
                            if (txt != null)
                            {
                                string subGroupName = GameItem.GetPureItemText(txt.InnerText);
                                string subGroupLevel = lvl != null ? lvl.InnerText : "";

                                //There is one page available at least
                                int pagesCount = 1;

                                //For each page of items
                                for (int subGroupPage = 0; subGroupPage < pagesCount; subGroupPage++)
                                {
                                    //Make the filter string
                                    string filter = string.Format(@"name:{0},type:{1},lvl:{2}",
                                        subGroupId, subGroupType, subGroupLevel);

                                    //Get items list
                                    //Query params: 1: item group ID, 2: filter, 3: page number, 4: is auction?
                                    string getGroupsItemsListQuery = Packet.BuildPacket(FromClient.SHOP,
                                        Shop.ITEMS_GET_LIST, groupId, filter, subGroupPage,
                                        isAuction);
                                    networkClient.SendData(getGroupsItemsListQuery);

                                    //Get items list
                                    Packet groupItemsList = networkClient.InputQueue.Pop(FromServer.SHOP_DATA);

                                    if (groupItemsList != null)
                                    {
                                        //Calculate pages count or set according to ShopPagesLimit value
                                        if (subGroupPage == 0)
                                        {
                                            if (subGroup == null || subGroup.ShopPagesLimit == 0)
                                            {
                                                int itemsCount = int.Parse(groupItemsList["@m"]);
                                                pagesCount = itemsCount / 8 + (itemsCount % 8 > 0 ? 1 : 0);
                                            }
                                            else
                                            {
                                                pagesCount = subGroup.ShopPagesLimit;
                                            }
                                        }

                                        //Process items list
                                        ProcessItemsList(networkClient, client, groupId, groupPage, subGroupId,
                                            subGroupName, subGroupType, subGroupLevel, groupItemsList);
                                    }
                                }
                            }
                        }

                        //otherwise let`s process standalone item
                        else
                        {
                            //Check IgnoreForShopping flag
                            GameItemsSubGroup subGroup = _gameItemsGroups[groupId].GetSubGroup(subGroupId, subGroupType);
                            if (subGroup != null && subGroup.IgnoreForShopping)
                            {
                                continue;
                            }

                            XmlAttribute txt = itemOrSubGroup.Attributes["txt"];
                            XmlAttribute lvl = itemOrSubGroup.Attributes["lvl"];

                            //Verify parameters
                            if (txt != null)
                            {
                                string subGroupName = GameItem.GetPureItemText(txt.InnerText);
                                string subGroupLevel = lvl != null ? lvl.InnerText : "";

                                //Process item
                                ProcessItem(networkClient, client, groupId, 0, subGroupId, subGroupName, 
                                            subGroupType, subGroupLevel, itemOrSubGroup);
                            }
                        }
                    }
                }
            }
        }

        private void ProcessGroupPagesFull(NetworkClient networkClient, GameClient client,
            string locationIdent, bool isAuction, IEnumerable<KeyValuePair<string, string>> fullList)
        {
            //For all items groups...
            foreach (KeyValuePair<string, string> item in fullList)
            {
                //Get group ID
                string groupId = item.Key;

                //Ignore for shopping?
                GameItemsGroup group = _gameItemsGroups[groupId];
                if (group == null || group.IgnoreForShopping)
                {
                    continue;
                }

                //If number of items is more than 0
                if (int.Parse(item.Value) > 0)
                {
                    List<string> subGroupsOrderList = new List<string>();

                    //Get cached group page ident
                    string cachedGroupPageIdent = GetCachedGroupPageIdent(locationIdent, groupId);

                    //Get cached group pages
                    List<Packet> cachedGroupPages;
                    if (!_cachedGroupPages.ContainsKey(cachedGroupPageIdent))
                    {
                        cachedGroupPages = new List<Packet>();
                        _cachedGroupPages.Add(cachedGroupPageIdent, cachedGroupPages);
                    }
                    else
                    {
                        cachedGroupPages = _cachedGroupPages[cachedGroupPageIdent];
                    }

                    //There is one page available at least
                    int pagesCount = 1;

                    //For each page of group
                    for (int groupPage = 0; groupPage < pagesCount; groupPage++)
                    {
                        //Query page[i] of group
                        //Query params: 1: group ID, 2: filter, 3: page number, 4: is auction?
                        string getGroupPagesList = Packet.BuildPacket(FromClient.SHOP,
                            Shop.ITEMS_GET_LIST, groupId, string.Empty, groupPage,
                            isAuction);
                        networkClient.SendData(getGroupPagesList);

                        //Get group page
                        Packet groups = networkClient.InputQueue.Pop(FromServer.SHOP_DATA);

                        if (groups != null)
                        {
                            //Calculate pages count
                            if (groupPage == 0)
                            {
                                int cnt = int.Parse(groups["@m"]);
                                pagesCount = cnt / 8 + (cnt % 8 > 0 ? 1 : 0);
                            }

                            //Process items list
                            ProcessSubGroupsList(networkClient, client, groupId, groupPage, isAuction,
                                                 groups, subGroupsOrderList);

                            //Store cached group page
                            cachedGroupPages.Add(groups);
                        }
                    }

                    //Reorder subgroups
                    group.ReorderSubGroups(subGroupsOrderList);
                }
            }
        }

        private string GetCachedGroupPageIdent(string locationIdent, string groupId)
        {
            //Format: locationIdent: + groupId
            return string.Format("{0}:{1}", locationIdent, groupId);
        }

        private void ProcessGroupPagesFromCache(NetworkClient networkClient, GameClient client,
            string locationIdent, bool isAuction, GameItemsGroup gameItemsGroup)
        {
            string groupId = gameItemsGroup.ID;
            string cachedGroupPageIdent = GetCachedGroupPageIdent(locationIdent, groupId);

            //If group pages were cached for the location
            if (_cachedGroupPages.ContainsKey(cachedGroupPageIdent))
            {
                //Get cached group pages
                List<Packet> cachedGroupPages = _cachedGroupPages[cachedGroupPageIdent];

                //For each cached page of group
                int pagesCount = cachedGroupPages.Count;
                for (int groupPage = 0; groupPage < pagesCount; groupPage++)
                {
                    Packet groups = cachedGroupPages[groupPage];
                    ProcessSubGroupsList(networkClient, client, groupId, groupPage, isAuction,
                                         groups, null);
                }
            }
        }

        private void DoShopping(NetworkClient networkClient, GameClient client, 
            string locationIdent, bool isAuction, bool fullUpdate)
        {
            //Full update
            if (fullUpdate)
            {
                //Clear all of cached group pages
                _cachedGroupPages.Clear();

                //Clear all SubGroupIDToGroup relations
                _gameItemsGroups.ClearSubGroupToGroupIDList();

                //Send: get full groups list
                string getFullGroupsList = Packet.BuildPacket(FromClient.SHOP, 
                    Shop.ITEMS_GET_FULL);
                networkClient.SendData(getFullGroupsList);

                //Get response
                Packet fullGroupsList = networkClient.InputQueue.Pop(FromServer.SHOP_DATA);

                if (fullGroupsList != null)
                {
                    //Populate items list, full1: [groupId, itemsNum]
                    string full = fullGroupsList.GetValue("@full");
                    IEnumerable<KeyValuePair<string, string>> fullList = Helper.SplitStringItems(full, ":", ",");

                    //Process all items
                    ProcessGroupPagesFull(networkClient, client, locationIdent, isAuction, fullList);
                }
            }

            //or lets use cached group pages
            else
            {
                //Process every cached group
                foreach (GameItemsGroup group in _gameItemsGroups.Groups)
                {
                    if (!group.IgnoreForShopping)
                    {
                        ProcessGroupPagesFromCache(networkClient, client, locationIdent, isAuction, group);
                    }
                }
            }
        }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            if (IsReadyForAction)
            {
                _gameItemsGroups = Instance.GameItemsGroups;
                DateTime startShoppingTime = DateTime.Now;

                //Check full update requirement
                bool fullUpdate = _prewFullUpdateTime == 0 || 
                     Environment.TickCount - _prewFullUpdateTime >= SHOPPING_FULL_UPDATE_MIN * 60000;

                //Get location ident
                string locationIdent = Helper.GetCurrentLocationIdent(client);

                //Check on shop
                bool isShop = Locations.Shops.Contains(locationIdent);

                //Check on auction
                bool isAuction = Locations.Auctions.Contains(locationIdent);

                //Out action message
                string message = string.Format(@"started, {0}
    • in a shop: {1}
    • is it an auction: {2}
    • full update: {3}
", DateTime.Now, 
   isShop ? "YES" : "NO", 
   isAuction ? "YES" : "NO",
   fullUpdate ? "YES" : "NO").TrimEnd();
                networkClient.SendActionLogMessage(this, message);

                //Current location must be a shop, check it
                if (isShop)
                {
                    //Make a little shopping :)
                    DoShopping(networkClient, client, locationIdent, isAuction, fullUpdate);
                }
                else
                {
                    //Out action message
                    message = "You are not inside a shop. Shopping unavailable.";
                    networkClient.SendActionLogMessage(this, message);                    
                }

                //Store last time of full update
                _prewShoppingnTime = Environment.TickCount;
                if (fullUpdate)
                {
                    _prewFullUpdateTime = _prewShoppingnTime;
                }

                //Out action message
                string shoppingTime = DateTime.Now.Subtract(startShoppingTime).ToString();
                shoppingTime = shoppingTime.Remove(shoppingTime.IndexOf('.'));
                message = string.Format("completed. Duration: {0}", shoppingTime);
                networkClient.SendActionLogMessage(this, message);  

                return true;
            }

            return false;
        }

        public void Reset() 
        {
            _prewShoppingnTime = 0;
            _prewFullUpdateTime = 0;
        }

#endregion

    }
}
