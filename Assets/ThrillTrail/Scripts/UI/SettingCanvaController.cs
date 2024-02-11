using System;
using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;
using UnityEngine.UI;

public class SettingCanvaController : MonoBehaviour
{
    [SerializeField] private GameObject _MainScreen;
    [SerializeField] private GameObject _SettingsScreen;
    
    //The toggle references
    [SerializeField] private Toggle _SFXToggle;
    [SerializeField] private Toggle _MusicToggle;
    [SerializeField] private Toggle _VibrationToggle;
    
    private PlayerPrefService _playerPrefService;


    private void Start()
    {
        _playerPrefService = ServiceLocator.Instance.Get<PlayerPrefService>();
        
        //Set the toogle following the playerpref
        if(_playerPrefService.GetBool("SFX", out bool sfxEnabled))
            _SFXToggle.isOn = !sfxEnabled;
        if(_playerPrefService.GetBool("Music", out bool musicEnabled))
            _MusicToggle.isOn = !musicEnabled;
        if(_playerPrefService.GetBool("Vibration", out bool vibrationEnabled))
            _VibrationToggle.isOn = !vibrationEnabled;
        
    }

    public void BackButtonPressed()
    {
        _SettingsScreen.SetActive(false);
        _MainScreen.SetActive(true);
    }

    public void SFXButtonPressed(bool value)
    {
        _playerPrefService.SetBool("SFX", !value);
    }

    public void MusicButtonPressed(bool value)
    {
        _playerPrefService.SetBool("Music", !value);
    }

    public void VibrationButtonPressed(bool value)
    {
        _playerPrefService.SetBool("Vibration", !value);
    }

    public void ResetButtonPressed()
    {
        Debug.Log("Reset button pressed!");
    }

    public void PrivacyButtonPressed()
    {
        Debug.Log("Privacy button pressed!");
    }

    public void TermsButtonPressed()
    {
        Debug.Log("Terms button pressed!");
    }

    public void AboutButtonPressed()
    {
        Debug.Log("About button pressed!");
    }

    public void RateButtonPressed()
    {
        Debug.Log("Rate button pressed!");
    }

    public void ShareButtonPressed()
    {
        Debug.Log("Share button pressed!");
    }

    public void ContactButtonPressed()
    {
        Debug.Log("Contact button pressed!");
    }

    public void FeedbackButtonPressed()
    {
        Debug.Log("Feedback button pressed!");
    }

    public void HelpButtonPressed()
    {
        Debug.Log("Help button pressed!");
    }

    public void TutorialButtonPressed()
    {
        Debug.Log("Tutorial button pressed!");
    }

    public void PrivacyPolicyButtonPressed()
    {
        Debug.Log("Privacy Policy button pressed!");
    }

    public void TermsOfServiceButtonPressed()
    {
        Debug.Log("Terms of Service button pressed!");
    }

    public void AboutUsButtonPressed()
    {
        Debug.Log("About Us button pressed!");
    }

    public void RateUsButtonPressed()
    {
        Debug.Log("Rate Us button pressed!");
    }
}
