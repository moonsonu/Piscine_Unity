using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    //public enum TownType {Human, Orc};
    //public TownType townPeeps;

    public GameObject Spawn;
    public Vector3 position;
    public float time;
    public float HP = 20;
    public float spawnTime = 10;
    public bool isDead;

    void Start()
    {
        isDead = false;
        //position = GameObject.FindWithTag("FootPOS").transform.position;
        CharacterSpawn();
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

    public void TakeDamage(float dmg)
    {
        if (!isDead)
        {
            HP -= 0.1f;
            Debug.Log("TownHall [" + HP + "/20]HP has been attacked");
            if (HP <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
        else
            Debug.Log("Beating a dead horse.");
    }

    void CharacterSpawn()
    {
        GameObject tmp = Instantiate(Spawn, position, Quaternion.identity) as GameObject;
    }
}
