using System;
using UnityEngine;

namespace ThrillTrail.Services
{
    public class SFXService : IGameService
    {
        public Action<AudioClip> _PlaySFX;
        public Action _PlayDeathSFX;
        public Action _PlayButtonClickedSFX;
        public Action _PlayGameplayMusic;
        public Action _StopMusic;
        
        public void Play(AudioClip clip)
        {
            _PlaySFX?.Invoke(clip);
        }
        
        
        public void PlayDeathSFX()
        {
            _PlayDeathSFX?.Invoke();
        }
        
        public void PlayButtonClickedSFX()
        {
            _PlayButtonClickedSFX?.Invoke();
        }
        
        //Launch the gameplay music
        public void PlayGameplayMusic()
        {
            _PlayGameplayMusic?.Invoke();
        }
        
        //Stop Music
        public void StopMusic()
        {
            _StopMusic?.Invoke();
        }
        
        
    }
}