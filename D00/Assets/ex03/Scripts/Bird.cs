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
            transform.Translate(0, 1f, 0);
        }
        if (pipe.transform.position.x < -0.81f && pipe.transform.position.x > -3.71f)
        {
            if (transform.position.y < -1.55f || transform.position.y > 1.17f)
            {
                isDead = true;
                transform.position = new Vector3(transform.position.x, -3.5f, 0);
                Debug.Log("Score: " + score);
                Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
                Destroy(gameObject);
            }
            else
            {
                if (pipe.transform.position.y <= 0.5 && pipe.transform.position.y >= -0.5)
                    pipe.checkScore = true;
            }

        }
        if (transform.position.y >= 4.58 || transform.position.y <= -3.35f)
        {
            isDead = true;
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
            Debug.Log("Score: " + score);
            Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
            Destroy(gameObject);
        }
    }
}