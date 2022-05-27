using System;
using System.Data.SqlTypes;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public struct InventoryItem
    {
        [SerializeField] public string id;
        [SerializeField] public string title;
        [SerializeField] public Sprite inventoryIcon;
        [SerializeField] public GeneralType generalType;
        
        public enum GeneralType
        {
            Consumables
        }
        
    }
}