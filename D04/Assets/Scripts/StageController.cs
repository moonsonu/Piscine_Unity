using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Text lifelost;
    public Text totalring;

    private void Start()
    {
        lifelost.text = PlayerPrefs.GetInt("lifelost").ToString();
        totalring.text = PlayerPrefs.GetInt("totalring").ToString();
    }

}
