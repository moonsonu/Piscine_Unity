using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void fire()
    {
        Debug.Log("fire");
        GameObject tmp;
        tmp = Instantiate(bullet, transform.position, transform.rotation);
        tmp.transform.Rotate(Vector3.left * 90);
        Rigidbody tmprb;
        tmprb = tmp.GetComponent<Rigidbody>();
        tmprb.AddForce(transform.forward * 10);
        Destroy(tmp, 10);
    }
}
