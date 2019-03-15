using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float power;
    public int shot;
    public GolfBall golfBall;

    void Start()
    {
        shot = 0;
        power = 0;
    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (power < 1)
                power += 0.05f;
            else
                power = 0f;
            golfBall.isPowered = false;
        }
        if (Input.GetKeyUp("space"))
        {
            golfBall.isPowered = true;
            shot += 1;
        }
    }
}
