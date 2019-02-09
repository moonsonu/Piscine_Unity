using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    public static float force;
    public static bool IsPressed;
    public static Vector3 orgPosition;
    public Ball ball;

    void Start()
    {
        force = 0;
    }

    void Update()
    {
        if (!IsPressed && force == 0.0f)
            orgPosition = transform.position;
        if (Input.GetKey("space"))
        {
            force += 0.5f;
            transform.Translate(0, -0.1f, 0);
            IsPressed = true;
        }
        else
            IsPressed = false;
    }
}
