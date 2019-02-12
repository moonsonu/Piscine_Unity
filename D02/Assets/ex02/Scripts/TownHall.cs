using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    public GameObject Spawn;
    public Vector3 position;
    public float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            CharacterSpawn();
            time = 0;
        }
    }

    void CharacterSpawn()
    {
        GameObject tmp = Instantiate(Spawn, position, Quaternion.identity) as GameObject;
    }
}
