using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject gb;
    public Transform flag;
    public float speed = 10f;
    public float Border = 10f;
    private float mouseX;
    private float mouseY;
    private Vector3 offset;
    private Camera cam;
    private bool viewMode = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        Debug.Log(flag.Find("Camera01.target").name);
        flag = flag.Find("Camera01.target").transform;
        cam.transform.position = gb.transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            cam.fieldOfView -= 1;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            cam.fieldOfView += 1;
        
        if (Input.GetKey("a") || Input.GetKey("d"))
            cam.transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("w") || Input.GetKey("s"))
            cam.transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        if (Input.GetKey("e"))
            cam.transform.position += cam.transform.up * Time.deltaTime * speed;
        if (Input.GetKey("q"))
            cam.transform.position -= cam.transform.up * Time.deltaTime * speed;
        
        if (Input.GetKeyDown("e"))
        {
            cam.transform.position += cam.transform.up * 30f;
            viewMode = true;
        }
        if (Input.GetKeyDown("space"))
        {
            viewMode = false;
            cam.transform.position = gb.transform.position;
            cam.transform.LookAt(flag); 
        }
        if (viewMode)
        {
            mouseX -= speed * Input.GetAxis("Mouse Y") * Time.deltaTime;
            mouseY += speed * Input.GetAxis("Mouse X") * Time.deltaTime;
            transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        }
    }
}
