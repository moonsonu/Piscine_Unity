using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float range;
    public float damage;
    public float speed;

    public enum WeaponType { Msbs, Zod };
    public WeaponType weaponType;
    [SerializeField] private GameObject[] weapons;

    void Start()
    {
        InitializeGun();
    }

    void Update()
    {
        switch (weaponType)
        {
            case WeaponType.Msbs:
                range = 500;
                damage = 5;
                speed = 0.5f;
                break;
            case WeaponType.Zod:
                range = 1000;
                damage = 10;
                speed = 1;
                break;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = WeaponType.Msbs;
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = WeaponType.Zod;
            weapons[1].SetActive(true);
            weapons[0].SetActive(false);
        }
    }

    private void InitializeGun()
    {
        weaponType = WeaponType.Msbs;
        weapons[0].SetActive(true);
        weapons[1].SetActive(false);
    }
}
