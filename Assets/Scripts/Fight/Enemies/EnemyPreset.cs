using System;
using UnityEngine;

namespace Fight.Enemies
{
    [Serializable]
    public class EnemyPreset
    {
        [SerializeField] public string enemyId;
        [SerializeField] public int level;

        public EnemyPreset(string enemyId, int level)
        {
            this.enemyId = enemyId;
            this.level = level;
        }
    }
}