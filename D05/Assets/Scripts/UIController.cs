using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text shotText;
    public Image powerBar;
    public Text clubName;
    public Text holeText;
    public Text parText;
    [SerializeField] private GameController gm;
    private float bar;

    public void SetShot(int shot)
    {
        shotText.text = shot.ToString();
    }

    public void PowerBar(float power)
    {
        powerBar.fillAmount = power;
    }
    public void SetClubName(string name)
    {
        clubName.text = name;
    }

    public void setLevelInfo(int holeNum, int parNum)
    {
        holeText.text = "HOLE " + holeNum.ToString();
        parText.text = "(PAR " + parNum.ToString() + ")";
    }
}