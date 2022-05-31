using System;
using System.Data.SqlTypes;
using UnityEngine;

namespace Game.Inventory
{
    [Serializable]
    public struct InventoryMeta
    {
        [SerializeField] public string id;
        [SerializeField] public string title;
        [SerializeField] public Sprite inventoryIcon;
        [SerializeField] public GeneralType generalType;
        [SerializeField] public int startCount;
        
        public enum GeneralType
        {
            Consumables
        }
        
    }
}