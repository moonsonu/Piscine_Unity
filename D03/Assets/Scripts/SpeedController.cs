using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public gameManager gm;
    private float speed;

    public void PauseButtonClicker()
    {
        speed = 0f;
        gm.changeSpeed(speed);
    }

    public void PlayButtonClicker()
    {
        speed = 1f;
        gm.changeSpeed(speed);
    }

    public void FastButtonClicker()
    {
        speed = 2f;
        gm.changeSpeed(speed);
    }

    public void FasterButtonClicker()
    {
        speed = 4f;
        gm.changeSpeed(speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
