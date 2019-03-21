using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    private int hp = 100;
    private int ammo = 8;
    public Camera cam;
    //private bool isHp;
    //private bool isAmmo;
    public float range;

    public enum Weapons { Missile, MachinGun };
    public Weapons weapons;
    //public ParticleSystem[] particles;
    public ParticleSystem gunPart;
    public ParticleSystem missilePart;
    //public GameObject particlePos;
    public int damage;
    public int index;
    public AudioClip aGun;
    public AudioClip aMissile;
    public AudioClip aHit;
    public Enemy enemy;
    public bool isDead;
    public UIController ui;
    public Image crossHair;

    void Start()
    {
        isDead = false;
        hp = 100;
        ammo = 8;
        ui.GetLife(hp);
        ui.GetMissile(ammo);
    }
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Input.GetMouseButtonDown(0))
        {
            //fire machine gun
            weapons = Weapons.MachinGun;
            gunPart.Play();
            SoundManager.instance.PlaySingle(aGun);
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (ammo > 0)
            {
                //fire missile
                weapons = Weapons.Missile;
                SoundManager.instance.PlaySingle(aMissile);
                missilePart.Play();
                Shoot();
                ammo--;
                ui.GetMissile(ammo);
            }
        }
        switch(weapons)
        {
            case Weapons.MachinGun:
                range = 5;
                damage = 10;
                index = 0;
                //currentP = particles[0];
                break;
            case Weapons.Missile:
                range = 10;
                damage = 20;
                index = 1;
                //currentP = particles[0];
                break;
        }

        if (isDead)
            SceneManager.LoadScene("ex00");
    }

    void Shoot()
    {
        //currentP.Play();
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * hit.distance, Color.red);
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                StartCoroutine(changeColor());
                StartCoroutine(EnemyGotHit());
                enemy.GetDamage(damage);
            }
        }
    }

    IEnumerator changeColor()
    {
        Debug.Log("before" + crossHair.color);
        crossHair.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("after" + crossHair.color);

        crossHair.color = Color.white;
    }

    IEnumerator EnemyGotHit()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySingle(aHit);
    }

    public void GetDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp < 0)
                isDead = true;
            ui.GetLife(hp);
        }
    }
}
