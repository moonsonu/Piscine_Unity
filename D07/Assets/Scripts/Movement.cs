using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private enum Speed { normal, boost };
    private Speed speed;
    private Rigidbody rb;
    private float velocity;
    [SerializeField] private GameObject head;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Speed.normal;
    }

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
        if (Input.GetKey(KeyCode.LeftShift))
            speed = Speed.boost;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = Speed.normal;
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        transform.Rotate(0, moveHor, 0);
        Vector3 move = transform.forward * moveVer * velocity;
        rb.MovePosition(transform.position + move * Time.deltaTime);

        var v3 = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        head.transform.Rotate((v3) * 50);
    }
}
