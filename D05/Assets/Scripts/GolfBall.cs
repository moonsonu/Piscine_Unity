using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GolfBall : MonoBehaviour
{
    public enum BallState { BallMoving, BallStop, Free};
    public BallState bs;
    [SerializeField] private GameController gm;
    public CameraController cc;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        bs = BallState.Free;
    }
    private void Update()
    {
        switch (bs)
        {
            case BallState.BallMoving:
                BallMoving();
                break;
            case BallState.BallStop:
                gm.gs = GameController.GameState.Aim;
                bs = BallState.Free;
                break;
            case BallState.Free:
                break;
        }
    }

    void BallMoving()
    {
        float threshold = 20f;
        float gbVel = rb.velocity.sqrMagnitude;
        bool stop;

        Debug.Log(gbVel);
        if (gbVel < threshold)
            stop = true;
        else
            stop = false;

        if (stop)
        {
            rb.drag = 10;
            rb.angularDrag = 10;
            bs = BallState.BallStop;
        }
        else if (!stop)
        {
            rb.drag = 0;
            rb.angularDrag = 0.05f;
        }
    }

    public void Hit(float power, float forward, float up)
    {
        rb.velocity = (transform.forward * forward + transform.up * up) * power * 50;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gm.level.ToString())
            gm.state = GameController.State.Next;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
            gm.state = GameController.State.Gameover;
    }
}