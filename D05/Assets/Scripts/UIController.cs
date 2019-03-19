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
}
