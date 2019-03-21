using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public PlayerController playerController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedPercent", speedPercent);

        animator.SetBool("isAttack", playerController.isAttack);
        if (playerController.isDead)
        {
            animator.SetTrigger("isDead");
            playerController.isDead = false;
            //Game Over GUI?
        }
    }
}
