using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public float damage;
    public float speed;

    public WeaponController wc;
    [SerializeField] private Transform shootpoint;
    private Animator anim;
    public AudioSource sound;

    public GameObject particle;
    public GameObject bullet;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, wc.range))
        {
            GameObject spark = Instantiate(particle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(spark, 0.5f);
            GameObject laser = Instantiate(bullet, shootpoint.transform.position, Quaternion.identity);
            laser.transform.position = Vector3.forward * Time.deltaTime;
            //Debug.DrawRay(shootpoint.position, shootpoint.transform.forward, Color.yellow);
        }
        anim.CrossFadeInFixedTime("Fire", 0.1f);
        sound.Play();
    }
}
