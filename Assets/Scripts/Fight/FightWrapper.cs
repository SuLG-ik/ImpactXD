using UnityEngine;

namespace Fight
{
    public abstract class FightWrapper : MonoBehaviour, IFight
    {
        [SerializeField] private FightPreset preset;

        protected FightPreset GetPreset()
        {
            return preset;
        }

        public abstract void AttackPlayer(int damage);
        public abstract void AttackEnemy(int enemyIndex, int damage);
    }
}