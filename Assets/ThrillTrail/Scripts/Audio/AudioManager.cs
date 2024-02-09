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

    private void OnEnable()
    {
        _sfxService = ServiceLocator.Instance.Get<SFXService>();
        _sfxService._PlaySFX += PlaySFX;
        _sfxService._PlayDeathSFX += PlayDeathSFX;
        _sfxService._PlayButtonClickedSFX += PlayButtonClickedSFX;
        _sfxService._PlayGameplayMusic += PlayGameplayMusic;
    }

    public void PlayDeathSFX()
    {
        _sfxSource.PlayOneShot(deathSFX);
    }
    
    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
    
    public void PlayButtonClickedSFX()
    {
        _sfxSource.PlayOneShot(buttonClickedSFX);
    }
    
    
    public void PlayMusic(AudioClip musicClip)
    {
        _musicSource.clip = musicClip;
        _musicSource.Play();
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
