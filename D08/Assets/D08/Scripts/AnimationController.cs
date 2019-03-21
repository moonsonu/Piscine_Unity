using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.1f;
    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("SpeedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);

    }
}
