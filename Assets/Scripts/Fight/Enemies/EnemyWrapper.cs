using UnityEngine;

namespace Fight.Enemies
{
    public abstract class EnemyWrapper : MonoBehaviour
    {
        [SerializeField] private int index;

        [SerializeField]
        private EnemyPreset preset;

        public int GetIndex()
        {
            return index;
        }

        protected EnemyPreset GetPreset()
        {
            return preset;
        }

        private IFight fight;
        
        protected IFight GetFight()
        {
            return fight ??= FindObjectOfType<FightWrapper>();
        }
        
    }
}