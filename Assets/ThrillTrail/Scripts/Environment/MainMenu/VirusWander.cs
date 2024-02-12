using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//This script will be attached to virus prefabs. They will move on the background of the screen, when they reaches 
//the end of the screen + a margin, they will be teleported to the other side of the screen. They will Rotate on themselves
//and move in a random direction.
public class VirusWander : MonoBehaviour
{
    [Tooltip("The minimum speed of the virus")]
    [SerializeField] private float minSpeed = 1f;
    [Tooltip("The maximum speed of the virus")]
    [SerializeField] private float maxSpeed = 3f;
    [Tooltip("The minimum rotation speed of the virus")]
    [SerializeField] private float minRotationSpeed = 50f;
    [Tooltip("The maximum rotation speed of the virus")]
    [SerializeField] private float maxRotationSpeed = 150;
    [Tooltip("The x-margin of the screen where the virus will be teleported to the other side of the screen if it reaches it")]
    [SerializeField] private float xMargin = 0.5f;
    [Tooltip("The y-margin of the screen where the virus will be teleported to the other side of the screen if it reaches it")]
    [SerializeField] private float yMargin = 0.5f;
    
    //The direction of the virus
    private Vector3 _direction;
    //The start position of the virus
    private Vector3 _startPosition;
    
    //The rotation speed of the virus
    private float rotationSpeed;
    
    //The speed of the virus
    private float speed;
    
    //The x and y delimitation of the virus wandering zone
    private float xMax;
    private float yMax;
    
    private void Start()
    {
        float zValue = transform.position.z;
        
        //xMax and yMax are the delimitation of the wandering zone, they are calculated from the camera parameters and the zvalue, so that 
        //the xmax corresponds to the right border of the screen and the ymax to the top border of the screen at this z value
        float frustumHeight = 2.0f * Math.Abs(Camera.main.transform.position.z - zValue) * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * Camera.main.aspect;
        
        xMax = frustumWidth * 0.5f + xMargin;
        yMax = frustumHeight * 0.5f + yMargin;
        
        /*xMax = Camera.main.orthographicSize * Camera.main.aspect + xMargin;
        yMax = Camera.main.orthographicSize + yMargin;*/
        
        //The direction of the virus is a random direction
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        
        //The speed of the virus
        speed = Random.Range(minSpeed, maxSpeed);
        
        //The rotation of the virus 
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        
        //The start position is a random position inside the wandering zone
        _startPosition = new Vector3(Random.Range(-xMax, xMax), Random.Range(-yMax, yMax), zValue);
        transform.position = _startPosition;
    }

    private void Update()
    {
        //Move the virus
        transform.position += _direction * (speed * Time.deltaTime);
        
        //Rotate the virus
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
        
        //Check if the virus has reached a border of the wandering zone and reverse its direction if it is the case
        if (Mathf.Abs(transform.position.x) > xMax)
        {
            _direction = new Vector3(-_direction.x, _direction.y, _direction.z);
        }
        if (Mathf.Abs(transform.position.y) > yMax)
        {
            _direction = new Vector3(_direction.x, -_direction.y, _direction.z);
        }
        
        if (transform.position.y > yMax)
        {
            
        }
        else if (transform.position.y < -yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
    }
}
