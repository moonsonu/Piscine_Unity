using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;

    private void Start()
    {
        hp = 100;
    }

    void initPlayer()
    {
        hp = 100;
    }

    void getDamaged()
    {
        if (hp > 0)
        {
            hp -= 10;
            if (hp <= 0)
            {
                //display game over ui
                //reload scene
            }
        }
    }

}
