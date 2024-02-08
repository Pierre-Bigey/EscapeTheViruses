using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThrillTrail.Services
{
    public class SceneLoaderService : IGameService
    {
        private void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        
        public void LoadGamePlayScene()
        {
            LoadScene("Gameplay");
        }
        
        public void LoadMainMenuScene()
        {
            LoadScene("MainMenu");
        }
    }
}