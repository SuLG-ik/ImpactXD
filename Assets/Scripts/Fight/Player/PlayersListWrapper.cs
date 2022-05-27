using System.Collections.Generic;
using UnityEngine;

namespace Fight.Player
{
    public abstract class PlayersListWrapper : MonoBehaviour, IPlayersList
    {
        public abstract List<IPlayer> GetPlayers();
    }

}