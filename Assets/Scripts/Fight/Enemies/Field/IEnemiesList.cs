using Cysharp.Threading.Tasks;

namespace Fight.Enemies.Field
{
    public interface IEnemiesList
    {
        public IEnemy[] GetEnemies();
        
        public UniTask<EnemyField> HandleFieldClick();

        public EnemyField[] GetFields();
    }
}