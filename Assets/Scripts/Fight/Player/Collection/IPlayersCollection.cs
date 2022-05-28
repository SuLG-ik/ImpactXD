using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fight.Player.Collection
{
    public interface IPlayersCollection
    {

        public List<PlayerItem> GetPlayers();

        public PlayerItem GetPlayerById(string characterId);
        
    }
}