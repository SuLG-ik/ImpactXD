namespace Fight.Player.Collection
{
    public class PlayerPreset
    {
        public PlayerItem Player;
        public int Level;

        public PlayerPreset(PlayerItem player, int level)
        {
            Player = player;
            Level = level;
        }
    }
}