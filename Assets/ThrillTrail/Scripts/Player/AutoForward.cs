using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is aimed to make the player go forward
/// </summary>
public class AutoForward : MonoBehaviour
{
    [SerializeField] private float _Speed;
    
    private bool activated = false;
    private void Update()
    {
        if (activated)
        {
            transform.Translate(Vector3.forward * (_Speed * Time.deltaTime));
        }
    }
    
    public void Activate(bool value)
    {
        activated = value;
    }
}
