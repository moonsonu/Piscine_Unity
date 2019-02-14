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

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene("ex01");
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
        rankMenuUI.SetActive(true);
        gm.pause(true);
        titleText.text = "VICTORY!";
        scoreText.text = "" + gm.score;
        gradeText.text = "";

    }
    //public void OnNextLevelButtonClicked()
    //{
    //    SceneManager.LoadScene("ex02");
    //}
}
