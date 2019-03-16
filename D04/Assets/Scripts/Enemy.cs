using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance;
    public float range = 8;
    public float shootInterval = 3;
    public float bulletSpeed = 20;
    public float bulletTimer;

    public bool awake;
    public bool isDead = false;
    public GameObject bullet;
    public Transform target;
    public Transform shootPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        bulletTimer += Time.deltaTime;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        if (distance < range)
        {
            if (bulletTimer >= shootInterval)
            {
                GameObject bulletclon;
                bulletclon = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
                bulletclon.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
        }
    }

    //public void Attack()
    //{
    //    Debug.Log("attack");
    //    bulletTimer += Time.deltaTime;
    //    if (bulletTimer >= shootInterval)
    //    {
    //        Vector2 direction = target.transform.position - transform.position;
    //        direction.Normalize();
    //        //if (awake)
    //        //{
    //            GameObject bulletclon;
    //            bulletclon = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
    //            bulletclon.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    //            bulletTimer = 0;
    //        //}
    //        //if (!awake)
    //            //bulletTimer = 0;
    //    }
    //}
}
