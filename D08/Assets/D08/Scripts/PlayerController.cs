using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    Movement movement;
    private Animator animator;
    public bool isRun = false;

    void Start()
    {
        cam = Camera.main;
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                isRun = true;
                movement.MoveToPoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                
            }
        }
    }
}
