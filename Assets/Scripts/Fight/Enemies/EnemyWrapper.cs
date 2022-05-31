using Fight.Enemies.Field;
using Fight.Player;
using UnityEngine;

namespace Fight.Enemies
{
    public abstract class EnemyWrapper : MonoBehaviour, IEnemy
    {
        public abstract EnemyPreset GetPreset();
        public abstract int GetCurrentHealth();
        public abstract int GetMaxHealth();
        public abstract bool Attack(IPlayer player);
        public abstract bool Hit(int damage);
        public abstract void RegisterUpdateHealthListener(UpdateHealth listener);
        public abstract void UnregisterUpdateHealthListener(UpdateHealth listener);

    }
}