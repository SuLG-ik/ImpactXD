using System.Collections;
using System.Collections.Generic;
using Fight.Player;
using UnityEngine;

namespace Fight.Player
{
    public interface IPlayer
    {
        public int GetCurrentHealth();

        public int GetMaxHealth();

        public PlayerPreset GetPreset();

        public void Attack();

        public bool Hit(int damage);
    }
}