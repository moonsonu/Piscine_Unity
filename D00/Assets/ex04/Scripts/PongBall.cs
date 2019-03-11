using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public Vector3 ballDir;
    private float speed = 3;
    public Player player;
    private GameObject p1;
    private GameObject p2;
    private int p1score = 0;
    private int p2score = 0;

    void Start()
    {
        ResetBall();
        p1 = player.player1;
        p2 = player.player2;
    }

    void Update()
    {
        transform.Translate(ballDir * speed * Time.deltaTime);
        if (transform.position.y < -4.18)
            ballDir = new Vector3(ballDir.x, -ballDir.y, ballDir.z);
        if (transform.position.y > 4.18)
            ballDir = new Vector3(ballDir.x, -ballDir.y, ballDir.z);
        else if (transform.position.x >= 6.5)
        {
            p1score += 1;
            Debug.Log("Player 1: " + p1score + " | Player 2: " + p2score);
            ResetBall();
        }
        else if (transform.position.x <= -6.5)
        {
            p2score += 1;
            Debug.Log("Player 1: " + p1score + " | Player 2: " + p2score);
            ResetBall();
        }

        if ((transform.position.x >= -5.5f && transform.position.x <= -5f) && (transform.position.y < p1.transform.position.y + 2f) && (transform.position.y > p1.transform.position.y - 2f))
            ballDir = new Vector3(-ballDir.x, ballDir.y, ballDir.z);
        if ((transform.position.x <= 5.5f && transform.position.x >= 5f) && (transform.position.y < p2.transform.position.y + 2f) && (transform.position.y > p2.transform.position.y - 2f))
            ballDir = new Vector3(-ballDir.x, ballDir.y, ballDir.z);

    }

    void    ResetBall()
    {
        int x = Random.Range(-4, 4);
        int y = Random.Range(-4, 4);
        if (x == 0)
            x = 1;
        if (y == 0)
            y = 1;
        ballDir = new Vector3(x, y, 0);
        transform.position = new Vector3(0, 0, 0);
    }
}
