using System;
using Fight.Player.Collection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wish
{
    public class WishPlayerPreview : MonoBehaviour
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Image inventoryImage;
        [SerializeField] private TMP_Text playerName;

        private void Start()
        {
            inventoryImage.enabled = false;
            playerImage.enabled = false;
            playerName.enabled = false;
        }

        public void SetPlayer(PlayerItem player)
        {
            playerImage.enabled = true;
            playerName.enabled = true;
            inventoryImage.enabled = true;
            playerImage.sprite = player.characterMiniSprite;
            playerName.text = player.characterName;
        }
    }
}