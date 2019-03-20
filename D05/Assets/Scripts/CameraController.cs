using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraState { Free, Aiming, Following };
    public CameraState cs;
    public Transform ball;

    public Vector3 cameraBallOffset;

    [SerializeField] private GameController gm;

    private float speed = 20f;
    private float mouseX;
    private float mouseY;
    private Vector3 Pos;
    private void Start()
    {
        cs = CameraState.Aiming;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            this.cs = CameraState.Free;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            this.cs = CameraState.Aiming;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            this.cs = CameraState.Following;


        switch (cs)
        {
            case CameraState.Free:
                Move();
                break;
            case CameraState.Aiming:
                Aim();
                break;
            case CameraState.Following:
                Follow();
                break;
        }
    }

    public void Aim()
    {
        transform.position = ball.transform.position + this.cameraBallOffset;
        var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(v3 * 50 * Time.deltaTime);
    }

    public void Follow()
    {
        transform.position = ball.transform.position + this.cameraBallOffset;
    }

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
