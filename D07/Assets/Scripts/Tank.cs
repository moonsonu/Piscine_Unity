using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    //private int hp = 100;
    private int ammo = 8;
    public Camera cam;
    //private bool isHp;
    //private bool isAmmo;
    public float range;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //fire machine gun
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (ammo > 0)
            {
                //fire missile
            }
        }
    }
    void Shoot()
    {
        Vector3 orgRay = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(orgRay, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("죽어랏");
            }
        }
    }
}


