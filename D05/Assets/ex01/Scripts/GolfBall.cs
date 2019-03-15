using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    public bool isPowered = false;
    public KeyController keyController;
    private Rigidbody rb;
    public AudioClip shootSound;
    private AudioSource sound;
    public bool isMoving = false;
    public bool isGameover = false;
    public bool isNextlevel = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isPowered)
        {
            Debug.Log("space" + keyController.power);
            rb.velocity = Camera.main.transform.forward * keyController.power * 50;
        }

        else
        {
            sound.clip = shootSound;
            sound.Play();
        }

        if (isGameover)
        {
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
}
