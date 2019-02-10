using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    //private bool move = false;
    private Vector3 vector;
    public Vector3 target;
    public Vector3 direction;
    private Animator animator;
    public AudioSource runSound;
    private bool facingRight;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        vector = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            runSound.Play();
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
        }
        if (target != Vector3.zero && (target - vector).magnitude >= 0.2)
        {
            direction = (target - vector).normalized;
            if ((direction.x < 0 && facingRight) || (direction.x > 0 && !facingRight))
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("Walking", true);
            animator.SetFloat("DirX", direction.x);
            animator.SetFloat("DirY", direction.y);
        }
        else
        {
            animator.SetBool("Walking", false);
            direction = Vector3.zero;

        }
    }
    private void Flip(float flip)
    {
        if (flip < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}


        //if (Input.GetMouseButton(0))
        //{
        //    runSound.Play();
        //    animator.SetBool("Walking", true);
        //    vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    animator.SetFloat("DirX", vector.x);
        //    animator.SetFloat("DirY", vector.y);
        //    vector.z = transform.position.z;

        //    transform.position = Vector3.MoveTowards(transform.position, vector, speed* Time.deltaTime);
        //}
        //else
            //animator.SetBool("Walking", false);