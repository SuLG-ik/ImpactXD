using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Inventory
{
    public class InMemoryInventory : IInventory
    {
        private readonly Dictionary<string, IInventory.Item> inventory = new Dictionary<string, IInventory.Item>();

        private readonly Dictionary<string, IInventory.OnItemUpdate> listeners =
            new Dictionary<string, IInventory.OnItemUpdate>();

        private ItemsStorage itemsStorage;

        public InMemoryInventory(ItemsStorage itemsStorage)
        {
            this.itemsStorage = itemsStorage;
        }


        public IInventory.Item[] GetList(InventoryItem.GeneralType? generalType = null)
        {
            if (generalType == null) return inventory.Values.ToArray();
            return inventory.Values.Where((item) => item.Meta.generalType == generalType).ToArray();
        }

        public int CountItems(string itemId)
        {
            var exists = inventory.TryGetValue(itemId, out IInventory.Item item);
            return exists ? item.Count : 0;
        }

        public bool RemoveItems(string itemId, int count = 1)
        {
            var exists = inventory.TryGetValue(itemId, out var item);
            if (!exists || item.Count < count) return false;
            item.Count -= count;
            SendUpdateListener(item);
            inventory[itemId] = item;
            return true;
        }

        public bool AddItems(string itemId, int count = 1)
        {
            var exists = inventory.TryGetValue(itemId, out var item);
            if (!exists)
                item = new IInventory.Item(itemsStorage.GetItem(itemId), count);
            else
                item.Count += count;
            SendUpdateListener(item);
            inventory[itemId] = item;
            return true;
        }

        public IInventory.Item GetItem(string itemId)
        {
            var exists = inventory.TryGetValue(itemId, out var item);
            if (!exists)
            {
                item = new IInventory.Item(itemsStorage.GetItem(itemId), 0);
                inventory[itemId] = item;
            }

            return inventory[itemId];
        }

        public void RegisterItemUpdateListener(string itemId, IInventory.OnItemUpdate listener)
        {
            if (listeners.ContainsKey(itemId))
                listeners[itemId] -= listener;
            else
                listeners[itemId] = listener;
        }

        public void UnregisterItemUpdateListener(string itemId, IInventory.OnItemUpdate listener)
        {
            if (listeners.ContainsKey(itemId))
                listeners[itemId] += listener;
        }

        public void SendUpdateListener(IInventory.Item item)
        {
            listeners.TryGetValue(item.Meta.id, out var listener);
            listener?.Invoke(item);
        }
    }
}