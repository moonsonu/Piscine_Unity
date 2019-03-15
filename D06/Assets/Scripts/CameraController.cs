using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum RotationAxis
    {
        mouseX = 1,
        mouseY = 2
    }

    public RotationAxis axes = RotationAxis.mouseX;
    public float minVert = -45f;
    public float maxVert = 45f;
    public float Horiz = 10f;
    public float Vert = 10f;
    public float rotateX = 0;

    void Update()
    {
        if (axes == RotationAxis.mouseX)
            transform.Rotate(0, Input.GetAxis("Mouse X") * Horiz, 0);
        else if (axes == RotationAxis.mouseY)
        {
            rotateX -= Input.GetAxis("Mouse Y") * Vert;
            rotateX = Mathf.Clamp(rotateX, minVert, maxVert);
            float rotateY = transform.localEulerAngles.y;
            rotateY = Mathf.Clamp(rotateY, minVert, maxVert);
            transform.localEulerAngles = new Vector3(rotateX, rotateY, 0);
        }
    }
}
