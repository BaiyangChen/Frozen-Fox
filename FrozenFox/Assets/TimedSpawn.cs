using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    Vector3 InitPosition;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InitPosition = transform.position;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, InitPosition, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
    
}
