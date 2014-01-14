using System;
using System.Collections.Generic;
using System.Linq;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.GameItems;
using TimeZero.Auction.Bot.ClassesInstances;
using TimeZero.Auction.Bot.Classes.Network.Helpers;
using TimeZero.Auction.Bot.Classes.Network.Constants;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;
using System.Xml;
using TimeZero.Auction.Bot.Classes.Game.ShopItems;
using TimeZero.Auction.Bot.Classes.Game.InventoryItems;
using System.Media;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameStep_Selling : IActionStep
    {

#region Constants

        private const int SELLING_DELAY_SEC = 600; //In seconds, 10 min

#endregion

#region Private fields

        private int _prewSellingTime;
        private GameItemsGroupList _gameItemsGroups;
        private readonly Dictionary<string, List<ShopItem>> _auctionItems = 
            new Dictionary<string, List<ShopItem>>();
        private readonly SoundPlayer _soundPlayer = new SoundPlayer(Properties.Resources.sell_item);

#endregion

#region Properties

        public bool IsReadyForAction
        {
            get
            {
                int curTickCount = Environment.TickCount;
                return _prewSellingTime == 0 || curTickCount - _prewSellingTime >= SELLING_DELAY_SEC * 1000;
            }
        }

#endregion

#region Class methods

        private void CacheAuctionItems(NetworkClient networkClient, string groupId, 
            string subGroupId, string type, string level)
        {
            if (!_auctionItems.ContainsKey(subGroupId))
            {
                List<ShopItem> shopItems = new List<ShopItem>();
                _auctionItems.Add(subGroupId, shopItems);

                //There is one page available at least
                int pagesCount = 1;

                //For each page of items
                for (int subGroupPage = 0; subGroupPage < pagesCount; subGroupPage++)
                {
                    //Make the filter string
                    string filter = string.Format(@"name:{0},type:{1},lvl:{2}",
                        subGroupId, type, level == "" ? "0" : level);

                    //Get items list
                    //Query params: 1: item group ID, 2: filter, 3: page number, 4: is auction?
                    string getGroupsItemsListQuery = Packet.BuildPacket(FromClient.SHOP,
                        Shop.ITEMS_GET_LIST, groupId, filter, subGroupPage,
                        true);
                    networkClient.SendData(getGroupsItemsListQuery);

                    //Get items list
                    Packet itemsList = networkClient.InputQueue.Pop(FromServer.SHOP_DATA);

                    if (itemsList != null)
                    {
                        //Calculate pages count
                        if (subGroupPage == 0)
                        {
                            int itemsCount = int.Parse(itemsList["@m"]);
                            pagesCount = itemsCount / 8 + (itemsCount % 8 > 0 ? 1 : 0);
                        }

                        //Get all items
                        XmlNodeList items = itemsList.GetNodes("O");
                        if (items != null)
                        {
                            foreach (XmlNode item in items)
                            {
                                //Create new my shop item
                                ShopItem shopItem = Helper.ParseShopItem(item, _gameItemsGroups);
                                if (shopItem != null)
                                {
                                    shopItems.Add(shopItem);
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool GetOwnItem(NetworkClient networkClient, GameClient client,
                                ShopItem shopItem)
        {
            string message = string.Format("Trying to get: '{0}'...", shopItem.Parent);
            networkClient.OutLogMessage(message);

            //Try to get the item
            //Query params: 1: item ID
            string getGroupsItemsList = Packet.BuildPacket(FromClient.SHOP,
                Shop.ITEM_GET_OWN, shopItem.ID);
            networkClient.SendData(getGroupsItemsList);

            //Get a result
            string[] packetTypes = new[] { FromServer.ITEM_ADD_ONE, FromServer.SHOP_ERROR };
            Packet getResult = networkClient.InputQueue.PopAny(packetTypes);

            //Check the result
            if (getResult != null)
            {
                switch (getResult.Type)
                {
                    //Getting is failed
                    case FromServer.SHOP_ERROR:
                        {
                            string errorCode = getResult["@code"];
                            string errorMessage = Errors.ShopError.GetErrorMessage(errorCode);
                            networkClient.ThrowError(errorMessage, false);
                            break;
                        }
                    //Successful
                    default:
                        {
                            //Add the item to the inventory or, if it`s bad, out log message
                            InventoryItem inventoryItem = Helper.ParseInventoryItem(getResult.Data);
                            if (inventoryItem != null)
                            {
                                //Add the item to inventory
                                client.InventoryItems.Add(inventoryItem);

                                //Join inventory items
                                GameStep_JoinInventory.DoJoin(networkClient, client);

                                //Out log message
                                networkClient.OutLogMessage("Successful");

                                //Done
                                return true;
                            }
                            string errorMessage = string.Format("GET OWN ITEM: BAD INVENTORY ITEM: {0}", getResult.Data);
                            networkClient.ThrowError(errorMessage);
                            break;
                        }
                }
            }

            return false;
        }

        private void SellItem(NetworkClient networkClient, GameClient client,
                              string itemID, string itemName, int itemCount, 
                              float cost, bool isSingleItem)
        {
            string sellItem = isSingleItem
                ? Packet.BuildPacket(FromClient.SHOP, Shop.ITEM_SELL,
                                    itemID, cost)
                : Packet.BuildPacket(FromClient.SHOP, Shop.ITEM_SELL,
                                    itemID, cost, itemCount);
            networkClient.SendData(sellItem);

            string message = string.Format("Trying to sell: '{0}', cost: {1}, count: {2}...",
                                           itemName, cost, itemCount);
            networkClient.OutLogMessage(message);

            //Get a result
            string[] packetTypes = new[] { FromServer.SHOP_OK, FromServer.SHOP_ERROR };
            Packet getResult = networkClient.InputQueue.PopAny(packetTypes);

            //Check the result
            if (getResult != null)
            {
                switch (getResult.Type)
                {
                    //Selling is failed
                    case FromServer.SHOP_ERROR:
                        {
                            string errorCode = getResult["@code"];
                            string errorMessage = Errors.ShopError.GetErrorMessage(errorCode);
                            networkClient.ThrowError(errorMessage, false);
                            break;
                        }
                    //Done
                    default:
                        {
                            //Remove the item from inventory
                            InventoryItem inventoryItem = client.InventoryItems.Find(ii => ii.ID == itemID);
                            if (inventoryItem != null)
                            {
                                client.InventoryItems.Remove(inventoryItem);
                            }

                            //Play alert
                            _soundPlayer.Play();

                            //Out log message
                            networkClient.OutLogMessage("Successful");
                            break;
                        }
                }
            }
        }

        private bool AssertAntidumping(ShopItem shopItem, ShopItem[] shopItems)
        {
            int nextItemIdx = Array.IndexOf(shopItems, shopItem) + 1;
            if (nextItemIdx < shopItems.Length)
            {
                ShopItem nextItem = shopItems[nextItemIdx];
                float costDiff = nextItem.Cost - shopItem.Cost;

                if ((shopItem.Cost <= 0.4f && costDiff >= 0.05f) ||
                    (shopItem.Cost <= 0.9f && costDiff >= 0.1f ) ||
                    (shopItem.Cost <= 5    && costDiff >= 0.5f ) ||
                    (shopItem.Cost <= 15   && costDiff >= 1f   ) ||
                    (shopItem.Cost <= 30   && costDiff >= 2f   ) ||
                    (shopItem.Cost <= 100  && costDiff >= 3f   ) ||
                    (shopItem.Cost <= 200  && costDiff >= 4f   ) ||
                    (shopItem.Cost <= 500  && costDiff >= 10f  ) ||
                    (shopItem.Cost <= 999  && costDiff >= 20f) )
                {
                    return false;
                }
            }
            return true;
        }

        private float CalculateItemCost(GameClient client, ShopItem myItem, 
                                        ShopItem[] shopItems)
        {
            //Get basic item cost
            float cost = myItem.FactoryCost > 0f
                ? (int)myItem.FactoryCost * 1.5f
                : 0f;

            //Last shop item with a lower quality
            ShopItem lqShopItem;

            foreach (ShopItem shopItem in shopItems)
            {
                //Detect "antidumping"
                if (!AssertAntidumping(shopItem, shopItems))
                {
                    continue;
                }

                if (!myItem.IsSingle)
                {
                    if (shopItem.IsOwnItem(client.Login))
                    {
                        if (myItem.ID == shopItem.ID)
                        {
                            return 0f;
                        }
                        continue;
                    }

                    //Calculate subs. value
                    float subsValue = shopItem.Cost <= 50f ? 0.01f : 1f;

                    //Calculate a count ratio
                    double countRatio = myItem.Count / shopItem.Count;

                    //Calculate a shop item cost
                    float shopItemCost = shopItem.Count * shopItem.Cost;

                    //My item is more expensive
                    if (myItem.Cost > shopItem.Cost &&
                        shopItemCost > 100 &&
                        countRatio < 10f)
                    {
                        return shopItem.Cost - subsValue;
                    }

                    //Equal cost
                    if (myItem.Cost == shopItem.Cost)
                    {
                        return countRatio < 1.3f 
                            ? shopItem.Cost - subsValue 
                            : 0f;
                    }

                    //My item is chiper
                    if (myItem.Cost < shopItem.Cost)
                    {
                        cost = countRatio < 1.3f 
                            ? shopItem.Cost - subsValue 
                            : shopItem.Cost;
                        return cost != myItem.Cost ? cost : 0f;
                    }
                }
                else
                {
                    if (shopItem.IsOwnItem(client.Login))
                    {
                        return 0f;
                    }

                    if (shopItem.Quality < myItem.Quality)
                    {
                        continue;
                    }

                    lqShopItem = shopItem;

                    if (lqShopItem.Quality == myItem.Quality)
                    {
                        return lqShopItem.Cost - 1f;
                    }

                    Dictionary<float, List<ShopItem>> dictShopItems = new Dictionary<float, List<ShopItem>>();
                    foreach (ShopItem uniqueShopItem in shopItems)
                    {
                        List<ShopItem> list;
                        if (!dictShopItems.ContainsKey(uniqueShopItem.Quality))
                        {
                            list = new List<ShopItem>();
                            dictShopItems.Add(uniqueShopItem.Quality, list);
                        }
                        else
                        {
                            list = dictShopItems[uniqueShopItem.Quality];
                        }
                        list.Add(uniqueShopItem);
                    }

                    List<ShopItem> resultList = new List<ShopItem>();
                    foreach (List<ShopItem> list in dictShopItems.Values)
                    {
                        int itemsCnt = list.Count;
                        if (itemsCnt >= 3)
                        {
                            int truncNum = (int)Math.Ceiling(itemsCnt * 0.2f);
                            int truncCnt = Math.Max(itemsCnt - (truncNum * 2), 1);
                            resultList.AddRange(list.Skip(truncNum).Take(truncCnt));
                        }
                        else
                        {
                            resultList.AddRange(list);
                        }
                    }

                    if (resultList.Count < 5)
                    {
                        return 0f;
                    }

                    float sumCost = 0f, sumQuality = 0f;
                    foreach (ShopItem resultShopItem in resultList)
                    {
                        sumCost += resultShopItem.Cost;
                        sumQuality += resultShopItem.Quality;
                    }

                    double qualityUnitCost = sumQuality / sumCost;
                    float qualityDiff = lqShopItem.Quality - myItem.Quality;
                    float newCost = lqShopItem.Cost - ((float)qualityUnitCost * qualityDiff);
                    return newCost;
                }
            }

            return cost;
        }

        private void DoDumping(NetworkClient networkClient, GameClient client,
                               ShopItem myItem, bool itemInAuc)
        {
            bool needToSellItem = !itemInAuc;

            //Need to join
            if (itemInAuc && !myItem.IsSingle)
            {
                InventoryItem[] inventoryItem = client.InventoryItems.Where
                    (
                        ii => ii.Ident == myItem.Ident
                    ).ToArray();
                needToSellItem = inventoryItem.Length > 0;
            }

            //Need to dumping
            ShopItem[] shopItems = _auctionItems[myItem.SubGroupID].Where
                (
                    si => si.Ident == myItem.Ident
                ).ToArray();

            needToSellItem |= shopItems.Length > 0;

            if (needToSellItem)
            {
                //Calculate target cost
                float itemCost = CalculateItemCost(client, myItem, shopItems);
                if (itemCost > 0f)
                {
                    //Prevent to sell bla-bla
                    if (!itemInAuc && !myItem.IsSingle &&
                        ((itemCost <= 1f  && myItem.Count <= 100 ) ||
                         (itemCost <= 20f && myItem.Count <= 50  ) ||
                         (itemCost <= 50f && myItem.Count <= 10  )))
                    {
                        return;
                    }

                    string itemID = myItem.ID;
                    string itemName = myItem.Parent.ToString();
                    int itemCount = myItem.Count;

                    //Get the item from auction
                    if (itemInAuc)
                    {
                        if (!GetOwnItem(networkClient, client, myItem))
                        {
                            return;
                        }
                        InventoryItem inventoryItem = client.InventoryItems.FirstOrDefault
                            (
                                ii => ii.ID == myItem.ID
                            );
                        if (inventoryItem == null)
                        {
                            return;
                        }
                        itemID = inventoryItem.ID;
                        itemCount = inventoryItem.Count;
                    }

                    //Don`t sell the item if it`s cost lower than 50
                    if (itemCount > 1 && itemCount * itemCost < 50)
                    {
                        return;
                    }

                    //Sell the item
                    SellItem(networkClient, client, itemID, itemName, itemCount, 
                             itemCost, myItem.IsSingle);
                }
            }
        }

        private void ProcessMyAucItemsList(NetworkClient networkClient, GameClient client, 
                                           Packet itemsList)
        {
            //Get all nodes of items
            XmlNodeList items = itemsList.GetNodes("O");
            if (items != null)
            {
                //For each node of items
                foreach (XmlNode item in items)
                {
                    //Create new my shop item
                    ShopItem myItem = Helper.ParseShopItem(item, _gameItemsGroups);

                    //Validate the item
                    if (myItem != null && !string.IsNullOrEmpty(myItem.SubGroupID))
                    {
                        string groupId = _gameItemsGroups.SubGroupToGroupId(myItem.SubGroupID,
                                                                            myItem.SubGroupType);
                        if (!string.IsNullOrEmpty(groupId))
                        {
                            //Get subgroup
                            GameItemsSubGroup sg = _gameItemsGroups[groupId].GetSubGroup(
                                myItem.SubGroupID, myItem.SubGroupType);

                            //Cache items list from auction
                            CacheAuctionItems(networkClient, groupId, myItem.SubGroupID,
                                              sg.Type, sg.Level);

                            //Do dumping
                            DoDumping(networkClient, client, myItem, true);
                        }
                    }
                }
            }
        }

        private void DoSellingItemsFromAuc(NetworkClient networkClient, GameClient client)
        {
            //There is one page available at least
            int pagesCount = 1;

            //For each page of group
            for (int itemsPage = 0; itemsPage < pagesCount; itemsPage++)
            {
                //Query page[i] of group
                //Query params: 1: group ID, 2: filter, 3: page number, 4: is auction?
                string getGroupPagesList = Packet.BuildPacket(FromClient.SHOP,
                    Shop.ITEMS_GET_LIST, GameItemsGroupID.MY_THINGS, "", 
                    itemsPage, true);
                networkClient.SendData(getGroupPagesList);

                //Get items
                Packet itemsList = networkClient.InputQueue.Pop(FromServer.SHOP_DATA);

                if (itemsList != null)
                {
                    //Calculate items pages count
                    if (itemsPage == 0)
                    {
                        int cnt = int.Parse(itemsList["@m"]);
                        pagesCount = cnt / 8 + (cnt % 8 > 0 ? 1 : 0);
                    }

                    //Process items list
                    ProcessMyAucItemsList(networkClient, client, itemsList);
                }
            }
        }

        private void DoSellingItemsFromInv(NetworkClient networkClient, GameClient client)
        {
            List<InventoryItem> clonnedList = new List<InventoryItem>(client.InventoryItems);
            foreach (InventoryItem inventoryItem in clonnedList)
            {
                string subGroupId = inventoryItem.SubGroupID;
                string subGroupType = inventoryItem.SubGroupType;
                string groupId = _gameItemsGroups.SubGroupToGroupId(subGroupId, subGroupType);
                if (!string.IsNullOrEmpty(groupId))
                {
                    GameItem gameItem = _gameItemsGroups.GetItem(groupId, subGroupId,
                        subGroupType, inventoryItem.PureName, inventoryItem.Level);

                    if (gameItem != null && !gameItem.IgnoreForSelling)
                    {
                        if (string.IsNullOrEmpty(gameItem.SubGroupID))
                        {
                            gameItem.SubGroupID = subGroupId;
                        }

                        //Get subgroup
                        GameItemsSubGroup sg = _gameItemsGroups[groupId].GetSubGroup(
                            subGroupId, subGroupType);

                        if (!sg.IgnoreForSelling)
                        {
                            //Cache items list from auction
                            CacheAuctionItems(networkClient, groupId, subGroupId, sg.Type, sg.Level);

                            //Create shop item
                            ShopItem myItem = ShopItem.FromInventoryItem(gameItem, inventoryItem,
                                                                         client.Login);

                            //Do dumping
                            DoDumping(networkClient, client, myItem, false);
                        }
                    }
                }
            }
        }

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            if (IsReadyForAction)
            {
                _gameItemsGroups = Instance.GameItemsGroups;

                //Current location must be quction, check it
                string locationIdent = Helper.GetCurrentLocationIdent(client);
                if (Locations.Auctions.Contains(locationIdent))
                {
                    //Sell items from auc
                    DoSellingItemsFromAuc(networkClient, client);

                    //Sell items from inventory
                    DoSellingItemsFromInv(networkClient, client);
                }

                //Clear auction items cache
                _auctionItems.Clear();

                _prewSellingTime = Environment.TickCount;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _prewSellingTime = 0;
        }

#endregion

    }
}
