using System.Collections.Generic;
using Fight.Player;
using UnityEngine;

namespace Game.Player
{
    public abstract class PlayersStorageWrapper : MonoBehaviour, IPlayersStorage
    {
        public abstract List<PlayerPreset> GetAvailablePlayers();
        public abstract List<PlayerPreset> GetSelectedPlayers();
    }
}