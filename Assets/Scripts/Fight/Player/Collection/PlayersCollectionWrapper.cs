using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fight.Player.Collection
{
    public class PlayersCollectionWrapper : MonoBehaviour, IPlayersCollection
    {
        [SerializeField] private List<PlayerItem> players = new List<PlayerItem>();

        public List<PlayerItem> GetPlayers()
        {
            return players;
        }

        public PlayerItem GetPlayerById(string characterId)
        {
            return GetPlayers().First(player => player.characterId == characterId);
        }
    }
}