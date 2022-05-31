using System;
using Fight.Enemies.Field;
using Fight.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fight.Enemies.Mobs.Slime
{
    public class BaseEnemy : EnemyWrapper
    {
        [SerializeField] private EnemyPreset preset;

        [SerializeField] private int baseDamage = 10;

        [SerializeField] private int baseHealth = 101;

        [SerializeField] private float baseCriticalDamage = 0.05f;

        [SerializeField] private float baseCriticalChance = 0.05f;

        [SerializeField] private float damageMultiplier = 0.5f;

        [SerializeField] private float healthMultiplier = 0.25f;

        private int health = -1;


        private int GetDamage()
        {
            var chance = Random.Range(0f, 1f);
            var damage = GetLeveledDamage();
            if (chance <= GetCriticalChance())
            {
                damage = (int) (damage * baseCriticalDamage);
            }

            return damage;
        }

        private int GetLeveledDamage()
        {
            return (int) (baseDamage * preset.Level * damageMultiplier);
        }

        private float GetCriticalChance()
        {
            return baseCriticalChance * preset.Level;
        }

        public override EnemyPreset GetPreset()
        {
            return preset;
        }

        public override int GetCurrentHealth()
        {
            return health >= 0 ? health : health = GetMaxHealth();
        }

        public override int GetMaxHealth()
        {
            return (int) (preset.Level * baseHealth * healthMultiplier);
        }

        public override bool Attack(IPlayer player)
        {
            return player.Hit(GetDamage());
        }

        public override bool Hit(int damage)
        {
            return DecrementHealth(damage);
        }


        public override void RegisterUpdateHealthListener(UpdateHealth listener)
        {
            _updateHealth += listener;
        }

        private event UpdateHealth _updateHealth;

        public override void UnregisterUpdateHealthListener(UpdateHealth listener)
        {
            _updateHealth -= listener;
        }

        private void SendUpdateHealth(int delta, int newHealth)
        {
            _updateHealth?.Invoke(delta, newHealth);
        }

        private bool DecrementHealth(int damage)
        {
            health = Math.Max(0, health - damage);
            SendUpdateHealth(-damage, health);
            return health <= 0;
        }


        public const string EnemyId = "enemy_slime";
    }
}