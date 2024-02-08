using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mainly used to make the virus rotate and float in the air
public class VirusController : MonoBehaviour
{
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

    private void OnEnable()
    {
        _initialPosition = transform.localPosition;
        //The rotation speed is randomly set so that each virus has a different rotation speed
        rotationspeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        //The float speed is randomly set so that each virus has a different float speed
        floatspeed = Random.Range(_minfloatSpeed, _maxfloatSpeed);
        //The float amplitude is randomly set so that each virus has a different float amplitude
        floatamplitude = Random.Range(_minfloatAmplitude, _maxfloatAmplitude);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
        transform.localPosition = _initialPosition + Vector3.up * (Mathf.Sin(Time.time * floatspeed) * floatamplitude);
    }
}
