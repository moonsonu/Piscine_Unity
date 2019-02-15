using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject upgradeMenuUI;
    public gameManager gm;
    public GameObject currentTower;
    public Text upgradeText;
    public Text downgradeText;
    public GameObject upgradeTower;
    public GameObject downgradeTower;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.transform.tag == "tower")
            {
                currentTower = hit.transform.gameObject;
                upgradeMenuUI.transform.position = hit.collider.transform.position;
                upgradeMenuUI.SetActive(true);
                upgradeTower = currentTower.GetComponent<towerScript>().upgrade;
                downgradeTower = currentTower.GetComponent<towerScript>().downgrade;
                upgradeText.text = "" + upgradeTower.GetComponent<towerScript>().energy;
                downgradeText.text = "" + (currentTower.GetComponent<towerScript>().energy / 2);
            }
        }
    }

    public void OnUpgradeClicked()
    {
        if (gameManager.gm.playerEnergy - (currentTower.GetComponent<towerScript>().energy) > 0)
        {
            Instantiate(currentTower.GetComponent<towerScript>().upgrade, currentTower.transform.position, Quaternion.identity);
            Destroy(currentTower);
            currentTower = currentTower.GetComponent<towerScript>().upgrade;
            gameManager.gm.playerEnergy -= currentTower.GetComponent<towerScript>().energy;
            upgradeMenuUI.SetActive(false);
        }
    }

    public void OnDownGradeClicked()
    {
        if (currentTower.GetComponent<towerScript>().downgrade != null)
        {
            Instantiate(currentTower.GetComponent<towerScript>().downgrade, currentTower.transform.position, Quaternion.identity);
            Destroy(currentTower);
            currentTower = currentTower.GetComponent<towerScript>().downgrade;
            gameManager.gm.playerEnergy += (currentTower.GetComponent<towerScript>().energy / 2);
            upgradeMenuUI.SetActive(false);
        }
        else
            //오또케오또케에에에에?
            currentTower = null;
    }

    public void OnExitClicked()
    {
        upgradeMenuUI.SetActive(false);
    }
}
