using System;
using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace ThrillTrail.Player
{
    //Singleton script that manages the player's movement and speed
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;

        private float speed;
        [SerializeField] private float initialSpeed = 5f;
        [SerializeField] private float speedIncreaseRatio = 0.01f;
        
        [SerializeField] private GameOverlayViewController gameOverlayViewController;
        
        private bool _isDead = false;

        [SerializeField] private GameObject LittleBoy;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            speed = 0;
        }

        private void Start()
        {
            StartEndlessRun();
        }

        public void StartEndlessRun()
        {
            speed = initialSpeed;
            _isDead = false;
            ServiceLocator.Instance.Get<SFXService>().PlayGameplayMusic();
        }

        private void Update()
        {
            if (!_isDead && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _playerMovement.MovePlayer(touch.position, speed);
                    
                }
            }
            if(!_isDead)
            {
                GoForward();
                IncreaseSpeed();
                gameOverlayViewController.UpdateScore((int)transform.position.z);
            }
        }
        
        private void GoForward()
        {
            transform.Translate(LittleBoy.transform.forward * (speed * Time.deltaTime));
            _playerAnimator.SetSpeed(speed>0?1:0);
        }

        private void IncreaseSpeed()
        {
            speed += Time.deltaTime * speedIncreaseRatio;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Danger") && !_isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            speed = 0;
            //trigger the death animation in the _playerAnimator
            _playerAnimator.Die();
            
            gameOverlayViewController.ShowDeathPanel();
            
            //Update the high score
            ServiceLocator.Instance.Get<PlayerPrefService>().SetInt("HighScore", (int)transform.position.z);
            
            //Trigger the death SFX action
            var _SFXService = ServiceLocator.Instance.Get<SFXService>();
            _SFXService.PlayDeathSFX();
            _SFXService.StopMusic();
        }
    }
}