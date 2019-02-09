using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float time;
    public float scale = 0.4f;
    public float shrink;
    public float maxScale = 5;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (transform.localScale.x >= 0 && transform.localScale.x < maxScale)
        {
            if (Input.GetKeyDown("space"))
                transform.localScale += Vector3.one * scale;
            transform.localScale -= Vector3.one * shrink * Time.deltaTime;
        }

        if (transform.localScale.x < 0)
        {
            Destroy(gameObject);
            Debug.Log("FAIL");
        }

        if (transform.localScale.x >= maxScale)
        {
            Destroy(gameObject);
            Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
        }
    }
}