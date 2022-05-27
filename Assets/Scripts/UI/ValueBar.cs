using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteInEditMode]
    public class ValueBar : MonoBehaviour
    {
        [SerializeField] private Sprite icon;

        [SerializeField] private string value;

        [SerializeField] private Image iconRenderer;
        [SerializeField] private TMP_Text textRenderer;

        private void Start()
        {
            iconRenderer.sprite = icon;
        }

        private void Update()
        {
            textRenderer.text = value;
        }

        public void SetValue(string newValue)
        {
            value = newValue;
        }
        
    }
}