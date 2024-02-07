using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement),typeof(AutoForward))]
public class PlayerManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private AutoForward _autoForward;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _autoForward = GetComponent<AutoForward>();
        _playerMovement.Activate(true);
        _autoForward.Activate(true);
    }


    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Danger"))
        {
            Die();
        }*/
        if (other.gameObject.CompareTag("Danger"))
        {
            Die();
        }
    }

    private void Die()
    {
        _playerMovement.Activate(false);
        _autoForward.Activate(false);
        Debug.Log("Player died!");
    }
}
