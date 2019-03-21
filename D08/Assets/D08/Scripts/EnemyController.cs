using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    public float lookRadius = 10f;
    public float shrinkSpeed = 0.1f;

    public Transform target;
    public bool isAttack;
    public bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("SpeedPercent", speedPercent);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //Attack();
            }
        }
        else
            animator.SetFloat("SpeedPercent", 0);
        //animator.SetBool("isAttack", isAttack);

        if (isDead)
        {
            animator.SetTrigger("isDead");
            isDead = false;
            Destroy(gameObject);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    //IEnumerator Dead()
    //{
    //    agent.enabled = false;
    //    //yield return new WaitForSeconds(2f);
    //    transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
    //    if (transform.localScale.y < 0)
    //    {
    //        isDead = false;
    //        Debug.Log("Game Over");
    //        Destroy(gameObject);
    //        //gameover GUI;
    //    }
    //}
}

//public float lookRadius = 10f;
//public Transform target;
//public NavMeshAgent agent;
//Movement movement;
//private Animator animator;
//public bool isInRadius;
//public Transform spawnPosition;
//public GameObject[] enemyList;

//public int hp;
//public int damage;
//public bool isDead;

//void Start()
//{
//    hp = 30;
//    damage = 5;
//    isInRadius = false;
//    agent.GetComponent<NavMeshAgent>();
//    movement = GetComponent<Movement>();
//    animator = GetComponent<Animator>();
//}

//void Update()
//{
//    float distance = Vector3.Distance(target.position, transform.position);

//    if (distance <= lookRadius)
//    {
//        movement.MoveToPoint(target.position);
//        //agent.SetDestination(target.position);
//        if (distance <= agent.stoppingDistance)
//        {
//            isInRadius = true;
//            FaceTarget();
//            //Attack();
//        }
//        else
//            isInRadius = false;
//    }
//}

//void SpawnEnemy()
//{
//    GameObject tmp = Instantiate(gameObject, spawnPosition.position, Quaternion.identity) as GameObject;
//}

//void FaceTarget()
//{
//    Vector3 direction = (target.position - transform.position).normalized;
//    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
//}

//public void GetDamage(GameObject currentEnemy)
//{
//    if (hp > 0)
//    {
//        hp -= damage;
//        if (hp <= 0)
//            Dead(currentEnemy);
//    }
//    Debug.Log("ENEMY got damaged! HP left : " + hp);
//}

//void Dead(GameObject currentEnemy)
//{
//    Destroy(currentEnemy);
//    SpawnEnemy();
//}

//private void OnDrawGizmos()
//{
//    Gizmos.color = Color.red;
//    Gizmos.DrawWireSphere(transform.position, lookRadius);
//}