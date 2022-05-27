using System.Collections.Generic;
using Fight.Player;

namespace Game.Player
{
    public interface IPlayersStorage
    {
        public List<PlayerPreset> GetAvailablePlayers();

        public List<PlayerPreset> GetSelectedPlayers();
    }
}