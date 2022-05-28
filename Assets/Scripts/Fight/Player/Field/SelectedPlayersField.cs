﻿using JetBrains.Annotations;

namespace Fight.Player.Field
{
    public class SelectedPlayersField
    {
        [CanBeNull] public IPlayer First;
        public IPlayer Second;

        public SelectedPlayersField([CanBeNull] IPlayer first, [CanBeNull] IPlayer second)
        {
            First = first;
            Second = second;
        }
    }
}