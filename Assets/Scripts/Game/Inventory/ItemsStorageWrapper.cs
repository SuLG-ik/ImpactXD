using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Inventory
{
    public class ItemsStorageWrapper : MonoBehaviour, ItemsStorage
    {
        [SerializeField] private InventoryMeta[] items;

        public InventoryMeta[] GetItems()
        {
            return items;
        }

        public InventoryMeta GetItem(string itemId)
        {
            return items.First(item => item.id == itemId);
        }
    }
}