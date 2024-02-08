using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    private SceneLoaderService _sceneLoaderService;
    // Start is called before the first frame update
    void Start()
    {
        _sceneLoaderService = ServiceLocator.Instance.Get<SceneLoaderService>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartButtonPressed()
    {
        Debug.Log("Start button pressed!");
        _sceneLoaderService.LoadGamePlayScene();
    }
    
    public void SettingsButtonPressed()
    {
        Debug.Log("Settings button pressed!");
    }
    
    public void ExitButtonPressed()
    {
        Debug.Log("Exit button pressed!");
        Application.Quit();
    }
}
