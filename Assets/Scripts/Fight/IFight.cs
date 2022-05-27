namespace Fight
{
    public interface IFight
    {
        
        public void AttackPlayer(int damage);

        public void AttackEnemy(int enemyIndex, int damage);
        
    }
}