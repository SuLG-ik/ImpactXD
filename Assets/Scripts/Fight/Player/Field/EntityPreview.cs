using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Player.Field
{
    public class EntityPreview : MonoBehaviour
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
        [SerializeField] private Animator animator;

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

        public void SetEntityName(string name)
        {
            this.playerName = name;
            playerNameBar.text = playerName;
        }

        public void SetEmpty(bool isEmpty)
        {
            miniPreview.gameObject.SetActive(!isEmpty);
            levelBar.gameObject.SetActive(!isEmpty);
            playerNameBar.gameObject.SetActive(!isEmpty);
            healthBar.gameObject.SetActive(!isEmpty);
        }

        public void OnAttack()
        {
            animator.Play("attack");
        }

        public void OnHit()
        {
            animator.Play("hit");
        }

        public void OnDie()
        {
            animator.Play("died");
            animator.SetBool("is_died", true);
        }
    }
}