using UnityEngine;

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
        private const float HealthMultiplier = 0.25f;


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
            return GetPreset().Level * health;
        }

        public PlayerPreset GetPreset()
        {
            return preset;
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public bool Hit(int damage)
        {
            throw new System.NotImplementedException();
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