using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private GameController gm;
    [SerializeField] private CameraController cam;

    private bool isGameover = false;
    private bool isNext = false;
    private Rigidbody rb;
    private bool isMoving;
    public bool IsMoving { get { return isMoving; } }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Rotate()
    {
        cam.transform.parent = this.transform;
        var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate((v3) * 50 * Time.deltaTime);
        cam.gameObject.transform.LookAt(this.transform);
    }

    public void NotRotate()
    {
        Debug.Log("dkdsyd");
        cam.transform.parent = null;
    }

    public void shoot(float power)
    {
        rb.velocity = transform.forward * power * 50;
        isMoving = true;
    }
    private void Update()
    {
        if (isMoving)
        {
            NotRotate();
            float threshold = 100f;
            float gbVel = rb.velocity.sqrMagnitude;
            bool stop;

            Debug.Log(gbVel);
            if (gbVel < threshold)
                stop = true;
            else
                stop = false;

            if (stop)
            {
                rb.drag = 10;
                rb.angularDrag = 10;
                isMoving = false;
            }
            else if (!stop)
            {
                rb.drag = 0;
                rb.angularDrag = 0.05f;

            }
        }

        if (isGameover)
        {
            GameObject gameover = GameObject.Find("GameOverUI");
            Debug.Log(gameover.GetComponentInChildren<Canvas>());
            gameover.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        if (isNext)
        {
            GameObject nextLevel = GameObject.Find("NextLevelUI");
            nextLevel.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("nextLevel");
            }
        }
        //if (!isMoving)
        //{
        //    gm.NotView();

        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            isNext = true;

        }
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
