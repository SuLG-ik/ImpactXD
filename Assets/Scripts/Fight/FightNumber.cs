using System;
using TMPro;
using UnityEngine;

namespace Fight
{
    [RequireComponent(typeof(TMP_Text))]
    public class FightNumber : MonoBehaviour
    {
        private void Start()
        {
            IFight fight = FindObjectOfType<FightWrapper>();
            var text = GetComponent<TMP_Text>();
            text.text = $"Схватка {fight.GetNumber()}";
        }
    }
}