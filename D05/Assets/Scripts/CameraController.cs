using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject gb;
    [SerializeField] private Transform boundary;
    [SerializeField] private GolfBall golfBall;
    [SerializeField] private GameObject flag;

    public float speed = 20f;
    public float Border = 10f;
    private float mouseX;
    private float mouseY;
    private Vector3 offset;
    private Vector3 offsetcam;

    private Camera cam;

    private bool isView = false;
    public bool IsView { get { return isView; } }
    private bool isReadytoShot = true;
    public bool IsReadytoShot { get { return isReadytoShot; } }
    private Vector3 orgPosBall;



    void Start()
    {
        cam = GetComponent<Camera>();
        orgPosBall = gb.transform.position;
        offset = transform.position - gb.transform.position;
    }

    public void Ball()
    {
        transform.position = gb.transform.position + offset;
        transform.LookAt(gb.transform);
    }

    void Update()
    {
        
        //transform.position = gb.transform.position + offset;
        //transform.LookAt(gb.transform);

        if (isView)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                cam.fieldOfView -= 1;
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                cam.fieldOfView += 1;

            if (cam.transform.position.x > 58 && cam.transform.position.x < 433)
            {
                if (Input.GetKey("a") || Input.GetKey("d"))
                    cam.transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);
            }

            if (cam.transform.position.z > 14 && cam.transform.position.z < 398)
            {
                if (Input.GetKey("w") || Input.GetKey("s"))
                    cam.transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
            }

            if (cam.transform.position.y > 28 && cam.transform.position.y < 153)
            {
                if (Input.GetKey("e"))
                {
                    cam.transform.position += cam.transform.up * Time.deltaTime * speed;
                    isView = true;
                    isReadytoShot = false;
                }
                if (Input.GetKey("q"))
                    cam.transform.position -= cam.transform.up * Time.deltaTime * speed;
            }

            if (Input.GetKeyDown("space"))
            {
                if (isView)
                {
                    Debug.Log("isview");
                    cam.transform.position = orgPosBall + offset;

                    isView = false;
                    isReadytoShot = false;
                    golfBall.isPowered = false;
                }

                if (!isView)
                {
                    if (Input.GetKeyDown("space"))
                        isReadytoShot = true;
                }
            }
            mouseX -= speed * Input.GetAxis("Mouse Y") * Time.deltaTime;
            mouseY += speed * Input.GetAxis("Mouse X") * Time.deltaTime;
            transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        }


        //viewmode and ballmode
        //if (isView)
        //{
        //    mouseX -= speed * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //    mouseY += speed * Input.GetAxis("Mouse X") * Time.deltaTime;
        //    transform.eulerAngles = new Vector3(mouseX, mouseY, 0);
        //}

        if (!isView)
        {
            golfBall.isRotate = true;
        //    //offsetcam = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * speed, Vector3.up) * offset;
        //    //transform.position = gb.transform.position + offset;
        //    //transform.LookAt(gb.transform.position);
        //    //transform.RotateAround(gb.transform.position, transform.up, Input.GetAxis("Horizontal") * speed);

        //    //transform.LookAt(gb.transform);
        //    var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        //    transform.Rotate(v3 * speed * Time.deltaTime);
        //    //transform.LookAt(gb.transform);
        //    //transform.Translate(Vector3.right * Time.deltaTime);
            if (Input.GetKeyDown("e"))

                transform.SetParent(null);
                Debug.Log("hereee");
                isView = true;
                golfBall.isRotate = false;
            {
                golfBall.rotateBall();

            }
        }

        //if (!gbscript.isMoving)
            //cam.transform.position = gb.transform.position;
    }
}
