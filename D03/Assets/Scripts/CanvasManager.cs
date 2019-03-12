﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public gameManager gm;
    public Text hpLabel;
    public Text energyLabel;

    void Start()
    {
        hpLabel.text = "20";
        energyLabel.text = "300";
    }

    void Update()
    {
        int hp = CalcHP();
        int energy = CalcEnergy();
        hpLabel.text = "" + hp;
        energyLabel.text = "" + energy;
    }

    int CalcHP()
    {
        return (int)gameManager.gm.playerHp;
    }

    int CalcEnergy()
    {
        print(gameManager.gm.playerEnergy);
        return (int)gameManager.gm.playerEnergy;
    }
}