using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ThrillTrail.Trail
{
    /// <summary>
    /// This script is attached to plateforms and will spawn some dangers on it at its creation
    /// </summary>
    public class TrailEndanger : MonoBehaviour
    {
        [Header("Random Settings")] [Tooltip("The probability of having two dangers on the same z value")] [SerializeField]
        private float probabilityOfTwoDangers = 0.6f;

        [Header("Dangers Settings")] [Tooltip("The dangers prefab")] [SerializeField]
        private GameObject dangerPrefab;

        [Tooltip("The distance between two dangers")] [SerializeField]
        private float dangerSpacing = 5f;

        [Tooltip("The x space for dangers to spawn on the platform")] [SerializeField]
        private float xSpacing = 1.5f;

        private float[] xPositions;

        private void OnEnable()
        {
            xPositions = new float[3] { -xSpacing, 0, xSpacing };
            //EndangerPlatform();
        }

        /// <summary>
        /// This method will randomly spawn some dangerPrefabs on the platform to make it more challenging
        /// </summary>
        public void EndangerPlatform()
        {
            for (float z = 0; z < transform.localScale.z; z += dangerSpacing)
            {
                int randomIndex = Random.Range(0, xPositions.Length);
                float x = xPositions[randomIndex];
                Vector3 cubePosition = new Vector3(x, 0.5f, z + transform.position.z - transform.localScale.z / 2);
                var danger = Instantiate(dangerPrefab, cubePosition, Quaternion.identity);
                danger.transform.parent = transform;

                if (Random.value <= probabilityOfTwoDangers)
                {
                    int secondRandomIndex = Random.Range(0, xPositions.Length);
                    while (secondRandomIndex == randomIndex)
                    {
                        secondRandomIndex = Random.Range(0, xPositions.Length);
                    }

                    x = xPositions[secondRandomIndex];
                    cubePosition = new Vector3(x, 0.5f, z + transform.position.z - transform.localScale.z / 2);
                    danger = Instantiate(dangerPrefab, cubePosition, Quaternion.identity);
                    danger.transform.parent = transform;
                }
            }
        }
    }
}
