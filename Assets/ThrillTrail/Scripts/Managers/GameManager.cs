using System;
using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private SceneLoaderService _sceneLoaderService;
    private PlayerPrefService _playerPrefService;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject GameManager = new GameObject("GameControllerSingleton");
                    _instance = GameManager.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _sceneLoaderService = ServiceLocator.Instance.Get<SceneLoaderService>();
        _playerPrefService = ServiceLocator.Instance.Get<PlayerPrefService>();
        
        //If the game is started for the first time, set the default values for the playerpref
        if (!_playerPrefService.GetBool("SFX", out bool _))
            _playerPrefService.SetBool("SFX", true);
        if (!_playerPrefService.GetBool("Music", out bool _))
            _playerPrefService.SetBool("Music", true);
        if (!_playerPrefService.GetBool("Vibration", out bool _))
            _playerPrefService.SetBool("Vibration", true);
        
        _sceneLoaderService.LoadMainMenuScene();
    }
    
    
}
