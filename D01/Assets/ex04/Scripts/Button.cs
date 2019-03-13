using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorMovement dm;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        dm.Move();
    }
}
