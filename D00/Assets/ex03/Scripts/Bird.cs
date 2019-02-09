using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float time;
    public bool isDead;
    public int score = 0;
    public Pipe pipe;

    private void Start()
    {
        isDead = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.down * 3f * Time.deltaTime);
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(0, 2f, 0);
        }
        if (transform.position.y < -3.0f || transform.position.y > 4.5f)
        {
            isDead = true;
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
            Debug.Log("Score: " + score);
            Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
            Destroy(gameObject);
        }
        if (transform.position.y <= 3 && transform.position.y >= -3)
        {
            if (pipe.transform.position.y <= 0.5 && pipe.transform.position.y >= -0.5)
                pipe.checkScore = true;
        }
        else
        {
            isDead = true;
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
            Debug.Log("Score: " + score);
            Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
            Destroy(gameObject);
        }
    }
}