using System;
using Fight.Player.Collection;
using UnityEngine;

namespace Fight.Player
{
    public class PlayerPreset
    {
        public PlayerItem Player;
        public int Level;

        public PlayerPreset(PlayerItem player, int level)
        {
            Player = player;
            Level = level;
        }
    }
}