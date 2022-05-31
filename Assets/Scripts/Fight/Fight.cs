using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Fight.Enemies;
using Fight.Player;
using Fight.Player.Collection;
using Fight.Player.Field;
using Game.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Random = System.Random;

namespace Fight
{
    public class Fight : FightWrapper
    {
        [SerializeField] private int primogems;
        [SerializeField] private int reshin = 20;
        [SerializeField] private int fightNumber = 1;

        [SerializeField] private PlayersListWrapper playersList;
        [SerializeField] private EnemiesListWrapper enemiesList;

        private IInventory inventory;
        private INavigator navigator;

        private async void Start()
        {
            inventory = FindObjectOfType<InventoryWrapper>();
            navigator = FindObjectOfType<GameNavigator>();
            playersList.SpawnPlayer();
            try
            {
                await HandleNextMovement();
            }
            catch (OperationCanceledException)
            {
                print("canceled");
            }
        }

        private async UniTask HandleNextMovement()
        {
            while (true)
            {
                await AttachByPlayer();
                await UniTask.Delay(1000);
                if (enemiesList.GetAliveFields().Length == 0)
                {
                    Win();
                    return;
                }

                AttackByEnemy();
                if (playersList.GetAliveFields().Length == 0)
                {
                    Lose();
                    return;
                }
            }
        }

        private void AttackByEnemy()
        {
            var enemyField = GetRandomAliveEnemy();
            if (enemyField == null) throw new Exception("null enemy");
            var playerField = GetRandomAlivePlayer();
            if (playerField == null) throw new Exception("null player");
            enemyField.OnAttack();
            if (enemyField.GetEnemy()?.Attack(playerField.GetPlayer()) == true)
            {
                playerField.OnDie();
            }
            else
            {
                playerField.OnHit();
            }
        }

        private async UniTask AttachByPlayer()
        {
            var playerField = await playersList.HandleFieldClick();
            if (playerField == null) throw new Exception("null player");
            var enemyField = await enemiesList.HandleFieldClick();
            if (enemyField == null) throw new Exception("null enemy");
            playerField.OnAttack();
            if (playerField.GetPlayer()?.Attack(enemyField.GetEnemy()) == true)
            {
                enemyField.OnDie();
            }
            else
            {
                enemyField.OnHit();
            }
        }

        private PlayerField GetRandomAlivePlayer()
        {
            var random = new Random();
            var fields = playersList.GetAliveFields().ToList();
            print(fields.Count);
            if (fields.Count == 0)
                return null;
            var index = random.Next(fields.Count());
            return fields[index];
        }

        private EnemyField GetRandomAliveEnemy()
        {
            var random = new Random();
            var fields = enemiesList.GetAliveFields().ToList();
            if (fields.Count == 0)
                return null;
            var index = random.Next(fields.Count());
            return fields[index];
        }

        private void Win()
        {
            var isFightCompleted = PlayerPrefs.GetInt("is_fight_completed", 0) == 1;
            var primogems = isFightCompleted ? 5 : this.primogems;
            inventory.AddItems("primogem", primogems);
            inventory.AddItems("original_resin", -reshin);
            PlayerPrefs.SetInt("is_fight_completed", 0);
            PlayerPrefs.Save();
            navigator.NavigateWin(primogems);
        }

        private void Lose()
        {
            navigator.NavigateLose();
        }

        public override int GetNumber()
        {
            return fightNumber;
        }
    }
}