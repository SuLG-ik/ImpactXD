using UnityEngine;

namespace Fight.Player
{
    public abstract class PlayerWrapper : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerPreset preset;

        public PlayerPreset GetPreset()
        {
            return preset;
        }

        public abstract int GetCurrentHealth();
        public abstract int GetMaxHealth();
        public abstract void Attack();
        public abstract bool Hit(int damage);
    }

    class PlayerWrapperImpl : PlayerWrapper
    {
        private int health = -1;

        private const int BaseDamage = 10;

        private const int BaseHealth = 101;

        private const float BaseCriticalDamage = 0.05f;

        private const float BaseCriticalChance = 0.05f;

        private const float DamageMultiplier = 0.5f;
        private const float HealthMultiplier = 0.25f;

        public override int GetCurrentHealth()
        {
            return health >= 0 ? health : health = GetMaxHealth();
        }

        public override int GetMaxHealth()
        {
            return GetPreset().level * health;
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override bool Hit(int damage)
        {
            throw new System.NotImplementedException();
        }

        private int GetBaseHealth()
        {
            return (int) (HealthMultiplier * GetPreset().level * BaseHealth);
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
            return (int) (BaseDamage * GetPreset().level * DamageMultiplier);
        }

        private float GetCriticalChance()
        {
            return BaseCriticalChance * GetPreset().level;
        }
    }
}