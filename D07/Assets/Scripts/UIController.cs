using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public GameObject tank;
    public Text lifeText;
    public Text MissileText;

    public void GetLife(int life)
    {
        lifeText.text = life.ToString();
    }

    public void GetMissile(int ammo)
    {
        MissileText.text = ammo.ToString();
    }
}
