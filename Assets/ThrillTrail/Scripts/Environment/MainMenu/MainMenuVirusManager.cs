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
    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn the amount of virus
        for (int i = 0; i < amount; i++)
        {
            GameObject virus = Instantiate(virusPrefab, transform);
        }
    }
}
