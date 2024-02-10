using ThrillTrail.Player;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(PlayerManager))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float value)
    {
        _animator.SetFloat("speed", value);
    }
    
}
