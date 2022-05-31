using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Fight.Player.Collection;
using JetBrains.Annotations;
using Lifecycle;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Fight.Player.Field
{
    public class PlayerField : CompatComponent
    {
        [SerializeField] private EntityPreview preview;

        private IPlayer player;

        [CanBeNull]
        public IPlayer GetPlayer()
        {
            return player;
        }

        private IPlayer CreatePlayer(PlayerPreset preset)
        {
            return new BasePlayer(preset);
        }

        [SerializeField] private Button button;

        [CanBeNull]
        public IPlayer InitializeField([CanBeNull] PlayerPreset preset)
        {
            if (preset == null)
            {
                preview.SetEmpty(true);
                return null;
            }

            player = CreatePlayer(preset);
            SetPreview(preset);
            SetHealth(player);
            return player;
        }

        private void SetPreview(PlayerPreset preset)
        {
            preview.SetEmpty(false);
            preview.SetImage(preset.Player.characterMiniSprite);
            preview.SetEntityName(preset.Player.characterName);
            preview.SetLevel(preset.Level);
        }

        private void SetHealth(IPlayer player)
        {
            void UpdateHealth(int delta, int health)
            {
                preview.SetHealth(health, player.GetMaxHealth());
            }

            preview.SetHealth(player.GetCurrentHealth(), player.GetMaxHealth());
            player.RegisterUpdateHealthListener(UpdateHealth);
            GetLifecycle().RegisterEventListener((newEvent) =>
            {
                if (newEvent == ILifecycle.Event.Destroy)
                    player.UnregisterUpdateHealthListener(UpdateHealth);
            });
        }

        public async UniTask<PlayerField> HandleClick()
        {
            await button.OnClickAsync();
            return this;
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