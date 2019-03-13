using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;

    [SerializeField]
    private float speed;

    private Vector3 nexPos;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;


    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     Move();
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(other.tag);
    //     Move();
    // }
    public void Move()
    {
        Debug.Log("yogig");
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed);
        // if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        //     ChangeDestination();
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }
}
