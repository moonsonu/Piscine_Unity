using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraController cam;
    [SerializeField] private GolfBall ball;
    //[SerializeField] private GameObject Clubs;
    [SerializeField] private GameObject currentClub;
    [SerializeField] private GameObject tab;
    [SerializeField] private GameObject flag;
    [SerializeField] private Text HoleText;
    [SerializeField] private UIController ui;
    [SerializeField] private GameObject[] Hole;
    [SerializeField] private Text clubName;
    [SerializeField] private Text ParText;


    private bool isView;
    public bool IsView { get { return isView; } }
    private float power;
    public float Power { get { return power; } }
    private int shot;
    public float Shot { get { return shot; } }
    public int indexClub = 0;
    private int maxClub = 3;
    public int level = 1;
    public int parnumber = 3;
    public int club = 0;

    private Vector3 offset;
    public Vector3 Offset { get { return offset; } }

    void Start()
    {
        isView = false;
        offset = cam.transform.position - ball.transform.position;
        clubName.text = "wood";
        ball.forward = 3f;
        ball.up = 0.5f;
        //orgBallPos = ball.transform.rotation;
    }

    public void View()
    {
        cam.Move();
        ball.NotRotate();
        if (Input.GetKeyDown("space"))
        {
            isView = false;
        }
    }

    public void NotView()
    {
        //cam.gameObject.transform.LookAt(flag.transform);
        ball.Rotate();
        if (Input.GetKeyDown("e"))
            isView = true;
        if (Input.GetKey("space"))
        {
            if (power < 1)
                power += 0.05f;
            else
                power = 0f;
        }
        if (Input.GetKeyUp("space"))
        {
            cam.gameObject.transform.SetParent(null);
            ball.shoot(power, ball.forward, ball.up);
            shot += 1;
            power = 0;
        }
    }

    void Update()
    {
        HoleText.text = "HOLE " + level;
        ParText.text = "(PAR " + parnumber + ")";

        if (isView)
        {
            View();
        }

        if (!isView)
        {
            NotView();
        }

        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            //GameObject c;
            if (indexClub < maxClub)
            {
                //c = currentClub.transform.GetChild(indexClub).gameObject;
                //c.SetActive(true);
                indexClub++;
            }
            else
                indexClub = 0;
            switch(indexClub)
            {
                case 0:
                    clubName.text = "wood";
                    ball.forward = 0.3f;
                    ball.up = 0.3f;
                    break;
                case 1:
                    clubName.text = "wedge";
                    ball.forward = 0.3f;
                    ball.up = 0.3f;

                    break;
                case 2:
                    clubName.text = "iron";
                    ball.forward = 0.3f;
                    ball.up = 0.3f;

                    break;
                case 3:
                    clubName.text = "putter";
                    ball.forward = 0.3f;
                    ball.up = 0.3f;
                    break;
            }
        }


        if (Input.GetKey(KeyCode.Tab))
            tab.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            tab.SetActive(false);
    }
}
