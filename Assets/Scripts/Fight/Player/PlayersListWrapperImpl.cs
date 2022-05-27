using System;
using System.Collections.Generic;
using Game.Player;

namespace Fight.Player
{
    class PlayersListWrapperImpl : PlayersListWrapper
    {
        private IPlayersStorage storage;

        private IPlayersStorage GetStorage()
        {
            return storage ??= FindObjectOfType<PlayersStorageWrapper>();
        }
        
        private void Get
        

        private void SpawnPlayer()
        {
            
        }

        public override List<IPlayer> GetPlayers()
        {
            
        }
        
    }
}