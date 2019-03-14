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
    public AudioClip[] ackSound;
    private bool facingRight;
    public bool isClicked;
    public bool isAttacking = false;
    public GameObject currentenemy;
    public float HP = 10;
    public bool isDead;

    private AudioSource spotify;

    void Start()
    {
        spotify = GetComponent<AudioSource>();
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
        if (currentenemy != null)
            Attack(currentenemy);
    }

    public void FirstClicked()
    {
        PlayAck();
    }

    public void PlayAck()
    {
        int rand = 0;

        if(ackSound.Length > 0){
            rand = Random.Range(0, ackSound.Length);
            spotify.clip = ackSound[rand];
            if (spotify.clip)
                spotify.Play();
        }
        else
            Debug.LogWarning("NO AUDIO CLIP!!!!");   
    }

    void Attack(GameObject enemy)
    {
        if (isAttacking)
        {
            if (enemy.CompareTag("OrcTown"))
            {
                Building town = enemy.gameObject.GetComponent<Building>();
                Debug.Log("attackorctown");
                if (!town.isDead)
                {
                    float enemyHP = town.HP;
                    town.TakeDamage(0.1f);
                    if (enemyHP == 0)
                    {
                        currentenemy = null;
                        isAttacking = false;
                        animator.SetBool("Fighting", false);
                    }
                }
                //else
                //{
                //    Debug.Log("deadfootman");
                //    currentenemy = null;
                //    isAttacking = false;
                //    animator.SetBool("Fighting", false);
                //}
            }
            if (enemy.CompareTag("OCTownHall"))
            {
                TownHall townhall = enemy.gameObject.GetComponent<TownHall>();
                if (!townhall.isDead)
                {
                    float enemyHP = townhall.HP;
                    townhall.TakeDamage(0.1f);
                    if (enemyHP <= 0)
                    {
                        //townhall.isDead = true;
                        //Debug.Log("deadfootman");
                        currentenemy = null;
                        isAttacking = false;
                        animator.SetBool("Fighting", false);
                    }
                    //Debug.Log("Orc Townhall [" + enemyHP + "/20]HP has been attacked");
                }

            }
            if (enemy.CompareTag("Orc"))
            {
                OrcAI orc = enemy.gameObject.GetComponent<OrcAI>();
                if (!orc.isDead)
                {
                    float enemyHP = orc.HP;
                    orc.TakeDamage(0.1f);
                    if (enemyHP <= 0)
                    {
                        currentenemy = null;
                        isAttacking = false;
                        animator.SetBool("Fighting", false);
                    }
                }
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isDead)
        {
            HP -= dmg;
            Debug.Log("Footman [" + HP + "/10]HP has been attacked");
            if (HP <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }
        else
            Debug.Log("Beating a dead horse.");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontrigger");
        if (collision.gameObject.CompareTag("Orc") ||
                collision.gameObject.CompareTag("OrcTown") ||
                    collision.gameObject.CompareTag("OCTownHall"))
        {
            animator.SetBool("Fighting", true);
            isAttacking = true;
            currentenemy = collision.gameObject;
            Debug.Log(currentenemy);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Fighting", false);
        isAttacking = false;
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
