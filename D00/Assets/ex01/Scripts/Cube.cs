    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Cube : MonoBehaviour
    {

        float randSpeed;
        float minSpeed = 1;
        float maxSpeed = 3;

        void Update()
        {

            randSpeed = Random.Range(minSpeed, maxSpeed);
            transform.Translate(Vector3.down * randSpeed * Time.deltaTime);
        if (Input.GetKeyDown("a"))
        {
            if (gameObject.tag == "a")
            {
                if (transform.position.y >= -4 && transform.position.y <= 4)
                {
                    Destroy(transform.gameObject);
                    if (transform.position.y > 0)
                        Debug.Log("Precisions: " + (transform.position.y - 3));
                    else
                        Debug.Log("Precisions: " + (transform.position.y + 8));
                }
            }
        }
        else if (Input.GetKeyDown("s"))
        {
            if (gameObject.tag == "s")
            {
                if (transform.position.y >= -4 && transform.position.y <= 4)
                {
                    Destroy(transform.gameObject);
                    Debug.Log("Precisions: " + (transform.position.y + 4));
                }
            }
        }
        else if (Input.GetKeyDown("d"))
        {
            if (gameObject.tag == "d")
            {
                if (transform.position.y >= -4 && transform.position.y <= 4)
                {
                    Destroy(transform.gameObject);
                    Debug.Log("Precisions: " + (transform.position.y + 4));
                }
            }
        }
        }
    }
