using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{
    public float speed;
    public Vector3 vector;
    public Vector3 target;
    public Vector3 direction;
    private Animator animator;
    public AudioSource runSound;
    private bool facingRight;
    public bool isClicked;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        facingRight = true;
        isClicked = false;
        target = transform.position;
    }

    void Update()
    {
        if (isClicked)
        {
            vector = transform.position;
            runSound.Play();
            //if (Input.GetMouseButtonDown(0))
            //{
            //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    target.z = 0;
            //}
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
    }

    //void TakeDamage(GameObject enemy)
    //{
    //    Debug.Log("damage");
    //    int hp = enemy.GetComponent<Building>().HP;
    //    hp -= 5;
    //    Debug.Log(enemy.name);
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orc") ||
                collision.gameObject.CompareTag("OrcTown") ||
                    collision.gameObject.CompareTag("OCTownHall"))
        {
            animator.SetBool("Fighting", true);
            if (collision.gameObject.CompareTag("OrcTown"))
            {
                Building enemy = collision.GetComponent<Building>();
                if (enemy.HP > 0)
                    enemy.TakeDamage();
            }
            if (collision.gameObject.CompareTag("OCTownHall"))
            {
                TownHall enemy = collision.GetComponent<TownHall>();
                enemy.TakeDamage();
            }

        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
            //if (other.gameObject.CompareTag("OrcTown"))
            //{
            //    Building enemy = other.GetComponent<Building>();
            //    enemy.TakeDamage();
            //}
            //if (other.gameObject.CompareTag("OCTownHall"))
            //{
            //    TownHall enemy = other.GetComponent<TownHall>();
            //    enemy.TakeDamage();
            //}
            //if (other.gameObject.CompareTag("Orc"))
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Fighting", false);
    }

    //public void setDestination()
    //{
    //    //transform.position = mapPosition;
    //    vector = transform.position;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        runSound.Play();
    //        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        target.z = 0;
    //    }
    //    if (target != Vector3.zero && (target - vector).magnitude >= 0.2)
    //    {
    //        direction = (target - vector).normalized;
    //        if ((direction.x < 0 && facingRight) || (direction.x > 0 && !facingRight))
    //        {
    //            facingRight = !facingRight;
    //            Vector3 theScale = transform.localScale;
    //            theScale.x *= -1;
    //            transform.localScale = theScale;
    //        }
    //        //transform.position = Vector3.Lerp(vector, target, ((Time.time - startTime) * speed)/ Vector3.Distance(vector,target));
    //        transform.position += direction * speed;
    //        animator.SetBool("Walking", true);
    //        animator.SetFloat("DirX", target.x);
    //        animator.SetFloat("DirY", target.y);
    //    }
    //    else
    //    {
    //        animator.SetBool("Walking", false);
    //        direction = Vector3.zero;

    //    }
    //}
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