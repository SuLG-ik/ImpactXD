using System;
using Game.Inventory;
using UnityEngine;

namespace UI
{
    public class InventoryItemValueBarWrapper : MonoBehaviour
    {
        [SerializeField] private ValueBar valueBar;

        [SerializeField] private string itemId;
        private IInventory inventory;

        private void Start()
        {
            inventory = FindObjectOfType<InventoryWrapper>();
            valueBar.SetValue(inventory.GetItem(itemId).Count.ToString());
            inventory.RegisterItemUpdateListener(itemId, OnUpdateItem);
        }

        private void OnUpdateItem(IInventory.Item item)
        {
            valueBar.SetValue(item.Count.ToString());
        }

        private void OnDestroy()
        {
            inventory.UnregisterItemUpdateListener(itemId, OnUpdateItem);
        }
    }
}

