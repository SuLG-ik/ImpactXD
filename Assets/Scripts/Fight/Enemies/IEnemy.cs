using Cysharp.Threading.Tasks;
using Fight.Enemies.Field;
using Fight.Player;

namespace Fight.Enemies
{
    public interface IEnemy
    {
        public EnemyPreset GetPreset();
        
        public int GetCurrentHealth();

        public int GetMaxHealth();

        public bool Attack(IPlayer player);

        public bool Hit(int damage);
        
        public void RegisterUpdateHealthListener(UpdateHealth listener);

        public void UnregisterUpdateHealthListener(UpdateHealth listener);

    }
}