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
    public GameObject rankMenuUI;
    public gameManager gm;
    public static RankController rc;

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("ex01");
    }

    public void Update()
    {
        if (gm.lastWave)
            Victory();
    }

    public void GameOver()
    {
        rankMenuUI.SetActive(true);

        gm.pause(true);

        titleText.text = "GAME OVER!";
        scoreText.text = "" + gm.score;
        gradeText.text = "F";
    }

    public void Victory()
    {
        Time.timeScale = 0f;
        rankMenuUI.SetActive(true);

        gm.pause(true);
        titleText.text = "VICTORY!";
        if (gm.playerHp > 0 && gm.playerHp < 5)
            gradeText.text = "E";
        else if (gm.playerHp >= 5 && gm.playerHp <= 8)
            gradeText.text = "D";
        else if (gm.playerHp >= 9 && gm.playerHp <= 12)
            gradeText.text = "C";
        else if (gm.playerHp >= 13 && gm.playerHp <= 17)
            gradeText.text = "B";
        else
            gradeText.text = "A";
        scoreText.text = "" + gm.score;

    }

    //public void OnNextLevelButtonClicked()
    //{
    //    SceneManager.LoadScene("ex02");
    //}
}
