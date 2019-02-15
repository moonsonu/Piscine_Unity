using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBoxController : MonoBehaviour
{
    int index = 0;
    public int totalLevel = 3;
    public float yOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index < totalLevel - 1)
            {
                index++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.y += yOffset;
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
