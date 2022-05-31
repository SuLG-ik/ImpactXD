using System;
using UnityEngine;

namespace Players
{
    public class PlayerContext : MonoBehaviour
    {
        [SerializeField] private GameObject context;

        private void Start()
        {
            context.SetActive(false);
        }

        public void ShowContext()
        {
            context.SetActive(true);
            context.GetComponentInChildren<PlayerContextLevelUp>().Initialize();
        }

        public void HideContext()
        {
            context.SetActive(false);
            context.GetComponentInChildren<PlayerContextLevelUp>().Uninitialize();
        }
    }
}