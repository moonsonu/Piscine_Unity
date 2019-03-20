using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text shot;
    public Image powerBar;
    [SerializeField] private GameController gm;
    private float bar;

    public Text p1Score;
    public Text p2Score;
    public Text p3Score;

    public Text hole;
    public Text par;

    void Start()
    {
        bar = gm.Power;
        shot.text = "SHOT " + gm.Shot.ToString(); 
    }

    void Update()
    {
        bar = gm.Power;
        powerBar.fillAmount = bar;
        shot.text = "SHOT " + gm.Shot.ToString();
    }

    public void SettabPanel()
    {
        if (gm.level == 1)
        {
            p1Score.text = gm.Shot.ToString();
        }
        if (gm.level == 2)
        {
            p2Score.text = gm.Shot.ToString();
        }
        if (gm.level == 3)
        {
            p3Score.text = gm.Shot.ToString();
        }
    }
}
