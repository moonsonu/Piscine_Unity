using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 6f;
    //public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //movement = Vector3.ClampMagnitude(movement, speed); //limits the max speed of the player
        ////movement.y = gravity;
        //movement *= Time.deltaTime;
        ////movement = transform.TransformDirection(movement);
        //transform.position += movement;
        transform.position += movement * Time.deltaTime * speed;
    }
}
