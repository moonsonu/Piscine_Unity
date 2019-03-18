using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isKey = false;
    public bool IsKey { get { return isKey; } }

    private bool isFan = false;
    public bool IsFan { get { return isFan; } }
    private bool isLight = false;
    private bool isDoorOpened = false;
    private bool isWin = false;

    [SerializeField] private ParticleSystem fog;
    [SerializeField] private SlideDoor door;
    [SerializeField] private Cctv cctv;
    [SerializeField] private SceneFader fader;

    //audio
    public AudioClip aKey;
    public AudioClip aDoor;
    public AudioClip aDeny;
    public AudioClip aWin;
    public AudioClip aFan;

    void Start()
    {
        fader.FadeOut();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "CardReader")
        {
            Debug.Log("cardreader");
            if (isKey)
            {
                if (!isDoorOpened)
                    fader.insertText("USE E TO UNLOCK THE DOOR");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SoundManager.instance.PlaySingle(aDoor);
                    isKey = false;
                    isDoorOpened = true;
                    door.OpenDoor();
                    fader.FadeOut();
                }
            }

            if (!isKey && !isDoorOpened)
            {
                SoundManager.instance.PlaySingle(aDeny);
                fader.insertText("YOU NEED TO FIND DOOR KEY FIRST");
            }
        }

        if (collision.gameObject.tag == "KeyCard")
        {
            fader.insertText("USE E TO PICK UP THE KEY");
            if (Input.GetKeyDown(KeyCode.E) && !isKey)
            {
                SoundManager.instance.PlaySingle(aKey);
                Destroy(collision.gameObject);
                isKey = true;
                fader.FadeOut();
            }
        }

        if (collision.gameObject.tag == "Fan")
        {
            Debug.Log("Fan");
            if (!isFan)
                fader.insertText("USE E TO ACTIVATE THE FAN");
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundManager.instance.PlaySingle(aFan);
                isFan = true;
                fog.Play();
                fader.FadeOut();
            }
        }

        if (collision.gameObject.tag == "Paper")
        {
            Debug.Log("Paper");
            fader.insertText("USE E TO PICK UP THE FILES");
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundManager.instance.PlaySingle(aKey);
                fader.FadeOut();
                isWin = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "CardReader" ||
            collision.gameObject.tag == "Paper" ||
            collision.gameObject.tag == "Fan" ||
            collision.gameObject.tag == "KeyCard")
            fader.FadeOut();
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Map");
    }
    private void Update()
    {
        if (isWin)
        {
            SoundManager.instance.PlaySingle(aWin);
            fader.insertText("YOU WIN. RESTARTING SIMULATION...");
            StartCoroutine(reload());
        }
            
    }
}
