using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour
{
    public GameObject currentPlayer;
    public Exit ThomasExit;
    public Exit JohnExit;
    public Exit ClaireExit;

    private Rigidbody2D rb;
    private float moveInput;
    private float[] speed = new float[3];
    private float[] jump = new float[3];
    private int i;
    private int currentLevel = 1;

    private bool IsGround;

    void Start()
    {
        currentPlayer = GameObject.Find("Thomas");
        speed[0] = 4f;
        speed[1] = 5f;
        speed[2] = 3f;
        jump[0] = 6.5f;
        jump[1] = 10f;
        jump[2] = 3f;
        i = 0;
        IsGround = true;

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
            currentPlayer = GameObject.Find("Thomas");
        }

        else if (Input.GetKey("2"))
        {
            i = 1;
            currentPlayer = GameObject.Find("John");
        }
        else if (Input.GetKey("3"))
        {
            i = 2;
            currentPlayer = GameObject.Find("Claire");
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
