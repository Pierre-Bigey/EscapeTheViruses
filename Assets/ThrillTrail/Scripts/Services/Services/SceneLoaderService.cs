using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThrillTrail.Services
{
    public class SceneLoaderService : IGameService
    {
        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}