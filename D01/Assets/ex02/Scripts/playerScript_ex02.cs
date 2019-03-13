using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex02 : MonoBehaviour
{
    public GameObject currentPlayer;
    public Exit ThomasExit;
    public Exit JohnExit;
    public Exit ClaireExit;
    public GameObject Thomas;
    public GameObject John;
    public GameObject Claire;
    public GameObject tg;
    public GameObject jg;
    public GameObject cg;
    //public Gameobject door;

    private Rigidbody2D rb;
    private Rigidbody2D tr;
    private Rigidbody2D jr;
    private Rigidbody2D cr;
    private BoxCollider2D colT;
    private BoxCollider2D colJ;
    private BoxCollider2D colC;

    private float moveInput;
    private float[] speed = new float[3];
    private float[] jump = new float[3];
    private int i;
    private int currentLevel;
    //private int nextLevel;

    private bool IsGround;

    public DoorMovement dm;

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentPlayer = GameObject.Find("Thomas");
        tr = Thomas.GetComponent<Rigidbody2D>();
        jr = John.GetComponent<Rigidbody2D>();
        cr = Claire.GetComponent<Rigidbody2D>();


        speed[0] = 5f;
        speed[1] = 6f;
        speed[2] = 4f;
        jump[0] = 8f;
        jump[1] = 10f;
        jump[2] = 6f;
        i = 0;
        IsGround = true;

        tr.isKinematic = false;
        jr.isKinematic = true;
        cr.isKinematic = true;

        DisableChild(tg);
        AbleChild(jg);
        AbleChild(cg);
        // colT.isTrigger = false;
        // colJ.isTrigger = true;
        // colC.isTrigger = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
                collision.gameObject.tag == "Thomas" ||
                    collision.gameObject.tag == "John" ||
                        collision.gameObject.tag == "Claire")
            IsGround = true;
        if (collision.gameObject.tag == "Teleport")
            currentPlayer.transform.position = collision.transform.GetChild(0).position;
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "RedButton" && currentPlayer.tag == "Thomas")
        {
            Destroy(collision.gameObject);
            dm.Move();
        }
        if (collision.gameObject.tag == "Bomb")
            Destroy(door);
    }

    void Update()
    {
        rb = currentPlayer.GetComponent<Rigidbody2D>();

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed[i], rb.velocity.y);
        if (Input.GetKey("1"))
        {
            i = 0;
            rb.isKinematic = true;
            currentPlayer = GameObject.Find("Thomas");
            rb.isKinematic = false;
            //tr.isKinematic = false;
            jr.isKinematic = true;
            cr.isKinematic = true;

            DisableChild(tg);
            AbleChild(jg);
            AbleChild(cg);
            //colT.isTrigger = false;
            //colJ.isTrigger = true;
            //colC.isTrigger = true;
        }
        else if (Input.GetKey("2"))
        {
            i = 1;
            rb.isKinematic = true;
            currentPlayer = GameObject.Find("John");
            rb.isKinematic = false;
            tr.isKinematic = true;
            //jr.isKinematic = false;
            cr.isKinematic = true;

            DisableChild(jg);
            AbleChild(tg);
            AbleChild(cg);
            //colJ.isTrigger = false;
            //colT.isTrigger = true;
            //colC.isTrigger = true;
        }
        else if (Input.GetKey("3"))
        {
            i = 2;
            rb.isKinematic = true;
            currentPlayer = GameObject.Find("Claire");
            rb.isKinematic = false;
            tr.isKinematic = true;
            jr.isKinematic = true;
            //cr.isKinematic = false;

            DisableChild(cg);
            AbleChild(jg);
            AbleChild(tg);
            //colC.isTrigger = false;
            //colJ.isTrigger = true;
            //colT.isTrigger = true;
        }
        if (IsGround)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity = Vector2.up * jump[i];
                IsGround = false;
            }
        }

        if (Input.GetKey("r"))
        {
            // currentLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentLevel);
        }

        if (ThomasExit.IsFallIn() && JohnExit.IsFallIn() && ClaireExit.IsFallIn())
        {
            //nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            //currentLevel += 1;
            Debug.Log("nextlevel" + currentLevel + 1);
            SceneManager.LoadScene(currentLevel + 1);
            Debug.Log("Success");
        }
    }
    public void DisableChild(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i).GetComponent<BoxCollider2D>();
            if (child != null)
                child.isTrigger = false;
        }
    }
    public void AbleChild(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i).GetComponent<BoxCollider2D>();
            if (child != null)
                child.isTrigger = true;
        }
    }
}