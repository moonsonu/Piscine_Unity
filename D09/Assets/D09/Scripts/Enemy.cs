using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public float lookRadius = 10f;
    public float shrinkSpeed = 0.1f;
    public enum enemyState { Free, Attack, Dead };
    public enemyState es;
    public Transform target;
    public float distance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(target.gameObject.transform.position, transform.position);
        switch (es)
        {
            case enemyState.Free:
                Move();
                break;
            case enemyState.Attack:
                Attack();
                break;
            case enemyState.Dead:
                animator.SetTrigger("isDead");
                break;
        }
    }

    void Move()
    {
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.transform.position);
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("SpeedPercent", speedPercent);
            if (distance <= agent.stoppingDistance)
            {
                es = enemyState.Attack;
            }
        }

        else
        {
            animator.SetFloat("SpeedPercent", 0);
        }
    }

    void Attack()
    {
        if (distance <= agent.stoppingDistance)
        {
            //FaceTarget();
            animator.SetFloat("SpeedPercent", 0);
            animator.SetBool("isAttack", true);
            //if (isAttack)
            //StartCoroutine(Attacking());
            //target.Damaged(finalDamage);
        }
        else
        {
            es = enemyState.Free;
            animator.SetBool("isAttack", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}