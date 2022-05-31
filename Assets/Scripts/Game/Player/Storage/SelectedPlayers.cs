using System;
using Fight.Player;
using Fight.Player.Collection;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Player.Storage
{
    public class SelectedPlayers
    {
        [CanBeNull] public readonly PlayerPreset First;
        [CanBeNull] public readonly PlayerPreset Second;

        public SelectedPlayers([CanBeNull] PlayerPreset first, [CanBeNull] PlayerPreset second)
        {
            First = first;
            Second = second;
        }
    }
}