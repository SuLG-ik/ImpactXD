using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Levels
{
    public class NavigationButton : MonoBehaviour
    {
        [SerializeField] private string targetScene;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(targetScene));
        }
    }
}