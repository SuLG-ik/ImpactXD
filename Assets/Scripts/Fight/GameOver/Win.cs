using System;
using TMPro;
using UI;
using UnityEngine;

namespace Fight.GameOver
{
    public class Win : MonoBehaviour
    {
        private int addedPremogems;
        [SerializeField] private ValueBar gems;

        private void Start()
        {
            addedPremogems = PlayerPrefs.GetInt("last_add_gems", 0);
            gems.SetValue(addedPremogems.ToString());
            PlayerPrefs.SetInt("is_fight_completed", 1);
            PlayerPrefs.Save();
        }
    }
}