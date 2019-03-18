using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;

    [SerializeField]private Camera cam;

    void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed;

        rotY = Mathf.Clamp(rotY, -45, 45);
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
    }
    //public enum RotationAxis
    //{
    //    mouseX = 1,
    //    mouseY = 2
    //}

    //public RotationAxis axes = RotationAxis.mouseX;
    //public float minVert = -45f;
    //public float maxVert = 45f;
    //public float Horiz = 10f;
    //public float Vert = 10f;
    //public float rotateX = 0;

    //void Update()
    //{
    //    if (axes == RotationAxis.mouseX)
    //        transform.Rotate(0, Input.GetAxis("Mouse X") * Horiz, 0);
    //    else if (axes == RotationAxis.mouseY)
    //    {
    //        rotateX -= Input.GetAxis("Mouse Y") * Vert;
    //        rotateX = Mathf.Clamp(rotateX, minVert, maxVert);
    //        float rotateY = transform.localEulerAngles.y;
    //        rotateY = Mathf.Clamp(rotateY, minVert, maxVert);
    //        transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);

    //    }
    //}
}
