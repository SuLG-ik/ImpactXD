using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Enemies
{
    [ExecuteInEditMode]
    public class EnemyPreview : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int level;

        private TMP_Text levelBar;
        private ValueBar healthBar;

        private void Start()
        {
            levelBar = GetComponentInChildren<TMP_Text>();
            healthBar = GetComponentInChildren<ValueBar>();
            SetLevel(level);
            SetHealth(health);
        }

        public void SetLevel(int level)
        {
            this.level = level;
            levelBar.text = $"Ур. {level}";
        }

        public void SetHealth(int health)
        {
            this.health = health;
            healthBar.SetValue(health.ToString());
        }
    }
}