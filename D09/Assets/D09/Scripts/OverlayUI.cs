using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUI : MonoBehaviour
{
    public Text overlayText;
    public Text timerText;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 25;
        overlayText.text = "";
        InvokeRepeating("timer", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            overlayText.text = "next wave";
        }
        if (time > 0)
            timerText.text = "Time: " + time + "s";
    }

    void timer()
    {
        time--;
    }
}
