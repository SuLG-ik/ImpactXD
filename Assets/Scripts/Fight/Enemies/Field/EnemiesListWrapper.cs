using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fight.Enemies.Field;
using UnityEngine;

namespace Fight.Enemies
{
    public abstract class EnemiesListWrapper : MonoBehaviour, IEnemiesList
    {
        public abstract IEnemy[] GetEnemies();
        
        public abstract UniTask<EnemyField> HandleFieldClick();

        public abstract EnemyField[] GetFields();
        
        public abstract EnemyField[] GetAliveFields();
        
    }
}