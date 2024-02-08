using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvaController : MonoBehaviour
{
    [SerializeField] private GameObject _MainScreen;
    [SerializeField] private GameObject _SettingsScreen;


    public void BackButtonPressed()
    {
        _SettingsScreen.SetActive(false);
        _MainScreen.SetActive(true);
    }

    public void SoundButtonPressed()
    {
        Debug.Log("Sound button pressed!");
    }

    public void MusicButtonPressed()
    {
        Debug.Log("Music button pressed!");
    }

    public void VibrationButtonPressed()
    {
        Debug.Log("Vibration button pressed!");
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
