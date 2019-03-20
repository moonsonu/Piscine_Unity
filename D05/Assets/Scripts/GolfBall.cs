using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GolfBall : MonoBehaviour
{
    [SerializeField] private GameController gm;
    [SerializeField] private CameraController cam;
    [SerializeField] private UIController ui;
    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject nextLevel;

    private bool isGameover = false;
    private bool isNext = false;
    private Rigidbody rb;
    private bool isMoving;
    public bool IsMoving { get { return isMoving; } }
    public Quaternion orgBallRot;
    public Vector3 orgBallPos;
    public bool isFirst = true;
    public bool isWin = false;
    public float forward;
    public float up;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        orgBallPos = transform.position;
        orgBallRot = transform.rotation;
    }

    public void Rotate()
    {
        if (isFirst)
        {
            this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            cam.transform.position = transform.position + gm.Offset;

            Debug.Log(transform.rotation);
            isFirst = false;
            cam.gameObject.transform.LookAt(this.transform);
        }
        if (!isFirst)
        {
            cam.transform.parent = this.transform;
            var v3 = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            transform.Rotate((v3) * 50 * Time.deltaTime);
            cam.gameObject.transform.LookAt(this.transform);
        }

    }

    public void NotRotate()
    {
        Debug.Log("dkdsyd");
        cam.transform.parent = null;
    }

    public void shoot(float power, float forward, float up)
    {
        rb.velocity = (transform.forward * forward + transform.up * up) * power * 50;
        isMoving = true;
        //isFirst = true;
        //forward *= 20.0f * uiController.powerLevel;
        //up *= 20.0f * uiController.powerLevel;
        //rb.AddForce((transform.forward * forward + transform.up * power), ForceMode.Impulse);
    }
    private void Update()
    {
        if (isMoving)
        {
            Debug.Log("inmoving" + gm.IsView);
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

        if (isWin)
        {
            
            //GameObject gameover = GameObject.Find("GameOverUI");
            //Debug.Log(gameover.GetComponentInChildren<Canvas>());
            //gameover.GetComponent<Canvas>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        if (isGameover)
        {
            gameover.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (isNext)
        {
            Debug.Log("nexlevel");
            nextLevel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gm.level++;
                gm.parnumber++;
                ui.SettabPanel();
                nextLevel.SetActive(false);
                Debug.Log("nextLevel");
            }
        }
        //if (!isMoving)
        //{
        //    transform.rotation = orgBallRot;
        //    cam.transform.position = orgBallPos + gm.Offset;

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gm.level.ToString())
        {
            isNext = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            cam.transform.position = orgBallPos;
            isGameover = true;
            //gameObject.SetActive(false);
            Debug.Log("water");
        }
    }
}
