using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public GameObject stage;
        public Image lockimg;
        public string LevelText;
        public int Unlocked;
        public int BestScore;
    }

    public List<Level> Levellist;


    void FillList()
    {
        foreach(var s in Levellist)
        {
            s.LevelText = s.stage.name;
            if (s.stage.name == "Angel Island")
            {
                s.Unlocked = 1;
                s.BestScore = PlayerPrefs.GetInt("angelbestscore");
            }
            else if (s.stage.name == "Oil Ocean")
            {
                s.Unlocked = PlayerPrefs.GetInt("oilunlocked", 0);
                s.BestScore = PlayerPrefs.GetInt("oilbestscore");
            }
            else if (s.stage.name == "Flying Battery")
            {
                s.Unlocked = PlayerPrefs.GetInt("flyingunlocked", 0);
                s.BestScore = PlayerPrefs.GetInt("flyingbestscore");
            }
            else if (s.stage.name == "Chemical Plant")
            {
                s.Unlocked = PlayerPrefs.GetInt("chemicalunlocked", 0);
                s.BestScore = PlayerPrefs.GetInt("chemicalbestscore");
            }
            if (s.Unlocked == 1)
                s.lockimg.enabled = false;
            else
                s.lockimg.enabled = true;
        }
    }

    void Start()
    {
        FillList();
    }
}
