using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ballObj;
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
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, ballObj.GetComponent<Rigidbody>().velocity.z); 
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            if (pos.z <= Screen.width)
                pos.z += speedKey * Time.deltaTime;
        }

        if (Input.GetKey("s"))
            pos.z -= speedKey * Time.deltaTime;

        if (Input.GetKey("a"))
        {
            if (pos.x >= 50)
                pos.x -= speedKey * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            if (pos.x <= Screen.width + 50)
                pos.x += speedKey * Time.deltaTime;
        }

        if (Input.GetKey("e"))
        {
            if (pos.y <= Screen.height)
                pos.y += speedKey * Time.deltaTime;
        }

        if (Input.GetKey("q"))
        {
            if (pos.y >= 0)
                pos.y -= speedKey * Time.deltaTime;
        }
        //mouseX -= speedMouse * Input.GetAxis("Mouse Y");
        //mouseY += speedMouse * Input.GetAxis("Mouse X");
        //transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        transform.position = pos;
    }
}
