using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour
{
    public GameObject currentPlayer;
    public float speed = 3.0f;
    public float jump = 10f;

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        currentPlayer = GameObject.Find("Thomas");

    }

    void Update()
    {
        rb = currentPlayer.GetComponent<Rigidbody2D>();
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (Input.GetKey("1"))
            currentPlayer = GameObject.Find("Thomas");
        else if (Input.GetKey("2"))
            currentPlayer = GameObject.Find("John");
        else if (Input.GetKey("3"))
            currentPlayer = GameObject.Find("Claire");

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKey("r"))
            Application.LoadLevel(0);
    }
}
