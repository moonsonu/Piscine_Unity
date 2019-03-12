using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speedKey = 50f;
    public float speedMouse = 5f;
    public float Border = 10f;
    private float mouseX;
    private float mouseY;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
            pos.z += speedKey * Time.deltaTime;

        if (Input.GetKey("s"))
            pos.z -= speedKey * Time.deltaTime;

        if (Input.GetKey("a"))
            pos.x -= speedKey * Time.deltaTime;

        if (Input.GetKey("d"))
            pos.x += speedKey * Time.deltaTime;

        if (Input.GetKey("e"))
            pos.y += speedKey * Time.deltaTime;

        if (Input.GetKey("q"))
            pos.y -= speedKey * Time.deltaTime;
        mouseX -= speedMouse * Input.GetAxis("Mouse Y");
        mouseY += speedMouse * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        transform.position = pos;
    }
}
