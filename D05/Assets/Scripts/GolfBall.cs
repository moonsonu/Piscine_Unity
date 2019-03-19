using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public bool isPowered = false;
    private Rigidbody rb;
    public AudioClip shootSound;
    public AudioClip GameoverSound;
    private AudioSource sound;
    public bool isMoving = false;
    public bool isGameover = false;
    public bool isNextlevel = false;
    public bool isRotate;
    public float time;
    public GameObject arrow;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private KeyController keyController;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        isRotate = true;
    }

    void shoot()
    {
        Debug.Log("space" + keyController.Power);
        rb.velocity = transform.forward * keyController.Power * 50;
        //Debug.Log(movement);
        //rb.AddForce(Camera.main.transform.forward * keyController.Power * 1000);
        isMoving = true;
    }

    public void rotateBall()
    {
        if (isRotate)
        {
                //arrow.SetActive(true);
            cameraController.transform.parent = this.transform;
            var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            transform.Rotate(v3* 50 * Time.deltaTime);

                //cameraController.gameObject.transform.rotation = transform.rotation;

            cameraController.gameObject.transform.LookAt(this.transform);
        }

        if (!isRotate)
            cameraController.transform.parent = null;
    }

    void Update()
    {
        if (cameraController.IsView)
            isRotate = false;
        if (!cameraController.IsView)
            isRotate = true;
        if (isRotate)
        {
            //arrow.SetActive(true);
            cameraController.transform.parent = this.transform;
            var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            transform.Rotate(v3 * 50 * Time.deltaTime);

            //cameraController.gameObject.transform.rotation = transform.rotation;

            cameraController.gameObject.transform.LookAt(this.transform);
        }

        if (!isRotate)
            cameraController.transform.parent = null;
        time += Time.deltaTime;
        if (!cameraController.IsView)
        {
            if (isPowered)
            {
                shoot();
                isPowered = false;
            }
        }

        if (isMoving)
        {
            float threshold = 100f;
            float gbVel = rb.velocity.sqrMagnitude;
            bool stop;

            Debug.Log(gbVel);
            if (gbVel < threshold)
            {
                stop = true;
                //Debug.Log(stop);
            }
            else
            {
                stop = false;
                //Debug.Log("stop " + stop);
            }

            if (stop)
            {
                //Debug.Log("drag");
                rb.drag = 10;
                rb.angularDrag = 10;
                isMoving = false;
                isRotate = true;
            }
            else if (!stop)
            {
                rb.drag = 0;
                rb.angularDrag = 0.05f;

            }
        }
        if (!isMoving)
        {
            isRotate = true;
            rotateBall();
        }

        //else
        //{
        //    sound.clip = shootSound;
        //    sound.Play();
        //}

        //if (isGameover)
        //{
        //    sound.clip = GameoverSound;
        //    sound.Play();
        //    GameObject gameover = GameObject.Find("GameOverUI");
        //    Debug.Log(gameover.GetComponentInChildren<Canvas>());
        //    gameover.GetComponent<Canvas>().enabled = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
            Debug.Log("Success!!!");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.SetActive(false);
            Debug.Log("water");
            isGameover = true;
        }
    }
}
