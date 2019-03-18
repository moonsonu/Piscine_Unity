using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cctv : MonoBehaviour
{
    //private GameObject player;
    private bool isDetected = false;
    public bool IsDetected { get { return isDetected; } }

    private float discretion = 0;
    private float maxDiscretion = 20;
    private float pamount;

    [SerializeField] private Player player;
    [SerializeField] private SceneFader fader;
    [SerializeField] private AlarmLight alarm;
    [SerializeField] private GameObject progressbar;
    public AudioClip aDead;
    public AudioClip aAlarm;

    private void Awake()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("cctv detected");
            isDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isDetected = false;
    }

    private void Update()
    {
        
        if (isDetected && !player.IsFan)
        {
            SoundManager.instance.PlaySingle(aAlarm);
            alarm.isAlarm = true;
            if (discretion < maxDiscretion)
                discretion += 0.1f;
            else
            {
                SoundManager.instance.PlaySingle(aDead);
                fader.insertText("GAME OVER. RESTARTING...");
                fader.FadeIn();
                isDetected = false;
                StartCoroutine(restart());
            }
        }

        if (!isDetected)
        {
                if (0 < discretion)
                    discretion -= 0.1f;
        }
        progressbar.GetComponent<Image>().fillAmount = discretion / 20;
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(3f);
        fader.FadeOut();
        SceneManager.LoadScene("Map");
    }
}
