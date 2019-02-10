using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    //private bool move = false;
    private Vector3 vector;
    public GameObject target;
    private Animator animator;
    public AudioSource runSound;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("Walking", false);
        if (Input.GetMouseButton(0))
        {
            runSound.Play();
            animator.SetBool("Walking", true);
            vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);
            vector.z = transform.position.z;

            transform.position = Vector3.MoveTowards(transform.position, vector, speed * Time.deltaTime);
        }
        else
            animator.SetBool("Walking", false);



    }
}
