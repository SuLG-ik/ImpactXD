using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Inventory
{
    public class ItemsStorageWrapper : MonoBehaviour, ItemsStorage
    {
        [SerializeField] private InventoryItem[] items;

        public InventoryItem[] GetItems()
        {
            return items;
        }

        public InventoryItem GetItem(string itemId)
        {
            return items.First(item => item.id == itemId);
        }
    }
}