using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int HP = 1;
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
}
