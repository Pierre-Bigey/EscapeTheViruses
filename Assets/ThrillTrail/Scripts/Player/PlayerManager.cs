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

        public float speed{ private set; get; }
        [SerializeField] private float initialSpeed = 5f;
        [SerializeField] private float speedIncreaseRatio = 0.01f;
        
        [SerializeField] private GameOverlayViewController gameOverlayViewController;
        
        private bool _isDead = false;



        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
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
            _playerMovement.Activate(true);
            
        }

        private void Update()
        {
            if(!_isDead)
            {
                GoForward();
                IncreaseSpeed();
                gameOverlayViewController.UpdateScore((int)transform.position.z);
            }
        }
        
        private void GoForward()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
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
            _playerMovement.Activate(false);
            gameOverlayViewController.ShowDeathPanel();
            //Trigger the death SFX action
            ServiceLocator.Instance.Get<SFXService>().PlayDeathSFX();
            Debug.Log("Player died!");
        }
    }
}