using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float HP = 10;
    public TownHall townhall;
    public bool isDead;

    void Start()
    {
        isDead = false;
    }

    void Update()
    {
        if (isDead)
        {
            Debug.Log("dbuildingdead");
            isDead = true;
            gameObject.SetActive(false);
            TownHall stime = townhall.GetComponent<TownHall>();
            stime.spawnTime += 2.5f;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isDead)
        {
            HP -= 0.1f;
            Debug.Log("Building [" + HP + "/10]HP has been attacked");
            if (HP <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
        else
            Debug.Log("Beating a dead horse.");
    }
}
