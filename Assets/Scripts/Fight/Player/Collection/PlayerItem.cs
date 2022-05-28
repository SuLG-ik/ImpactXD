using System;
using UnityEngine;

namespace Fight.Player.Collection
{
    [Serializable]
    public class PlayerItem
    {
        [SerializeField] public string characterId;
        [SerializeField] public string characterName;
        [SerializeField] public Sprite characterMiniSprite;
    }
}