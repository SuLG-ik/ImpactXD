using System.Collections.Generic;
using Fight.Player.Field;

namespace Fight.Player
{
    public interface IPlayersList
    {
        public SelectedPlayersField GetPlayers();
    }
}