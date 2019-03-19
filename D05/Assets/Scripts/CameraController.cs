using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameController gm;

    private float speed = 20f;
    private float mouseX;
    private float mouseY;

    public void Move()
    {
        if (transform.position.x > 58 && transform.position.x < 433)
        {
            if (Input.GetKey("a") || Input.GetKey("d"))
                transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.z > 14 && transform.position.z < 398)
        {
            if (Input.GetKey("w") || Input.GetKey("s"))
                transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        }

        if (transform.position.y > 28 && transform.position.y < 153)
        {
            if (Input.GetKey("e"))
                transform.position += transform.up * Time.deltaTime * speed;
            if (Input.GetKey("q"))
                transform.position -= transform.up * Time.deltaTime * speed;
        }
        mouseX -= speed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        mouseY += speed * Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
    }
}
