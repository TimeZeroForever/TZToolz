using System.Collections.Generic;
using TimeZero.Auction.Bot.Classes.Game.Client;
using TimeZero.Auction.Bot.Classes.Game.InventoryItems;
using TimeZero.Auction.Bot.Classes.Network.ProtoPacket;

namespace TimeZero.Auction.Bot.Classes.Network.Acitons.Game
{
    public sealed class GameStep_JoinInventory : IActionStep
    {

#region Static methods

        public static bool DoJoin(NetworkClient networkClient, GameClient client)
        {
            Dictionary<string, InventoryItemList> items = new Dictionary<string, InventoryItemList>();

            foreach (InventoryItem inventoryItem in client.InventoryItems)
            {
                //Get the item ident
                string ident = inventoryItem.Ident;
                InventoryItemList inventoryItemsList;

                //Get items list for the item
                if (items.ContainsKey(ident))
                {
                    inventoryItemsList = items[ident];
                }
                else
                {
                    items.Add(ident, inventoryItemsList = new InventoryItemList());
                }

                //Add the item to items list
                inventoryItemsList.Add(inventoryItem);
            }

            //Do join items
            foreach (string ident in items.Keys)
            {
                InventoryItemList inventoryItemsList = items[ident];
                int itemsCount = inventoryItemsList.Count;
                if (itemsCount > 1)
                {
                    InventoryItem item2 = inventoryItemsList[0];
                    for (int i = 1; i < itemsCount; i++)
                    {
                        InventoryItem item1 = inventoryItemsList[i];
                        string joinInventory = Packet.BuildPacket(FromClient.JOIN_INVENTORY,
                            item1.ID, item2.ID);
                        networkClient.SendData(joinInventory);
                        item2.Count += item1.Count;
                        client.InventoryItems.Remove(item1);
                    }
                }
            }

            return true;
        }

#endregion

#region Properties

        public bool IsReadyForAction { get { return !_firstStartJoined; } }

#endregion

#region Private fields

        private bool _firstStartJoined;

#endregion

#region Class methods

        public bool DoStep(NetworkClient networkClient, GameClient client)
        {
            if (IsReadyForAction)
            {
                _firstStartJoined = true;
                return DoJoin(networkClient, client);
            }
            return false;
        }

        public void Reset() { }

#endregion

    }
}
