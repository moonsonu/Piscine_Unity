using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float cameralimit;
    private float currentCamRotX = 0;
    [SerializeField]
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        CameraRot();
        CharacterRot();
    }

    private void CharacterRot()
    {
        float rotY = Input.GetAxisRaw("Mouse X");
        Vector3 chacRotY = new Vector3(0, rotY, 0) * sensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(chacRotY));
    }
    private void CameraRot()
    {
        float rotX = Input.GetAxisRaw("Mouse Y");
        float camRotX = rotX * sensitivity;
        currentCamRotX -= camRotX;
        currentCamRotX = Mathf.Clamp(currentCamRotX, -cameralimit, cameralimit);
        cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0, 0);
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHor = transform.right * moveX;
        Vector3 moveVer = transform.forward * moveZ;

        Vector3 velocity = (moveHor + moveVer).normalized * speed;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovementController : MonoBehaviour
//{
//    public float speed = 6f;
//    //public float gravity = -9.8f;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float deltaX = Input.GetAxis("Horizontal") * speed;
//        float deltaZ = Input.GetAxis("Vertical") * speed;
//        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
//        //movement = Vector3.ClampMagnitude(movement, speed); //limits the max speed of the player
//        ////movement.y = gravity;
//        //movement *= Time.deltaTime;
//        ////movement = transform.TransformDirection(movement);
//        //transform.position += movement;
//        //transform.position += movement * Time.deltaTime * speed;

//        transform.Translate(movement * Time.deltaTime * speed);
//    }
//}
