using System;
using TMPro;
using UI;
using UnityEngine;

namespace Wish
{
    public class WishPlayerDrop : MonoBehaviour
    {
        [SerializeField] private TMP_Text infoText;
        [SerializeField] private ValueBar primogems;


        private void Start()
        {
            infoText.gameObject.SetActive(false);
            primogems.gameObject.SetActive(false);
        }

        public void SetPrimogems(int count)
        {
            if (count == 0)
            {
                infoText.gameObject.SetActive(false);
                primogems.gameObject.SetActive(false);
                return;
            }
            infoText.gameObject.SetActive(true);
            primogems.gameObject.SetActive(true);
            primogems.SetValue(count.ToString());
        }
    }
}