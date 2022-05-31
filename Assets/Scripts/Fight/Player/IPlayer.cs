using System;
using System.Collections;
using System.Collections.Generic;
using Fight.Enemies;
using Fight.Player;
using Fight.Player.Collection;
using UnityEngine;

namespace Fight.Player
{
    public interface IPlayer
    {
        public int GetCurrentHealth();

        public int GetMaxHealth();

        public PlayerPreset GetPreset();

        public bool Attack(IEnemy enemy);

        public bool Hit(int damage);

        public void RegisterUpdateHealthListener(UpdateHealth listener);

        public void UnregisterUpdateHealthListener(UpdateHealth listener);
        
    }
}