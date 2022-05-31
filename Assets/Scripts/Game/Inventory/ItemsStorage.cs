using System;
using System.Collections.Generic;
using System.Data;

namespace Game.Inventory
{
    public interface ItemsStorage
    {
        public InventoryMeta[] GetItems();
        
        public InventoryMeta GetItem(string itemId);
        
    }
}