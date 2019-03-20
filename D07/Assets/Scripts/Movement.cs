using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private enum Speed { normal, boost };
    private Speed speed;
    private Rigidbody rb;
    private float velocity;

    //float mouseY = 0;
    //Vector3 orgPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Speed.normal;
        //orgPos = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        switch (speed)
        {
            case Speed.normal:
                velocity = 10f;
                break;
            case Speed.boost:
                velocity = 50f;
                break;
            default:
                break;
        }
        Debug.Log(velocity);
        if (Input.GetKey(KeyCode.LeftShift))
            speed = Speed.boost;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = Speed.normal;
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        transform.Rotate(0, moveHor, 0);
        Vector3 move = transform.forward * moveVer * velocity;
        rb.MovePosition(transform.position + move * Time.deltaTime);

        //float mouseY = Input.GetAxis("Mouse X");
        //Vector3 rot = new Vector3(0, mouseY, 0);
        //cam.transform.Rotate(rot);
        //mouseY += 15 * Input.GetAxis("Mouse X");
        //transform.eulerAngles = new Vector3(orgPos.x, mouseY, 0.0f);

    }
}
