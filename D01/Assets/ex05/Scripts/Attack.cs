using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Turret turretAI;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Thomas")
            turretAI.Attack(true);
    }
}
