using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawnTime;
    public float time;

    public bool isSpawn;

    void Start()
    {
        isSpawn = false;
        time = 0;
    }

    void Update()
    {
        time = Time.deltaTime;
        if (!isSpawn)
        {
            spawnTime = Random.Range(0, 0.5f);
            isSpawn = true;
        }
        if (spawnTime < time && isSpawn)
        {
            time = 0;
            Instantiate(zombie, transform.position, Quaternion.identity);
            isSpawn = false;
        }
    }
}
