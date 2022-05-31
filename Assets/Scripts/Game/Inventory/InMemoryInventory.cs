using System;
using System.Collections.Generic;
using System.Linq;
using Fight.Player.Collection;
using UnityEngine;

namespace Game.Inventory
{
    public class InMemoryInventory : IInventory
    {
        private Dictionary<string, IInventory.Item> inventory;

        private readonly Dictionary<string, IInventory.OnItemUpdate> listeners =
            new Dictionary<string, IInventory.OnItemUpdate>();

        private readonly ItemsStorage itemsStorage;

        private Dictionary<string, IInventory.Item> GetInventory()
        {
            return inventory ??= LoadItems();
        }

        public InMemoryInventory(ItemsStorage itemsStorage)
        {
            this.itemsStorage = itemsStorage;
        }


        public IInventory.Item[] GetList(InventoryMeta.GeneralType? generalType = null)
        {
            if (generalType == null) return GetInventory().Values.ToArray();
            return GetInventory().Values.Where((item) => item.Meta.generalType == generalType).ToArray();
        }

        public int CountItems(string itemId)
        {
            var exists = GetInventory().TryGetValue(itemId, out var item);
            return exists ? item.Count : 0;
        }

        public bool RemoveItems(string itemId, int count = 1)
        {
            var exists = GetInventory().TryGetValue(itemId, out var item);
            if (!exists || item.Count < count) return false;
            item.Count -= count;
            SendUpdateListener(item);
            GetInventory()[itemId] = item;
            SaveItem(item);
            return true;
        }

        public bool AddItems(string itemId, int count = 1)
        {
            var exists = GetInventory().TryGetValue(itemId, out var item);
            if (!exists)
                item = new IInventory.Item(itemsStorage.GetItem(itemId), count);
            else
                item.Count += count;
            SendUpdateListener(item);
            GetInventory()[itemId] = item;
            SaveItem(item);
            return true;
        }

        private IInventory.Item LoadItem(InventoryMeta meta)
        {
            var count = PlayerPrefs.GetInt("inventory_" + meta.id + "_count", meta.startCount);
            return new IInventory.Item(
                meta: meta,
                count: count
            );
        }

        private Dictionary<string, IInventory.Item> LoadItems()
        {
            return itemsStorage.GetItems().ToDictionary(keySelector: meta => meta.id, elementSelector: LoadItem);
        }

        private void SaveItem(IInventory.Item item)
        {
            PlayerPrefs.SetInt("inventory_" + item.Meta.id + "_count", item.Count);
            PlayerPrefs.Save();
        }

        public IInventory.Item GetItem(string itemId)
        {
            var exists = GetInventory().TryGetValue(itemId, out var item);
            if (!exists)
            {
                item = new IInventory.Item(itemsStorage.GetItem(itemId), 0);
                GetInventory()[itemId] = item;
            }

            return GetInventory()[itemId];
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