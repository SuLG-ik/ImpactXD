using System;
using Fight.Enemies;
using Fight.Player.Collection;
using Random = UnityEngine.Random;

namespace Fight.Player
{
    internal class BasePlayer : IPlayer
    {
        private int health = -1;

        private const int BaseDamage = 10;

        private const int BaseHealth = 101;

        private const float BaseCriticalDamage = 0.05f;

        private const float BaseCriticalChance = 0.05f;

        private const float DamageMultiplier = 0.5f;
        private const float HealthMultiplier = 0.36f;

        private PlayerPreset preset;

        public BasePlayer(PlayerPreset preset)
        {
            this.preset = preset;
        }

        public int GetCurrentHealth()
        {
            return health >= 0 ? health : health = GetMaxHealth();
        }

        public int GetMaxHealth()
        {
            return (int) (GetPreset().Level * BaseHealth * HealthMultiplier);
        }

        public PlayerPreset GetPreset()
        {
            return preset;
        }

        public bool Attack(IEnemy enemy)
        {
            return enemy.Hit(GetDamage());
        }

        public bool Hit(int damage)
        {
            health = Math.Max(0, health - damage);
            SendUpdateHealth(-damage, health);
            return health <= 0;
        }

        public void RegisterUpdateHealthListener(UpdateHealth listener)
        {
            _updateHealth += listener;
        }

        private event UpdateHealth _updateHealth;

        public void UnregisterUpdateHealthListener(UpdateHealth listener)
        {
            _updateHealth -= listener;
        }

        private void SendUpdateHealth(int delta, int newHealth)
        {
            _updateHealth?.Invoke(delta, newHealth);
        }

        private int GetBaseHealth()
        {
            return (int) (HealthMultiplier * GetPreset().Level * BaseHealth);
        }

        private int GetDamage()
        {
            var chance = Random.Range(0f, 1f);
            var damage = GetLeveledDamage();
            if (chance <= GetCriticalChance())
            {
                damage = (int) (damage * BaseCriticalDamage);
            }

            return damage;
        }

        private int GetLeveledDamage()
        {
            return (int) (BaseDamage * GetPreset().Level * DamageMultiplier);
        }

        private float GetCriticalChance()
        {
            return BaseCriticalChance * GetPreset().Level;
        }
    }
}