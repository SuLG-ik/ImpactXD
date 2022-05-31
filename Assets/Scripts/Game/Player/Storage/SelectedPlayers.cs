using System;
using Fight.Player;
using Fight.Player.Collection;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Player.Storage
{
    public class SelectedPlayers
    {
        [CanBeNull] public PlayerPreset First;
        [CanBeNull] public PlayerPreset Second;

        public SelectedPlayers([CanBeNull] PlayerPreset first, [CanBeNull] PlayerPreset second)
        {
            First = first;
            Second = second;
        }
    }
}