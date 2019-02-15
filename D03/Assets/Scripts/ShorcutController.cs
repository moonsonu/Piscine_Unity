using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShorcutController : MonoBehaviour
{
    
    public GameObject canon;
    public Image canonImage;
    public GameObject gatling;
    public Image gatlingImage;
    public GameObject rocket;
    public Image rocketImage;
    private Image currentTowerImage;
    private GameObject currentTower;
    private Vector3 orgPosition;


    private Vector3 mousePosition;
    public gameManager gm;

    void Update()
    {
        if (!gameManager.gm.isOver)
        {
            if (Input.GetKeyDown("1"))
            {
                int energy = gameManager.gm.playerEnergy - canon.GetComponent<towerScript>().energy;
                if (energy > 0)
                {
                    currentTowerImage = canonImage;
                    currentTower = canon;
                    orgPosition = canonImage.transform.position;
                }

            }

            else if (Input.GetKeyDown("2"))
            {
                int energy = gameManager.gm.playerEnergy - gatling.GetComponent<towerScript>().energy;
                if (energy > 0)
                {
                    currentTowerImage = gatlingImage;
                    currentTower = gatling;
                    orgPosition = gatlingImage.transform.position;
                }
            }

            else if (Input.GetKeyDown("3"))
            {
                int energy = gameManager.gm.playerEnergy - rocket.GetComponent<towerScript>().energy;
                if (energy > 0)
                {
                    currentTowerImage = rocketImage;
                    currentTower = rocket;
                    orgPosition = rocketImage.transform.position;
                }
            }
            else if (Input.GetKeyDown("4"))
            {
                currentTowerImage.transform.position = orgPosition;
                currentTower = null;
                currentTowerImage = null;
            }

            if (currentTowerImage != null)
                currentTowerImage.transform.position = Input.mousePosition;


            if (currentTowerImage != null && Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit && hit.collider.transform.tag == "empty")
                {
                    int towerEnergy = currentTower.GetComponent<towerScript>().energy;
                    gameManager.gm.playerEnergy -= towerEnergy;
                    Instantiate(currentTower, hit.collider.gameObject.transform.position, Quaternion.identity);
                    currentTowerImage.transform.position = orgPosition;
                }
                currentTower = null;
                currentTowerImage = null;
            }
        }

    }
}
