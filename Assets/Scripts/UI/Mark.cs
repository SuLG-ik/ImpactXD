using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Image))]
    public class Mark : MonoBehaviour
    {
        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
            SetMark(false);
        }

        public void SetMark(bool isShown)
        {
            image.enabled = isShown;
        }
    }
}