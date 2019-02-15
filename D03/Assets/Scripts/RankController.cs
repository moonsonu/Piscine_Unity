using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankController : MonoBehaviour
{
    public Text titleText;
    public Text scoreText;
    public Text gradeText;
    public GameObject RetryButton;
    public GameObject NextLevelButton;
    public GameObject rankMenuUI;
    public gameManager gm;
    public static RankController rc;

    void Start()
    {
        RetryButton.SetActive(false);
        NextLevelButton.SetActive(false);

    }
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("ex01");
    }

    public void Update()
    {
        if (gameManager.gm.lastWave)
            Victory();
        if (gameManager.gm.isOver)
            GameOver();
    }

    public void GameOver()
    {
        rankMenuUI.SetActive(true);

        gameManager.gm.pause(true);

        titleText.text = "GAME OVER!";
        scoreText.text = "" + gameManager.gm.score;
        gradeText.text = "F";
        RetryButton.SetActive(true);
    }

    public void Victory()
    {
        Time.timeScale = 0f;
        rankMenuUI.SetActive(true);

        gameManager.gm.pause(true);
        titleText.text = "VICTORY!";
        if (gameManager.gm.playerHp > 0 && gameManager.gm.playerHp < 5)
            gradeText.text = "E";
        else if (gameManager.gm.playerHp >= 5 && gameManager.gm.playerHp <= 8)
            gradeText.text = "D";
        else if (gameManager.gm.playerHp >= 9 && gameManager.gm.playerHp <= 12)
            gradeText.text = "C";
        else if (gameManager.gm.playerHp >= 13 && gameManager.gm.playerHp <= 17)
            gradeText.text = "B";
        else
            gradeText.text = "A";
        scoreText.text = "" + gameManager.gm.score;
        NextLevelButton.SetActive(true);

    }

    public void OnNextLevelButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("ex02");
    }
}