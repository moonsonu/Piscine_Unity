using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex00 : MonoBehaviour
{
    public GameObject currentPlayer;
    public float speed = 3.0f;
    public float jump = 10f;

    private Rigidbody2D rb;
    private float moveInput;

    int currentLevel;

    void Start()
    {
        currentPlayer = GameObject.Find("Thomas");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        rb = currentPlayer.GetComponent<Rigidbody2D>();
        if (Input.GetKey("1"))
            currentPlayer = GameObject.Find("Thomas");
        else if (Input.GetKey("2"))
            currentPlayer = GameObject.Find("John");
        else if (Input.GetKey("3"))
            currentPlayer = GameObject.Find("Claire");

        moveInput = Input.GetAxis("Horizontal");
        if(Input.GetKey("right"))
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        currentPlayer.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey("left"))
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
            currentPlayer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (Input.GetKeyDown("space"))
        {
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKey("r"))
            SceneManager.LoadScene(currentLevel);
    }
}
