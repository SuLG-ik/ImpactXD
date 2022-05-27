using System;
using Random = UnityEngine.Random;

namespace Fight.Enemies.Mobs.Slime
{
    public class SlimeEnemy : EnemyWrapper, IEnemy
    {
        private readonly EnemyPreset preset;
        private readonly IFight fight;

        private const int BaseDamage = 10;

        private const int BaseHealth = 101;

        private const float BaseCriticalDamage = 0.05f;

        private const float BaseCriticalChance = 0.05f;

        private const float DamageMultiplier = 0.5f;
        private const float HealthMultiplier = 0.25f;

        private int health;


        private int GetBaseHealth()
        {
            return (int) (HealthMultiplier * preset.level * BaseHealth);
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

        public EnemyPreset GetPreset()
        {
            if (preset == null || fight == null)
                throw new Exception("Illegal state. Enemy is not initialized");
            return preset;
        }

        public void Attack()
        {
            fight.AttackPlayer(GetDamage());
        }

        public bool Hit(int damage)
        {
            return DecrementHealth(damage);
        }

        private bool DecrementHealth(int damage)
        {
            if (damage >= health)
            {
                health = 0;
                return true;
            }

            health -= damage;
            return false;
        }


        public const string EnemyId = "enemy_slime";
    }
}