using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 clamp;
    public Vector3 rebounce;
    public Club Club;
    public static Vector3 ballPosition;
    public GameObject hole;
    public int score = -15;

    void Start()
    {
        rebounce = Vector3.up;
    }

    void Update()
    {
        clamp = transform.position;
        clamp.y = Mathf.Clamp(transform.position.y, -6, 6);
        if (!Club.IsPressed && Club.force != 0)
        {
            Club.gameObject.transform.position = Club.orgPosition;
            transform.Translate(rebounce * Club.force * Time.deltaTime);
            if (Club.force > 0)
                Club.force -= 0.2f;
            if (Club.force <= 0)
            {
                Club.force = 0;
                ballPosition = new Vector3
                    (transform.position.x - 0.3f,
                    transform.position.y,
                    transform.position.z);
                Club.gameObject.transform.position = ballPosition;
                Club.orgPosition = ballPosition;
                score += 5;
                Debug.Log("Score : " + score);
            }
        }
        if (transform.position.y <= -6.454165 || transform.position.y >= 6.5)
            rebounce = new Vector3(rebounce.x, -rebounce.y, rebounce.z);
        if (transform.position.y >= 4.5f && transform.position.y <= 5.5f && Club.force <= 1)
        {
            Club.force = 0;
            if (score > 0)
                Debug.Log("Score : " + score + " WIN!");
            else
                Debug.Log("Score : " + score + " LOST!");
            Destroy(gameObject);
        }
    }
}
