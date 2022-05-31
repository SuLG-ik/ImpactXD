using System.Linq;
using Cysharp.Threading.Tasks;

namespace Fight.Enemies.Field
{
    public class EnemiesListWrapperImpl : EnemiesListWrapper
    {
        private EnemyField[] fields;
        private IEnemy[] enemies;

        public override async UniTask<EnemyField> HandleFieldClick()
        {
            var tasks = GetFields().Where(field => field.GetEnemy()?.GetCurrentHealth() > 0)
                .Select(field => field.HandleClick()).ToArray();
            return !tasks.Any() ? null : (await UniTask.WhenAny(tasks)).result;
        }

        public override EnemyField[] GetFields()
        {
            return fields ??= GetComponentsInChildren<EnemyField>();
        }

        public override EnemyField[] GetAliveFields()
        {
            return GetFields().Where(field => field.GetEnemy().GetCurrentHealth() > 0).ToArray();
        }

        public override IEnemy[] GetEnemies()
        {
            return enemies ??= GetFields().Select(field => field.GetComponentInChildren<IEnemy>()).ToArray();
        }
    }
}