using System.Collections.Generic;
using Fight.Player;
using Fight.Player.Collection;
using JetBrains.Annotations;

namespace Game.Player.Storage
{
    public interface IPlayersStorage
    {
        public void SetPlayerLevelById(string characterId, int level);

        [CanBeNull]
        public PlayerPreset GetPlayerById(string characterId);

        public SelectedPlayers GetSelectedPlayers();

        public abstract void SetSelectedPlayer(SelectedPlayers players);
    }
}