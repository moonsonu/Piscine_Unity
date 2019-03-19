using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraController cam;
    [SerializeField] private GolfBall ball;
    [SerializeField] private GameObject Clubs;
    [SerializeField] private GameObject currentClub;
    [SerializeField] private GameObject tab;

    [SerializeField] private Text clubName;
    public Quaternion orgBallPos;

    private bool isView;
    private float power;
    public float Power { get { return power; } }
    private int shot;
    public float Shot { get { return shot; } }
    public int indexClub = 0;
    private int maxClub = 3;
    private int level = -1;
    private int maxLevel = 3;

    private Vector3 offset;
    [SerializeField] private GameObject viewPoint;

    void Start()
    {
        isView = false;
        offset = cam.transform.position - ball.transform.position;
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
            ball.shoot(power);
            shot += 1;
            power = 0;
        }
    }

    void Update()
    {
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
            if (indexClub < maxClub)
            {
                currentClub = Clubs.transform.GetChild(indexClub).gameObject;
                clubName.text = currentClub.name;
                indexClub++;
            }
            else
                indexClub = 0;
        }


        if (Input.GetKey(KeyCode.Tab))
            tab.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            tab.SetActive(false);
    }
}
