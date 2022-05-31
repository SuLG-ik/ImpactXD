using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fight.Enemies;
using Fight.Player.Field;

namespace Fight.Player
{
    public interface IPlayersList
    {
        public SelectedPlayersField GetPlayers();
        
        public UniTask<PlayerField> HandleFieldClick();

        public PlayerField[] GetFields();
    }
}