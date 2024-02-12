using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will make spawn a certain amour of virus in the main menu
public class MainMenuVirusManager : MonoBehaviour
{
    [Tooltip("The virus prefab")]
    [SerializeField] private GameObject virusPrefab;
    [Tooltip("The amount of virus to spawn")]
    [SerializeField] private int amount = 10;
    
    [Tooltip("The min-z value of the virus")]
    [SerializeField] private float minZ = 0;
    [Tooltip("The max-z value of the virus")]
    [SerializeField] private float maxZ = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn the amount of virus
        for (int i = 0; i < amount; i++)
        {
            float zValue = Random.Range(minZ, maxZ);
            GameObject virus = Instantiate(virusPrefab, new Vector3(0,0,zValue),Quaternion.identity,transform);
        }
    }
}
