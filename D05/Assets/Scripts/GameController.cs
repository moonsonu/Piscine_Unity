using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameState { Aim, Shoot, BallMoving, BallStop };
    public enum State { Win, Next, Gameover, start };
    public GameState gs;
    public State state;
    [SerializeField] private GolfBall ball;
    [SerializeField] private CameraController cc;
    [SerializeField] private UIController ui;
    public float power;
    public int shot;

    [SerializeField] private GameObject tab;
    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject nextLevel;
    public int indexClub = 0;
    private int maxClub = 3;
    public int level = 1;
    public int parnumber = 3;
    public int club = 0;
    public float forward;
    public float up;
    public int holeNum = 1;
    public int parNum = 3;

    private void Start()
    {
        gs = GameState.Aim;
        state = State.start;
        power = 0;
        shot = 0;
        ui.SetClubName("wood");
        forward = 0.3f;
        up = 0.8f;
    }

    private void Update()
    {
        Debug.Log(gs);
        switch (gs)
        {
            case GameState.Aim:
                SetClub();
                cc.cs = CameraController.CameraState.Aiming;
                if (Input.GetKeyDown("space"))
                    gs = GameState.Shoot;
                break;
            case GameState.Shoot:
                Shoot();
                break;
            case GameState.BallMoving:
                cc.cs = CameraController.CameraState.Following;
                break;
            case GameState.BallStop:
                cc.cs = CameraController.CameraState.Free;
                break;
        }

        switch (state)
        {
            case State.Gameover:
                gameover.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                    SceneManager.LoadScene(0);
                break;
            case State.Next:
                nextLevel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    level++;
                    parnumber++;
                    tab.SetActive(true);
                    nextLevel.SetActive(false);
                    Debug.Log("nextLevel");
                }
                break;
            case State.start:
                ui.setLevelInfo(holeNum, parNum);
                break;
            case State.Win:
                break;
        }
        if (gs == GameState.Aim)
        {
            if (Input.GetKeyDown("e"))
            {
                gs = GameState.BallStop;
                cc.cs = CameraController.CameraState.Free;
            }
        }
        if (gs == GameState.BallStop)
        {
            if (Input.GetKeyDown("space"))
            {
                gs = GameState.Aim;
                cc.cs = CameraController.CameraState.Aiming;
            }
        }
        ui.PowerBar(power);

        if (Input.GetKey(KeyCode.Tab))
            tab.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            tab.SetActive(false);
    }

    public void SetClub()
    {
        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            indexClub = 1;
            if (indexClub < maxClub)
                indexClub++;
            else
                indexClub = 0;
            switch (indexClub)
            {
                case 0:
                    ui.SetClubName("wood");
                    forward = 0.3f;
                    up = 0.3f;
                    break;
                case 1:
                    ui.SetClubName("wedge");
                    forward = 0.8f;
                    up = 0.5f;
                    break;
                case 2:
                    ui.SetClubName("iron");
                    forward = 1f;
                    up = 1.5f;
                    break;
                case 3:
                    ui.SetClubName("putter");
                    forward = 0.3f;
                    up = 0.3f;
                    break;
            }
        }
    }

    public void Shoot()
    {
        if (Input.GetKey("space"))
        {
            if (power < 1)
                power += 0.05f;
            else
                power = 0f;

        }
        if (Input.GetKeyUp("space"))
        {
            ball.bs = GolfBall.BallState.BallMoving;
            ball.Hit(power, forward, up);
            shot += 1;
            power = 0;
            ui.SetShot(shot);
        }
    }
}