using Fight.Player.Collection;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class GameNavigator : MonoBehaviour, INavigator
    {
        [SerializeField] private string mainMenuScene;
        [SerializeField] private string gameScene;

        public void NavigateToMainMenu()
        {
            Navigate(mainMenuScene);
        }

        public void NavigateToGame()
        {
            Navigate(gameScene);
        }

        public void Navigate(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void NavigateWin(int primogems, int mora)
        {
            PlayerPrefs.SetInt("last_add_gems", primogems);
            PlayerPrefs.SetInt("last_add_mora", mora);
            PlayerPrefs.Save();
            Navigate("Scenes/Win");
        }

        public void NavigateLose()
        {
            Navigate("Scenes/Lose");
        }
    }
}