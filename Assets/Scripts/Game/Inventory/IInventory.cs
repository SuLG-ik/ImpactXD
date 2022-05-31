using System;
using System.Data;

namespace Game.Inventory
{
    public interface IInventory
    {
        public Item[] GetList(InventoryMeta.GeneralType? generalType = null);

        public int CountItems(string itemId);

        public bool RemoveItems(string itemId, int count = 1);

        public bool AddItems(string itemId, int count = 1);

        public Item GetItem(string itemId);

        public void RegisterItemUpdateListener(string itemId, OnItemUpdate listener);
        public void UnregisterItemUpdateListener(string itemId, OnItemUpdate listener);
        
        public struct Item
        {
            public InventoryMeta Meta;
            public int Count;

            public Item(InventoryMeta meta, int count)
            {
                Meta = meta;
                Count = count;
            }
        }

        public delegate void OnItemUpdate(Item item);
        
    }
}