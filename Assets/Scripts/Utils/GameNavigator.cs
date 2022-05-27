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

        private void LoadScene(SceneAsset scene)
        {
            SceneManager.LoadScene(AssetDatabase.GetAssetPath(scene));
        } 
        
    }
}