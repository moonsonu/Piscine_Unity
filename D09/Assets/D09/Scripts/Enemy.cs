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

    public Transform target;

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
            Debug.Log(agent.velocity.magnitude + " / " + agent.speed + " = " + agent.velocity.magnitude / agent.speed);
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("SpeedPercent", speedPercent);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                //SetBool("isAttack", true);
                //StartCoroutine(Attack());
            }
            //else
                //animator.SetBool("isAttack", false);
        }
        else
            animator.SetFloat("SpeedPercent", 0);
    }

    //IEnumerator Attack()
    //{
    //    float chance = Random.value;
    //    finalDamage = baseDamage * (1 - (targetStat.myStats.getAGI / 200));
    //    if (chance > myStats.getHitChance(targetStat.myStats.getAGI))
    //    {
    //        if (myStats.getHp > 0)
    //            targetStat.myStats.getDamaged(finalDamage);
    //        else if (myStats.getHp <= 0)
    //        {
    //            //Debug.Log("game over, restart the game");
    //        }
    //    }
    //    yield return new WaitForSeconds(1f);
    //}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    //public void Dead()
    //{
    //    animator.SetTrigger("isDead");
    //    agent.enabled = false;
    //    //yield return new WaitForSeconds(2f);

    //    StartCoroutine(Shrink());

    //}

    //IEnumerator Shrink()
    //{
    //    yield return new WaitForSeconds(2f);
    //    transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
    //    if (transform.localScale.y < 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
