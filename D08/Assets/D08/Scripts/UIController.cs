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

    private void Update()
    {
        playerHPbar.fillAmount = playerController.myStats.getHp / playerController.maxHp;
        playerXPbar.fillAmount = playerController.myStats.getXp / 400;
        playerHPtext.text = playerController.myStats.getHp.ToString() + "/" + playerController.maxHp;
        playerXPtext.text = playerController.myStats.getXp.ToString() + "/400";
        playerSTRtext.text = playerController.myStats.getSTR.ToString();
        playerAGItext.text = playerController.myStats.getAGI.ToString();
        playerCONtext.text = playerController.myStats.getCON.ToString();
        playerARMtext.text = playerController.myStats.getArmor.ToString();
    }
    //public void SetHPbar()
    //{
    //    playerHPbar.fillAmount = playerController.myStats.getHp / playerController.maxHp;
    //}

    //public void SetXPbar()
    //{
    //    playerXPbar.fillAmount = playerController.myStats.getXp / 400;
    //}

    //public void SetInfoText()
    //{
    //    playerHPtext.text = playerController.myStats.getHp.ToString() + "/" + playerController.maxHp;
    //    playerXPtext.text = playerController.myStats.getXp.ToString() + "/400";
    //    playerSTRtext.text = playerController.myStats.getSTR.ToString();
    //    playerAGItext.text = playerController.myStats.getAGI.ToString();
    //    playerCONtext.text = playerController.myStats.getCON.ToString();
    //    playerARMtext.text = playerController.myStats.getArmor.ToString();
    //}

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
