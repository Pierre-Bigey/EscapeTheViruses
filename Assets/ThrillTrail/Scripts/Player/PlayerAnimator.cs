using System.Collections;
using System.Collections.Generic;
using ThrillTrail.Player;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(PlayerManager))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerManager _playerManager;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerManager = GetComponent<PlayerManager>();
    }


    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed", _playerManager.speed);
    }
}
