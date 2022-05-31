using System;
using TMPro;
using UI;
using UnityEngine;

namespace Fight.GameOver
{
    public class Win : MonoBehaviour
    {
        private int addedPrimogems;
        private int addedMora;
        [SerializeField] private ValueBar gems;
        [SerializeField] private ValueBar mora;

        private void Start()
        {
            addedPrimogems = PlayerPrefs.GetInt("last_add_gems", 0);
            addedMora = PlayerPrefs.GetInt("last_add_mora", 0);
            gems.SetValue(addedPrimogems.ToString());
            mora.SetValue(addedMora.ToString());
        }
    }
}