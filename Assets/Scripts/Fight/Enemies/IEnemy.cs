namespace Fight.Enemies
{
    public interface IEnemy
    {

        public EnemyPreset GetPreset();

        public void Attack();

        public bool Hit(int damage);

    }
}