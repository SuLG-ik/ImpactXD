using System.Collections.Generic;
using System.Linq.Expressions;
using Fight.Player;
using Fight.Player.Collection;
using UnityEngine;

namespace Game.Player.Storage
{
    public abstract class PlayersStorageWrapper : MonoBehaviour, IPlayersStorage
    {
        public abstract void SetPlayerLevelById(string characterId, int level);
        
        public abstract PlayerPreset GetPlayerById(string characterId);
        
        public abstract SelectedPlayers GetSelectedPlayers();

        public abstract void SetSelectedPlayer(SelectedPlayers players);
    }
}