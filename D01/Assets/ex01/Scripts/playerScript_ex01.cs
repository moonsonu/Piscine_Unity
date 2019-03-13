using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour
{
    public GameObject currentPlayer;

    public GameObject Thomas;
    public GameObject John;
    public GameObject Claire;

    public Exit ThomasExit;
    public Exit JohnExit;
    public Exit ClaireExit;

    private Rigidbody2D rb;
    private Rigidbody2D tr;
    private Rigidbody2D jr;
    private Rigidbody2D cr;
    private float moveInput;
    private float[] speed = new float[3];
    private float[] jump = new float[3];
    private int i;
    private int currentLevel = 1;

    private bool IsGround;

    void Start()
    {
        currentPlayer = GameObject.Find("Thomas");
        speed[0] = 5f;
        speed[1] = 6f;
        speed[2] = 4f;
        jump[0] = 8f;
        jump[1] = 10f;
        jump[2] = 6f;
        i = 0;
        IsGround = true;

        tr = Thomas.GetComponent<Rigidbody2D>();
        jr = John.GetComponent<Rigidbody2D>();
        cr = Claire.GetComponent<Rigidbody2D>();
        tr.isKinematic = false;
        jr.isKinematic = true;
        cr.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
                collision.gameObject.tag == "Thomas" ||
                    collision.gameObject.tag == "John" ||
                        collision.gameObject.tag == "Claire")
            IsGround = true;
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
            SceneManager.LoadScene("ex01");

        if (ThomasExit.IsFallIn() && JohnExit.IsFallIn() && ClaireExit.IsFallIn())
        {
            SceneManager.LoadScene("ex02");
            Debug.Log("Success");
        }
    }
}
