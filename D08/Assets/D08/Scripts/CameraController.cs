using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2;
    private float currentZoon = 10f;

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoon;
        transform.LookAt(target.position + Vector3.up * pitch);
    }

    //public Transform lookAt;
    //public Transform camTransform;

    //private Camera cam;
    //private float distance = 10;
    //private float currentX = 0;
    //private float currentY = 0;
    //private float sensivityX = 0;
    //private float sensivityY = 0;

    //void Start()
    //{
    //    camTransform = transform;
    //    cam = Camera.main;
    //}

    //private void LateUpdate()
    //{
    //    Vector3 dir = new Vector3(0, 0, -distance);
    //    Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
    //    camTransform.position = lookAt.position + rotation * dir;
    //    camTransform.LookAt(lookAt.position);
    //}

    //void Update()
    //{
    //    currentX += Input.GetAxis("Mouse X");
    //    currentY += Input.GetAxis("Mouse Y");
    //    currentY = Mathf.Clamp(currentY, -45, 45);
    //}
}
