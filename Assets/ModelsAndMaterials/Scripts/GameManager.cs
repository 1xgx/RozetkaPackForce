using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private BoxesSpawner _spawner;
    
    public void SpawnClick()
    {
        _spawner.Spawn();
    }
}
