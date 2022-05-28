using System.Collections.Generic;
using Fight.Player;

namespace Game.Player.Storage
{
    public interface IPlayersStorage
    {
        public SelectedPlayers GetSelectedPlayers();

        public abstract void SetSelectedPlayer(SelectedPlayers players);
    }
}