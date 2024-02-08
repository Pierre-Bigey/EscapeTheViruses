using System;
using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using TMPro;
using UnityEngine;

public class GameOverlayViewController : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    
    private SceneLoaderService _sceneLoaderService;

    private void Start()
    {
        _sceneLoaderService = ServiceLocator.Instance.Get<SceneLoaderService>();
    }

    //Update the score based on value
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString()+"m";
    }
    
    //When the player dies we show the death panel
    public void ShowDeathPanel()
    {
        m_gameOverPanel.SetActive(true);
    }
    
    public void HideDeathPanel()
    {
        m_gameOverPanel.SetActive(false);
    }

    public void RestartButtonPressed()
    {
        _sceneLoaderService.LoadGamePlayScene();
    }
    
    public void MenuButtonPressed()
    {
        _sceneLoaderService.LoadMainMenuScene();
    }
    
}
