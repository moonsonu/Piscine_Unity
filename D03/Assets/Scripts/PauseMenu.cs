using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public gameManager gm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gm.pause(false);
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gm.pause(true);
        isPaused = true;

    }

    //public void LoadMenu()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("ex00");
    //}

    public void QuitGame()
    {
        SceneManager.LoadScene("ex00");
    }
}
