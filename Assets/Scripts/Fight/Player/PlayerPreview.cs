using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Player
{
    public class PlayerPreview : MonoBehaviour
    {
        [SerializeField] private int playerHealth;
        [SerializeField] private int playerHealthMax;
        [SerializeField] private int playerLevel;
        [SerializeField] private string playerName;
        [SerializeField] private Sprite miniImage;

        [SerializeField] private TMP_Text levelBar;
        [SerializeField] private ValueBar healthBar;
        [SerializeField] private TMP_Text playerNameBar;
        [SerializeField] private Image miniPreview;

        private void Start()
        {
            SetLevel(playerLevel);
            SetHealth(playerHealth, playerHealthMax);
        }

        public void SetImage(Sprite sprite)
        {
            miniImage = sprite;
            miniPreview.sprite = miniImage;
        }

        public void SetLevel(int level)
        {
            playerLevel = level;
            levelBar.text = $"Ур. {playerLevel}";
        }

        public void SetHealth(int health, int maxHealth)
        {
            playerHealth = health;
            playerHealthMax = maxHealth;
            healthBar.SetValue($"{playerHealth}/{playerHealthMax}");
        }

        public void SetPlayerName(string name)
        {
            this.playerName = name;
            playerNameBar.text = playerName;
        }
    }
}