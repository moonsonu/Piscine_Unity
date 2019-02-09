using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("w") && player1.transform.position.y < 3.15f)
            player1.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("s") && player1.transform.position.y > -3.15f)
            player1.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (Input.GetKey("up") && player2.transform.position.y < 3.15f)
            player2.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey("down") && player2.transform.position.y > -3.15f)
            player2.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
