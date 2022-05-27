using System;
using UnityEngine;

namespace Fight.Player
{
    [Serializable]
    public class PlayerPreset
    {
        [SerializeField] public string CharacterId;
        [SerializeField] public int level;

        public PlayerPreset(string characterId)
        {
            CharacterId = characterId;
        }
    }
}