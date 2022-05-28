using System.Collections.Generic;
using Fight.Player.Field;
using UnityEngine;

namespace Fight.Player
{
    public abstract class PlayersListWrapper : MonoBehaviour, IPlayersList
    {
        public abstract SelectedPlayersField GetPlayers();
    }

}