using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThrillTrail.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        [SerializeField]private float speed = 5f;
        [SerializeField] private float speedIncreaseRatio = 0.01f;
        
        private bool _isDead = false;
        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.Activate(true);

        }

        private void Update()
        {
            if(!_isDead)
            {
                GoForward();
                IncreaseSpeed();
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
            /*if (other.gameObject.layer == LayerMask.NameToLayer("Danger"))
            {
                Die();
            }*/
            Debug.Log("On collision enter with " + other.gameObject.name);
            if (other.gameObject.CompareTag("Danger"))
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            _playerMovement.Activate(false);
            Debug.Log("Player died!");
        }
    }
}