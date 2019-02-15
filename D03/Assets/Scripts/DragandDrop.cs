using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler
{
    public GameObject tower;
    public gameManager gm;
    public GameObject t;
    public towerScript towerscript;
    private Vector3 orgPosition;
    private int energy;
    private bool enoughEnergy;

    void Start()
    {

        enoughEnergy = true;
    }

    void Update()
    {
        energy = gameManager.gm.playerEnergy - towerscript.energy;

        if (energy <= 0)
        {
            enoughEnergy = false;
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            enoughEnergy = true;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }
    public void OnBeginDrag(PointerEventData data)
    {
        orgPosition = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (enoughEnergy)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.transform.tag == "empty")
            {
                Debug.Log(energy);
                gameManager.gm.playerEnergy -= towerscript.energy;
                Instantiate(t, hit.collider.gameObject.transform.position, Quaternion.identity);
            }
        }

        transform.position = orgPosition;
        Debug.Log("Drop Item");
        tower = null;
    }
}
