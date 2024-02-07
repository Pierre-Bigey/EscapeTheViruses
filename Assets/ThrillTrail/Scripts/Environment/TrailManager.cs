using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// This script will automatically spawn platforms in front of the player when he is close to the last platform
/// and remove platforms that are behind the player
/// </summary>
public class TrailManager : MonoBehaviour
{
    [Tooltip("The player")]
    [SerializeField] private Transform player;
    [Tooltip("The platform prefab")]
    [SerializeField] private GameObject platformPrefab;
    [Tooltip("The platform parent")]
    [SerializeField] private Transform platformParent;
    [Tooltip("The distance from the player to spawn the next platform")]
    [SerializeField] private float spawnDistance = 20f;
    [Tooltip("The distance from the player to spawn the next platform")]
    [SerializeField] private float platformScale = 50;

    private Vector3 lastPlatformPos;

    private GameObject currentPlatform;
    private GameObject nextPlatform;
    
    private void Start()
    {
        lastPlatformPos = platformParent.position;
        currentPlatform = Instantiate(platformPrefab, lastPlatformPos-Vector3.forward*platformScale, Quaternion.identity, platformParent);
        nextPlatform = Instantiate(platformPrefab, lastPlatformPos, Quaternion.identity, platformParent);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, lastPlatformPos) < spawnDistance)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        Destroy(currentPlatform);
        currentPlatform = nextPlatform;
        
        lastPlatformPos += Vector3.forward*platformScale;
        nextPlatform = Instantiate(platformPrefab, lastPlatformPos, Quaternion.identity, platformParent);
    }

    private void RemovePreviousPlatform()
    {
        
    }
    
}
