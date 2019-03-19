using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text shot;
    public Image powerBar;
    public KeyController barUpdate;
    private float bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = barUpdate.Power;
        shot.text = "SHOT " + barUpdate.shot.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        bar = barUpdate.Power;
        powerBar.fillAmount = bar;
        shot.text = "SHOT " + barUpdate.shot.ToString();
    }
}
