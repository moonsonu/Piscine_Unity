using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionBoxController : MonoBehaviour
{
    //int yindex = 0;
    int xindex = 0;
    public int ytotalLevel = 3;
    public int xtotalLevel = 4;
    //public float yOffset = 1.8f;
    public float xOffset = 3f;
    public Text stagename;
    public Text bestscore;
    public LevelManager levelManager;
    private int currentlevel;
    private bool IsInteractable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (yindex < ytotalLevel - 1)
        //    {
        //        yindex++;
        //        Vector2 position = transform.position;
        //        position.y -= yOffset;
        //        transform.position = position;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (yindex > 0)
        //    {
        //        yindex--;
        //        Vector2 position = transform.position;
        //        position.y += yOffset;
        //        transform.position = position;
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (xindex < xtotalLevel - 1)
            {
                xindex++;
                Vector2 position = transform.position;
                position.x += xOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (xindex > 0)
            {
                xindex--;
                Vector2 position = transform.position;
                position.x -= xOffset;
                transform.position = position;
            }
        }
        switch (xindex)
        {
            case 0:
                StageInfo(0);
                currentlevel = 2;
                break;
            case 1:
                StageInfo(1);
                currentlevel = 2;
                break;
            case 2:
                StageInfo(2);
                currentlevel = 2;
                break;
            case 3:
                StageInfo(3);
                currentlevel = 2;
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (IsInteractable)
                SceneManager.LoadScene(currentlevel);
        }
    }
    void StageInfo(int stage)
    {
        //locked.transform.position = levelManager.Levellist[stage].stage.transform.position;
        if (levelManager.Levellist[stage].Unlocked == 1)
        {
            //Image lockscreen = locked.GetComponentInChildren<Image>();
            //Debug.Log(lockscreen);
            //lockscreen.enabled = true;
            //levelManager.Levellist[stage].lockimg.enabled = false;
            IsInteractable = true;
        }
        else
        {
            //levelManager.Levellist[stage].lockimg.enabled = true;
            IsInteractable = false;
        }
        stagename.text = levelManager.Levellist[stage].LevelText;
        bestscore.text = "best score : " + levelManager.Levellist[stage].BestScore + " pts";
    }
}
