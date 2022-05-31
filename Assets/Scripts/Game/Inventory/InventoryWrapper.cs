using System;
using UnityEngine;

namespace Game.Inventory
{
    public class InventoryWrapper : MonoBehaviour, IInventory
    {
        [SerializeField] private ItemsStorageWrapper itemsStorage;
        private IInventory inMemoryInventory;

        private IInventory GetInMemoryInventory()
        {
            return inMemoryInventory ??= new InMemoryInventory(itemsStorage);
        }
        
        public IInventory.Item[] GetList(InventoryMeta.GeneralType? generalType = null)
        {
            return GetInMemoryInventory().GetList();
        }

        public int CountItems(string itemId)
        {
            return GetInMemoryInventory().CountItems(itemId);
        }

        public bool RemoveItems(string itemId, int count = 1)
        {
            return GetInMemoryInventory().RemoveItems(itemId, count);
        }

        public bool AddItems(string itemId, int count = 1)
        {
            return GetInMemoryInventory().AddItems(itemId, count);
        }

        public IInventory.Item GetItem(string itemId)
        {
            return GetInMemoryInventory().GetItem(itemId);
        }

        public void RegisterItemUpdateListener(string itemId, IInventory.OnItemUpdate listener)
        {
            GetInMemoryInventory().RegisterItemUpdateListener(itemId, listener);
        }

        public void UnregisterItemUpdateListener(string itemId, IInventory.OnItemUpdate listener)
        {
            GetInMemoryInventory().UnregisterItemUpdateListener(itemId, listener);
        }
    }
}