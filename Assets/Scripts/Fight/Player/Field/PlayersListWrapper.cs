using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Fight.Player.Field
{
    public abstract class PlayersListWrapper : MonoBehaviour, IPlayersList
    {
        public abstract SelectedPlayersField GetPlayers();
        public abstract UniTask<PlayerField> HandleFieldClick();
        public abstract PlayerField[] GetFields();

        public abstract SelectedPlayersField SpawnPlayer();

        public abstract PlayerField[] GetAliveFields();

    }
}