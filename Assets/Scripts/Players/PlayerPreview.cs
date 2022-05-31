using Cysharp.Threading.Tasks;
using Fight.Player.Collection;
using Game.Player.Storage;
using JetBrains.Annotations;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Players
{
    public class PlayerPreview : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private string character;

        [SerializeField] private TMP_Text levelBar;
        [SerializeField] private TMP_Text playerNameBar;
        [SerializeField] private Image miniPreview;
        [SerializeField] private Button button;

        private PlayerPreset preset;

        [SerializeField] private Mark mark;

        [SerializeField] private PlayerContext context;

        private void Start()
        {
            IPlayersStorage inventory = FindObjectOfType<PlayersStorageWrapper>();
            preset = inventory.GetPlayerById(character);
            if (preset != null)
            {
                SetPlayer(preset);
                return;
            }

            IPlayersCollection collection = FindObjectOfType<PlayersCollectionWrapper>();
            var playerItem = collection.GetPlayerById(character);
            SetPlayer(playerItem);
        }

        [CanBeNull]
        public PlayerPreset GetPreset()
        {
            return preset;
        }

        private void SetPlayer(PlayerItem item)
        {
            button.enabled = false;
            levelBar.gameObject.SetActive(false);
            playerNameBar.text = item.characterName;
            miniPreview.sprite = item.characterMiniSprite;
            canvasGroup.alpha = 0.5f;
        }

        private void SetPlayer(PlayerPreset preset)
        {
            levelBar.text = $"Ур. {preset.Level}";
            playerNameBar.text = preset.Player.characterName;
            miniPreview.sprite = preset.Player.characterMiniSprite;
            button.enabled = true;
        }

        public async UniTask<PlayerPreview> HandleField()
        {
            await button.OnClickAsync();
            return this;
        }

        public void Mark()
        {
            mark.SetMark(true);
        }

        public void Unmark()
        {
            mark.SetMark(false);
        }

        public void ShowContext()
        {
            context.ShowContext();
        }

        public void HideContext()
        {
            context.HideContext();
        }
    }
}