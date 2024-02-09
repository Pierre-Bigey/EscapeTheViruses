using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ThrillTrail.Services
{
    public class SceneLoaderService : IGameService
    {
        private void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        
        public void LoadGamePlayScene()
        {
            LoadScene("Gameplay");
        }
        
        public void LoadMainMenuScene()
        {
            LoadScene("MainMenu");
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }
    }
}