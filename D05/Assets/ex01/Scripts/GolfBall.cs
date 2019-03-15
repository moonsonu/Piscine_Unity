using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public bool isPowered = false;
    public KeyController keyController;
    private Rigidbody rb;
    public AudioClip shootSound;
    public AudioClip GameoverSound;
    private AudioSource sound;
    public bool isMoving = false;
    public bool isGameover = false;
    public bool isNextlevel = false;
    public float time;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (isPowered)
        {
            Debug.Log("space" + keyController.power);
            //rb.velocity = Camera.main.transform.forward * keyController.power * 50;
            Vector3 movement = Camera.main.transform.forward;
            rb.AddForce(movement * keyController.power * 100);
            isMoving = true;
        }
        if (isMoving)
        {
            if (time > 5)
            {
                if (rb.drag < 30)
                    rb.drag += 0.1f;
                else
                {
                    isMoving = false;
                    rb.AddForce(0, 0, 0);
                    keyController.power = 0;
                    isPowered = false;
                }
            }
            //else
            //{
            //    isMoving = false;
            //    rb.AddForce(0, 0, 0);
            //}
                
        }

        else
        {
            sound.clip = shootSound;
            sound.Play();
        }

        if (isGameover)
        {
            sound.clip = GameoverSound;
            sound.Play();
            GameObject gameover = GameObject.Find("GameOverUI");
            Debug.Log(gameover.GetComponentInChildren<Canvas>());
            gameover.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
            Debug.Log("Success!!!");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.SetActive(false);
            Debug.Log("water");
            isGameover = true;
        }
        //if (collision.gameObject.CompareTag("Ground"))
            //rb.velocity = new Vector3(0, 0, 0);
    }
}
