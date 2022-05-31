using System;
using Fight.Player.Collection;
using Fight.Player.Field;
using Game.Inventory;
using Game.Player.Storage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Players
{
    public class PlayerContextLevelUp : MonoBehaviour
    {
        [SerializeField] private Image image;

        [SerializeField] private Button button;

        [SerializeField] private Sprite activateButton;

        [SerializeField] private Sprite inactivateButton;

        [SerializeField] private TMP_Text costText;

        private INavigator navigator;
        private IPlayersStorage storage;


        private PlayerPreset preset;
        private IInventory inventory;

        private int cost;


        public void Initialize()
        {
            storage = FindObjectOfType<PlayersStorageWrapper>();
            navigator = FindObjectOfType<GameNavigator>();
            inventory = FindObjectOfType<InventoryWrapper>();
            var item = inventory.GetItem("mora");
            preset = GetComponentInParent<PlayerPreview>().GetPreset();
            print(preset);
            if (preset != null)
            {
                cost = 100 * preset.Level;
                costText.text = cost.ToString();
                if (item.Count >= cost)
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
        }


        public void Uninitialize()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnDestroy()
        {
            Uninitialize();
        }

        private void OnClick()
        {
            storage.SetPlayerLevelById(preset.Player.characterId, preset.Level + 1);
            inventory.AddItems("mora", -cost);
            navigator.Navigate("Players");
        }
    }
}