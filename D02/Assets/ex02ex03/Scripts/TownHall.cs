using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    public GameObject Spawn;
    public Vector3 position;
    public float time = 0.0f;
    public int HP = 20;
    public float spawnTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            CharacterSpawn();
            time = 0;
        }
    }

    void CharacterSpawn()
    {
        GameObject tmp = Instantiate(Spawn, position, Quaternion.identity) as GameObject;
    }

    public void TakeDamage()
    {
        HP -= 1;
        Debug.Log("Orc Townhall [" + HP + "/20]HP has been attacked");
        if (HP < 0)
        {
            Destroy(gameObject);
            Debug.Log("The Human Team wins");
        }
    }
}
