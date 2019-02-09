using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public string activeTag;
    bool fallIn;

    public bool IsFallIn()
    {
        return fallIn;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == activeTag)
            fallIn = true;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == activeTag)
            fallIn = false;
    }
}
