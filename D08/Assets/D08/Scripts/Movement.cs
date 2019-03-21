using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerController playerController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = GetComponent<PlayerController>();
    }

    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
        playerController.isRun = false;
    }
}
