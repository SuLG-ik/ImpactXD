using System;
using System.ComponentModel;
using Cysharp.Threading.Tasks;
using Fight.Enemies.Field;
using Fight.Player;
using Fight.Player.Collection;
using Fight.Player.Field;
using JetBrains.Annotations;
using Lifecycle;
using UnityEngine;
using UnityEngine.UI;

namespace Fight.Enemies
{
    public class EnemyField : CompatComponent
    {
        [SerializeField] private EntityPreview preview;
        [SerializeField] private EnemyWrapper enemy;
        [SerializeField] private Button button;

        private void Start()
        {
            SetPreview(enemy.GetPreset());
            SetHealth(enemy);
        }

        public async UniTask<EnemyField> HandleClick()
        {
            await button.OnClickAsync();
            return this;
        }

        public IEnemy GetEnemy()
        {
            return enemy;
        }

        private void SetPreview(EnemyPreset preset)
        {
            preview.SetEmpty(false);
            preview.SetEntityName(preset.Item.enemyName);
            preview.SetLevel(preset.Level);
        }


        private void SetHealth(IEnemy enemy)
        {
            void UpdateHealth(int delta, int health)
            {
                preview.SetHealth(health, enemy.GetMaxHealth());
            }

            preview.SetHealth(enemy.GetCurrentHealth(), enemy.GetMaxHealth());
            enemy.RegisterUpdateHealthListener(UpdateHealth);
            GetLifecycle().RegisterEventListener((newEvent) =>
            {
                if (newEvent == ILifecycle.Event.Destroy)
                    enemy.UnregisterUpdateHealthListener(UpdateHealth);
            });
        }

        public void OnAttack()
        {
            preview.OnAttack();
        }

        public void OnHit()
        {
            preview.OnHit();
        }

        public void OnDie()
        {
            preview.OnDie();
        }
    }
}