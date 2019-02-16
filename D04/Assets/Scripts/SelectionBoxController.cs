using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBoxController : MonoBehaviour
{
    int yindex = 0;
    int xindex = 0;
    public int ytotalLevel = 3;
    public int xtotalLevel = 4;
    public float yOffset = 1.8f;
    public float xOffset = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (yindex < ytotalLevel - 1)
            {
                yindex++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (yindex > 0)
            {
                yindex--;
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (xindex < xtotalLevel - 1)
            {
                xindex++;
                Vector2 position = transform.position;
                position.x += xOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (xindex > 0)
            {
                xindex--;
                Vector2 position = transform.position;
                position.x -= xOffset;
                transform.position = position;
            }
        }
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (index == 0)
        //    {
        //    }
        //}
    }
}
