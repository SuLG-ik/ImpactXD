using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Fight.Player.Collection;
using Game.Inventory;
using Game.Player.Storage;
using UnityEngine;
using UnityEngine.Video;
using Random = System.Random;

namespace Wish
{
    public class Wish : MonoBehaviour
    {
        [SerializeField] private int animationDurationMillis;
        [SerializeField] private WishPreview preview;


        private async void Start()
        {
            var collection = FindObjectOfType<PlayersCollectionWrapper>();
            var storage = FindObjectOfType<PlayersStorageWrapper>();
            var inventory = FindObjectOfType<InventoryWrapper>();
            await HandleWish(collection, storage, inventory);
        }

        private async UniTask HandleWish(IPlayersCollection collection, IPlayersStorage storage, IInventory inventory)
        {
            inventory.AddItems("primogem", -160);
            await UniTask.Delay(animationDurationMillis);
            var players = collection.GetPlayers();
            var index = new Random().Next(players.Count);
            var player = players[index];
            if (storage.GetPlayerById(player.characterId) == null)
            {
                NewPlayer(player, storage);
            }
            else
            {
                RepeatPlayer(player, inventory);
            }
        }

        private void NewPlayer(PlayerItem player, IPlayersStorage storage)
        {
            storage.SetPlayerLevelById(player.characterId, 1);
            preview.NewPlayer(player);
        }

        private void RepeatPlayer(PlayerItem player, IInventory inventory)
        {
            inventory.AddItems("primogem", 50);
            preview.RepeatPlayer(player, 50);
        }
    }
}