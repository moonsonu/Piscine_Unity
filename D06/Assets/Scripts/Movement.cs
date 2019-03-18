using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
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
    public AudioClip aWalk;
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

        if (moveX == 1 || moveX == -1 || moveZ == 1 || moveZ == -1)
            SoundManager.instance.PlaySingle(aWalk);
            
        Vector3 moveHor = transform.right * moveX;
        Vector3 moveVer = transform.forward * moveZ;

        Vector3 velocity = (moveHor + moveVer).normalized * speed;
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }
}
