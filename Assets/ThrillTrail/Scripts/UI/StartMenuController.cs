using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    private SceneLoaderService _sceneLoaderService;
    
    [SerializeField] private GameObject _MainScreen;
    [SerializeField] private GameObject _SettingsScreen;
    // Start is called before the first frame update
    void Start()
    {
        _sceneLoaderService = ServiceLocator.Instance.Get<SceneLoaderService>();
        _MainScreen.SetActive(true);
        _SettingsScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartButtonPressed()
    {
        // Debug.Log("Start button pressed!");
        _sceneLoaderService.LoadGamePlayScene();
    }
    
    public void SettingsButtonPressed()
    {
        _SettingsScreen.SetActive(true);
        _MainScreen.SetActive(false);
    }
    
    public void ExitButtonPressed()
    {
        _sceneLoaderService.ExitGame();
    }
    
    
}
