using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    void Start()
    {
        GetComponent<ConstantForce>().enabled = false;   
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<ConstantForce>().enabled = true;
            Debug.Log("space");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy(this.gameobject);
        Debug.Log("fire");
    }
}
