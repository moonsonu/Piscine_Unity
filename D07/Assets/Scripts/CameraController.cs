using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    private Vector3 offset;
    float mouseY = 0;
    Vector3 orgPos;

    void Start()
    {
        offset = transform.position - tank.transform.position;
        orgPos = transform.eulerAngles;
    }

    void Update()
    {
        ////Vector3 CenterPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        ////gameObject.transform.position = CenterPos;
        //mouseY += 15 * Input.GetAxis("Mouse X");
        //transform.eulerAngles = new Vector3(orgPos.x, mouseY, 0.0f);
        ////transform.position = tank.transform.position + offset;
        //transform.LookAt(tank.transform);

    }
}
