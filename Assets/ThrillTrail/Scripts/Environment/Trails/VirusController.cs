using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mainly used to make the virus rotate and float in the air and make him emit particle when he dies
public class VirusController : MonoBehaviour
{
    [SerializeField] private bool animate;
    [Header("animation parameters")]
    [SerializeField] private float _minRotationSpeed = 10.0f;
    [SerializeField] private float _maxRotationSpeed = 30.0f;
    [SerializeField] private float _minfloatSpeed = 0.1f;
    [SerializeField] private float _maxfloatSpeed = 0.3f;
    [SerializeField] private float _minfloatAmplitude = 0.05f;
    [SerializeField] private float _maxfloatAmplitude = 0.2f;
    
    private Vector3 _initialPosition;
    private float rotationspeed;
    private float floatspeed;
    private float floatamplitude;
    
    private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _initialPosition = transform.localPosition;
        //The rotation speed is randomly set so that each virus has a different rotation speed
        rotationspeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        //The float speed is randomly set so that each virus has a different float speed
        floatspeed = Random.Range(_minfloatSpeed, _maxfloatSpeed);
        //The float amplitude is randomly set so that each virus has a different float amplitude
        floatamplitude = Random.Range(_minfloatAmplitude, _maxfloatAmplitude);
        
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
            transform.localPosition = _initialPosition + Vector3.up * (Mathf.Sin(Time.time * floatspeed) * floatamplitude);
        }
        
    }
    
    /// <summary>
    /// When the player touch this virus, it will die and emit particle
    /// </summary>
    public void PlayerTouched()
    {
        _particleSystem.Play();
        animate = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject, 1.5f);
    }
}
