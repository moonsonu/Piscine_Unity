using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    private Animator animator;
    private Player player;
    private Collider door;
    private bool isDoor;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        door = GetComponent<Collider>();
        isDoor = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDoor)
        {
            if (collision.gameObject.tag == "Player")
                door.isTrigger = true;
        }
    }

    public void OpenDoor()
    {
        isDoor = true;
        animator.SetBool("isOpen", true);
    }
}
