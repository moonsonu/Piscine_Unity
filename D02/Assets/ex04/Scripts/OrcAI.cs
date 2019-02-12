using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAI : MonoBehaviour
{
    public float speed;
    private Vector3 target;
    private Vector3 orcPosition;
    public Vector3 direction;
    private Animator animator;
    private bool facingRight;
    public GameObject footman;
    public bool isDead;
    public int HP = 10;

    void Start()
    {
        orcPosition = transform.position;
        target = footman.transform.position;
        animator = GetComponentInChildren<Animator>();
        facingRight = true;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (orcPosition != Vector3.zero && (orcPosition - target).magnitude >= 0.2)
        {
            direction = (orcPosition - target).normalized;
            if ((direction.x < 0 && facingRight) || (direction.x > 0 && !facingRight))
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("Walking", true);
            animator.SetFloat("DirX", direction.x);
            animator.SetFloat("DirY", direction.y);
        }
        else
        {
            animator.SetBool("Walking", false);
            direction = Vector3.zero;

        }
        if (isDead)
        {
            Debug.Log("dbuildingdead");
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Footman") ||
                collision.gameObject.CompareTag("FootmanTown") ||
                    collision.gameObject.CompareTag("FMTownHall"))
        {
            animator.SetBool("Fighting", true);
            //isAttacking = true;
            //currentenemy = collision.gameObject;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Fighting", false);
        //isAttacking = false;
    }
}
