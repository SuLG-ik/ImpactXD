using System;
using Fight.Enemies.Mobs;
using UnityEngine;

namespace Fight.Enemies.Field
{
    [Serializable]
    public class EnemyPreset
    {
        [SerializeField] public int Level;
        [SerializeField] public EnemyItem Item;
    }
}