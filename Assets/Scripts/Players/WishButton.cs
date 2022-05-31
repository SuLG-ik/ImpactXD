using System;
using Game.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Players
{
    public class WishButton : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;

        [SerializeField] private Sprite activateButton;

        [SerializeField] private Sprite inactivateButton;

        private INavigator navigator;

        private void Start()
        {
            navigator = FindObjectOfType<GameNavigator>();
            var inventory = FindObjectOfType<InventoryWrapper>();
            var item = inventory.GetItem("primogem");
            if (item.Count >= 160)
            {
                image.sprite = activateButton;
                button.onClick.AddListener(OnClick);
            }
            else
            {
                button.enabled = false;
                image.sprite = inactivateButton;
            }
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            navigator.Navigate("Wish");
        }
        
    }
}