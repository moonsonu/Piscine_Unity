    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Cube : MonoBehaviour
    {

        float randSpeed;
        float minSpeed = 1;
        float maxSpeed = 5;

        private void Start()
        {
            randSpeed = Random.Range(minSpeed, maxSpeed);

        }

        void Update()
        {
            transform.Translate(Vector3.down * randSpeed * Time.deltaTime);
            if (Input.GetKeyDown("a"))
            {
                if (gameObject.tag == "a" && transform.position.y >= -5 && transform.position.y <= -3.5)
                {
                    Destroy(transform.gameObject);
                    Debug.Log("A Precisions: " + (transform.position.y + 4));
                }
            }
            else if (Input.GetKeyDown("s"))
            {
                if (gameObject.tag == "s" && transform.position.y >= -5 && transform.position.y <= -3.5)
                {
                    Destroy(transform.gameObject);
                    Debug.Log("S Precisions: " + (transform.position.y + 4));
                }
            }
            else if (Input.GetKeyDown("d"))
            {
                if (gameObject.tag == "d" && transform.position.y >= -5 && transform.position.y <= -3.5)
                {
                    Destroy(transform.gameObject);
                    Debug.Log("D Precisions: " + (transform.position.y + 4));
                }
            }
            if (transform.position.y <= -6)
            {
                Destroy(transform.gameObject);
            }
        }
    }
