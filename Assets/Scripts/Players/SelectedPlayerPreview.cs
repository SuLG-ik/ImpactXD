
using Cysharp.Threading.Tasks;
using Fight.Player.Collection;
using Game.Player.Storage;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Players
{
    public class SelectedPlayerPreview : MonoBehaviour
    {
        [SerializeField] private PlayerNumber number;

        [SerializeField] private TMP_Text levelBar;
        [SerializeField] private TMP_Text playerNameBar;
        [SerializeField] private Image miniPreview;
        [SerializeField] private Button button;

        [SerializeField] private Mark mark;

        private void Start()
        {
            IPlayersStorage inventory = FindObjectOfType<PlayersStorageWrapper>();
            var players = inventory.GetSelectedPlayers();
            SetPlayer(number == PlayerNumber.First ? players.First : players.Second);
        }

        private void SetPlayer(PlayerPreset preset)
        {
            if (preset != null)
            {
                levelBar.text = $"Ур. {preset.Level}";
                playerNameBar.text = preset.Player.characterName;
                miniPreview.sprite = preset.Player.characterMiniSprite;
            }
            else
            {
                levelBar.gameObject.SetActive(false);
                playerNameBar.gameObject.SetActive(false);
                miniPreview.gameObject.SetActive(false);
            }
        }

        public void Mark()
        {
            mark.SetMark(true);
        }

        public void Unmark()
        {
            mark.SetMark(false);
        }

        public PlayerNumber GetNumber()
        {
            return number;
        }

        public async UniTask<SelectedPlayerPreview> HandleField()
        {
            await button.OnClickAsync();
            return this;
        }

        public enum PlayerNumber : int
        {
            First = 1,
            Second = 2,
        }
    }
}