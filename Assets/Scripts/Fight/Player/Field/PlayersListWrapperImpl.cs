using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.Player.Storage;
using UnityEngine;

namespace Fight.Player.Field
{
    class PlayersListWrapperImpl : PlayersListWrapper
    {
        private IPlayersStorage storage;

        private IPlayersStorage GetStorage()
        {
            return storage ??= FindObjectOfType<PlayersStorageWrapper>();
        }

        [SerializeField] private PlayerField[] fields;

        public override SelectedPlayersField SpawnPlayer()
        {
            var selected = GetStorage().GetSelectedPlayers();
            return new SelectedPlayersField(
                first: GetFields()[0].InitializeField(selected.First),
                second: GetFields()[1].InitializeField(selected.Second)
            );
        }

        public override PlayerField[] GetAliveFields()
        {
            return GetFields().Where(field => field.GetPlayer()?.GetCurrentHealth() > 0).ToArray();
        }

        private SelectedPlayersField players;

        public override SelectedPlayersField GetPlayers()
        {
            return players ??= SpawnPlayer();
        }

        public override async UniTask<PlayerField> HandleFieldClick()
        {
            var tasks = GetFields().Where(field => field.GetPlayer()?.GetCurrentHealth() > 0)
                .Select(field => field.HandleClick()).ToArray();
            return !tasks.Any() ? null : (await UniTask.WhenAny(tasks)).result;
        }

        public override PlayerField[] GetFields()
        {
            return fields;
        }
    }
}