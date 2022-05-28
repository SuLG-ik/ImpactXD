using System.Collections.Generic;
using System.Linq.Expressions;
using Fight.Player;
using UnityEngine;

namespace Game.Player.Storage
{
    public abstract class PlayersStorageWrapper : MonoBehaviour, IPlayersStorage
    {
        
        public abstract SelectedPlayers GetSelectedPlayers();
        
        public abstract void SetSelectedPlayer(SelectedPlayers players);
        
    }
}