using System;
using System.Collections.Generic;
using System.Linq;
using Fight.Player.Field;
using Game.Player;
using Game.Player.Storage;

namespace Fight.Player
{
    class PlayersListWrapperImpl : PlayersListWrapper
    {
        private IPlayersStorage storage;

        private IPlayersStorage GetStorage()
        {
            return storage ??= FindObjectOfType<PlayersStorageWrapper>();
        }

        private PlayerField[] fields;

        private PlayerField[] GetFields()
        {
            return fields.Length == 0 ? fields = FindObjectsOfType<PlayerField>() : fields;
        }


        private SelectedPlayersField SpawnPlayer()
        {
            var selected = GetStorage().GetSelectedPlayers();
            if (selected.First != null)
                if (selected.Second != null)
                    GetFields()[1].SetPlayer(selected.Second);
            return new SelectedPlayersField(
                first: selected.First != null ? GetFields()[0].SetPlayer(selected.First) : null,
                second: selected.Second != null ? GetFields()[1].SetPlayer(selected.Second) : null
            );
        }

        private SelectedPlayersField players;

        public override SelectedPlayersField GetPlayers()
        {
            return players ??= SpawnPlayer();
        }
    }
}