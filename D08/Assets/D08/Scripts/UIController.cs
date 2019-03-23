using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Image playerHPbar;
    public Image playerXPbar;
    public Text playerHPtext;
    public Text playerXPtext;
    public Text playerSTRtext;
    public Text playerAGItext;
    public Text playerCONtext;
    public Text playerARMtext;

    public GameObject infoPanel;

    public PlayerController playerController;

    private void Start()
    {
        SetHPbar();
        SetXPbar();
        SetInfoText();
    }

    private void Update()
    {
        playerHPbar.fillAmount = playerController.playerStat.getHp / playerController.maxHP;
        playerXPbar.fillAmount = playerController.playerStat.getXp / playerController.maxXP;
        playerHPtext.text = playerController.playerStat.getHp.ToString() + "/" + playerController.maxHP;
        playerXPtext.text = playerController.playerStat.getXp.ToString() + "/400";
        playerSTRtext.text = playerController.playerStat.getSTR.ToString();
        playerAGItext.text = playerController.playerStat.getAGI.ToString();
        playerCONtext.text = playerController.playerStat.getCON.ToString();
        playerARMtext.text = playerController.playerStat.getArmor.ToString();
    }
    public void SetHPbar()
    {
        playerHPbar.fillAmount = playerController.playerStat.getHp / playerController.maxHP;
    }

    public void SetXPbar()
    {
        playerXPbar.fillAmount = playerController.playerStat.getXp / playerController.maxXP;
    }

    public void SetInfoText()
    {
        playerHPtext.text = playerController.playerStat.getHp.ToString() + "/" + playerController.maxHP;
        playerXPtext.text = playerController.playerStat.getXp.ToString() + "/400";
        playerSTRtext.text = playerController.playerStat.getSTR.ToString();
        playerAGItext.text = playerController.playerStat.getAGI.ToString();
        playerCONtext.text = playerController.playerStat.getCON.ToString();
        playerARMtext.text = playerController.playerStat.getArmor.ToString();
    }

    public void ActiveInfo()
    {
        infoPanel.SetActive(true);
    }

    public void DeactiveInfo()
    {
        infoPanel.SetActive(false);
    }

    //public Image enemyHPbar;
    //public Text enemyHPtext;
}
