using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    public GameObject Spawn;
    public Vector3 position;
    public float time;
    public int HP = 20;
    public float spawnTime = 10;
    public bool isDead;

    void Start()
    {
        isDead = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            CharacterSpawn();
            time = 0;
        }

        if (isDead)
        {
            Debug.Log("dbuildingdead");
            isDead = true;
            gameObject.SetActive(false);
        }
    }

    void CharacterSpawn()
    {
        GameObject tmp = Instantiate(Spawn, position, Quaternion.identity) as GameObject;
    }
}
