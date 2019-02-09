using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    //public GameObject gg;
    public GameObject[] cubePrefabs;
    string tag;
    int randcube;
    float time;
    Vector3 spawnPosition;

    void Update()
    {
        time += Time.deltaTime;
        float waittime = 2;

        if (time > waittime)
        {
            time -= waittime;
            randcube = Random.Range(0, 3);

            if (randcube == 0)
            {
                spawnPosition = new Vector3(-2.4f, 6, 0);
                tag = "a";
            }

            else if (randcube == 1)
            {
                spawnPosition = new Vector3(0, 6, 0);
                tag = "s";
            }
            else if (randcube == 2)
            {
                spawnPosition = new Vector3(2.4f, 6, 0);
                tag = "d";
            }
            GameObject prefab = Instantiate(cubePrefabs[randcube], spawnPosition, Quaternion.identity);
            prefab.tag = tag;
        }
    }
}
