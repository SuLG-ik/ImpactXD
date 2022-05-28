using Fight.Player.Collection;
using UnityEngine;

namespace Fight.Player
{
    public class PlayerField : MonoBehaviour
    {
        [SerializeField] private PlayerPreview preview;

        private IPlayer player;

        private IPlayer CreatePlayer(PlayerPreset preset)
        {
            return player ??= new BasePlayer(preset);
        }


        public IPlayer SetPlayer(PlayerPreset player)
        {
            var playerItem = player.Player;
            preview.SetImage(playerItem.characterMiniSprite);
            preview.SetPlayerName(playerItem.characterName);
            preview.SetLevel(player.Level);
            return CreatePlayer(player);
        }

        private void Update()
        {
            if (player != null)
                preview.SetHealth(player.GetCurrentHealth(), player.GetMaxHealth());
        }
    }
}