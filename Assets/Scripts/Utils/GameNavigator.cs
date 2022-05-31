using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class GameNavigator : MonoBehaviour, INavigator
    {
        [SerializeField] private SceneAsset mainMenuScene;
        [SerializeField] private SceneAsset gameScene;

        public void NavigateToMainMenu()
        {
            LoadScene(mainMenuScene);
        }

        public void NavigateToGame()
        {
            LoadScene(gameScene);
        }

        public void Navigate(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void NavigateWin(int primogems)
        {
            PlayerPrefs.SetInt("last_add_gems", primogems);
            Navigate("Scenes/Win");
        }

        public void NavigateLose()
        {
            Navigate("Scenes/Lose");
        }

        private void LoadScene(SceneAsset scene)
        {
            SceneManager.LoadScene(AssetDatabase.GetAssetPath(scene));
        } 
        
    }
}