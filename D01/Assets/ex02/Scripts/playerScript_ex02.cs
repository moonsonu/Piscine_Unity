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
    public GameObject tg;
    public GameObject jg;
    public GameObject cg;

    private Rigidbody2D rb;
    private BoxCollider2D colT;
    private BoxCollider2D colJ;
    private BoxCollider2D colC;
    private float moveInput;
    private float[] speed = new float[3];
    private float[] jump = new float[3];
    private int i;
    private int currentLevel = 2;

    private bool IsGround;


    void Start()
    {
        currentPlayer = GameObject.Find("Thomas");
        colT = tg.GetComponent<BoxCollider2D>();
        colJ = jg.GetComponent<BoxCollider2D>();
        colC = cg.GetComponent<BoxCollider2D>();
        speed[0] = 5f;
        speed[1] = 6f;
        speed[2] = 4f;
        jump[0] = 7.5f;
        jump[1] = 10f;
        jump[2] = 5f;
        i = 0;
        IsGround = true;
        colT.isTrigger = false;
        colJ.isTrigger = true;
        colC.isTrigger = true;

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
    }

    void Update()
    {
        rb = currentPlayer.GetComponent<Rigidbody2D>();

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed[i], rb.velocity.y);
        if (Input.GetKey("1"))
        {
            i = 0;
            currentPlayer = GameObject.Find("Thomas");
            colT.isTrigger = false;
            colJ.isTrigger = true;
            colC.isTrigger = true;
        }
        else if (Input.GetKey("2"))
        {
            i = 1;
            currentPlayer = GameObject.Find("John");
            colJ.isTrigger = false;
            colT.isTrigger = true;
            colC.isTrigger = true;
        }
        else if (Input.GetKey("3"))
        {
            i = 2;
            currentPlayer = GameObject.Find("Claire");
            colC.isTrigger = false;
            colJ.isTrigger = true;
            colT.isTrigger = true;
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
            SceneManager.LoadScene("ex02");

        if (ThomasExit.IsFallIn() && JohnExit.IsFallIn() && ClaireExit.IsFallIn())
        {
            SceneManager.LoadScene("ex01");
            Debug.Log("Success");
        }
    }
}