using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Bird bird;
    public bool checkScore;
    void Start()
    {
        checkScore = false;
    }

    void Update()
    {
        if (!bird.isDead)
            transform.Translate(-0.1f, 0, 0);
        if (transform.position.x < -4)
        {
            transform.position = new Vector3(5, 0.5f, 0);
            if (checkScore)
            {
                bird.score += 5;
                Debug.Log(bird.score);
            }
            checkScore = false;
        }
        if (transform.position.x > 0)
            checkScore = true;
    }
}
