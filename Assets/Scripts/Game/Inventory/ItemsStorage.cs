using System;
using System.Collections.Generic;
using System.Data;

namespace Game.Inventory
{
    public interface ItemsStorage
    {
        public InventoryItem[] GetItems();
        
        public InventoryItem GetItem(string itemId);
        
    }
}