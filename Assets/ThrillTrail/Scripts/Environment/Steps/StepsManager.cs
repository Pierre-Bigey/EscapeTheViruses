using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// This script will Manage steps :
/// It will summon steps when the players frustrum is about to reach the end of the steps
/// and delete the steps that are behind the player.
/// When summonning a step, it will pick one of the available steps and place it at the end of the steps
/// </summary>
public class StepsManager : MonoBehaviour
{
    // The player transform
    [SerializeField] private Transform playerTransform;
    // The safe step prefab
    [SerializeField] private GameObject safeStep;
    // The list of available steps
    [SerializeField] private List<GameObject> endangeredSteps;
    // The list of the steps that are currently active
    private List<GameObject> activeSteps = new List<GameObject>();
    // The distance between the player and the last step
    [SerializeField] private float distanceBetweenPlayerAndLastStep = 10f;
    // The distance between the steps
    [SerializeField] private float distanceBetweenSteps = 5f;
    // The number of steps that are initially active
    [SerializeField] private int initialStepsCount = 5;
    // The number of steps that are initially active
    [SerializeField] private float stepsDeletionDistance = 10f;
    private void Start()
    {
        // Initialize the active steps
        for (int i = 0; i < initialStepsCount; i++)
        {
            SpawnSafeStep();
        }
    }
    private void Update()
    {
        // Check if the last step is behind the player
        if (activeSteps.Count > 0 && activeSteps[activeSteps.Count - 1].transform.position.z < playerTransform.position.z + distanceBetweenPlayerAndLastStep)
        {
            SpawnEndangeredSpawnStep();
        }
        // Check if the first step is behind the player
        if (activeSteps.Count > 0 && activeSteps[0].transform.position.z < playerTransform.position.z - stepsDeletionDistance)
        {
            RemoveStep();
        }
    }
    private void SpawnEndangeredSpawnStep()
    {
        // Pick a random step from the available steps
        GameObject step = Instantiate(endangeredSteps[Random.Range(0, endangeredSteps.Count)], transform, true);
        // Place it at the end of the steps
        Vector3 position = Vector3.zero;
        if (activeSteps.Count > 0)
        {
            position = activeSteps[activeSteps.Count - 1].transform.position + Vector3.forward * distanceBetweenSteps;
        }
        step.transform.position = position;
        step.SetActive(true);
        activeSteps.Add(step);
    }
    private void SpawnSafeStep()
    {
        // Pick a random step from the available steps
        GameObject step = Instantiate(safeStep, transform, true);
        // Place it at the end of the steps
        Vector3 position = Vector3.zero;
        if (activeSteps.Count > 0)
        {
            position = activeSteps[activeSteps.Count - 1].transform.position + Vector3.forward * distanceBetweenSteps;
        }
        step.transform.position = position;
        step.SetActive(true);
        activeSteps.Add(step);
    }
    
    private void RemoveStep()
    {
        // Deactivate the first step
        var step = activeSteps[0];
        // Remove it from the active steps list
        activeSteps.RemoveAt(0);
        Destroy(step);
    }
}