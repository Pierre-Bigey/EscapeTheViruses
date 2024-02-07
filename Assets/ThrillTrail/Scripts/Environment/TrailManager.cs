using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This script will automatically spawn platforms in front of the player when he is close to the last platform
/// and remove platforms that are behind the player
/// </summary>
public class TrailManager : MonoBehaviour
{
    [Tooltip("The player")]
    [SerializeField] private Transform player;
    
    
    [Header("Platform Settings")]
    [Tooltip("The platform prefab")]
    [SerializeField] private GameObject platformPrefab;
    [Tooltip("The platform parent")]
    [SerializeField] private Transform platformParent;
    [Tooltip("The distance from the player to spawn the next platform")]
    [SerializeField] private float spawnDistance = 20f;
    [Tooltip("The length of the platform (its z scale)")]
    private float platformLength;
    [Tooltip("The length of the platform (its z scale)")]
    private float platformWidth;
    
    

    private Vector3 lastPlatformPos;

    private GameObject currentPlatform;
    private GameObject nextPlatform;
    
    private void Start()
    {
        platformLength = platformPrefab.transform.localScale.z;
        platformWidth = platformPrefab.transform.localScale.x;
        
        lastPlatformPos = platformParent.position;
        currentPlatform = Instantiate(platformPrefab, lastPlatformPos-Vector3.forward*platformLength, Quaternion.identity, platformParent);
        nextPlatform = Instantiate(platformPrefab, lastPlatformPos, Quaternion.identity, platformParent);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastPlatformPos) < spawnDistance)
        {
            RemovePreviousPlatform();
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        lastPlatformPos += Vector3.forward*platformLength;
        nextPlatform = Instantiate(platformPrefab, lastPlatformPos, Quaternion.identity, platformParent);
    }

    private void RemovePreviousPlatform()
    {
        Destroy(currentPlatform);
        currentPlatform = nextPlatform;
    }

    
    
}
