using System;
using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    
    [Header("SFX Audio Clips")]
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip buttonClickedSFX;
    
    [Header("Music Audio Clips")]
    [SerializeField] private AudioClip gameplayMusic;
    
    SFXService _sfxService;
    PlayerPrefService _playerPrefService;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _sfxService = ServiceLocator.Instance.Get<SFXService>();
        _playerPrefService = ServiceLocator.Instance.Get<PlayerPrefService>();
        
        _sfxService._PlaySFX += PlaySFX;
        _sfxService._PlayDeathSFX += PlayDeathSFX;
        _sfxService._PlayButtonClickedSFX += PlayButtonClickedSFX;
        _sfxService._PlayGameplayMusic += PlayGameplayMusic;
        _sfxService._StopMusic += StopMusic;
    }

    public void PlayDeathSFX()
    {
        PlaySFX(deathSFX);
    }
    
    //Check if the SFX are enable in playerpref and play the sound
    private void PlaySFX(AudioClip clip)
    {
        if (_playerPrefService.GetBool("SFX", out bool sfxEnabled) && sfxEnabled)
        {
            _sfxSource.PlayOneShot(clip);
        }
        
    }
    
    public void PlayButtonClickedSFX()
    {
        PlaySFX(buttonClickedSFX);
    }
    
    //Check if the Music are enable in playerpref and play the sound
    public void PlayMusic(AudioClip musicClip)
    {
        if (_playerPrefService.GetBool("Music", out bool musicEnabled) && musicEnabled)
        {
            _musicSource.clip = musicClip;
            _musicSource.Play();
        }
    }
    
    public void PlayGameplayMusic()
    {
        PlayMusic(gameplayMusic);
    }
    
    public void StopMusic()
    {
        _musicSource.Stop();
    }
}
