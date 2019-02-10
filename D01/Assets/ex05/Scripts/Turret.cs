using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 10;
    public float bulletTimer;

    public bool attack;

    public GameObject bullet;
    public Transform target;
    public Transform shootpoint;

    void Update()
    {
        RangeCheck();
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < wakeRange)
            attack = true;
        else
            attack = false;
    }

    public void Attack(bool attack)
    {

        bulletTimer += Time.deltaTime;

        if (bulletTimer <= shootInterval)
        {
            if (attack)
            {
                Vector2 direction = target.transform.position - transform.position;
                direction.Normalize();
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootpoint.transform.position, shootpoint.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = shootpoint.transform.rotation * direction * bulletSpeed;
                bulletTimer = 0;
            }
        }
    }
}
