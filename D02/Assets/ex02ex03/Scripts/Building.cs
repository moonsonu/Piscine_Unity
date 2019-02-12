using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int HP = 1;
    public TownHall townhall;

    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage()
    {
        HP -= 1;
        Debug.Log("Orc Building [" + HP + "/10]HP has been attacked");
        if (HP <= 0)
        {
            Destroy(gameObject);
            TownHall stime = townhall.GetComponent<TownHall>();
            stime.spawnTime *= 2.5f;
        }

    }
}
