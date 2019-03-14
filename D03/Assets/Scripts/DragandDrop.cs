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
    //public Image range;
    private int energy;
    private bool enoughEnergy;

    void Start()
    {
        //range.enabled = false;
        enoughEnergy = true;
    }

    void Update()
    {
        Debug.Log("draganddrop");
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
        //range.enabled = true;
        //range.transform.position = Input.mousePosition;
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (enoughEnergy)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit.collider.transform.name);
            if (hit && hit.collider.transform.tag == "empty")
            {

                gameManager.gm.playerEnergy -= towerscript.energy;
                Instantiate(t, hit.collider.gameObject.transform.position, Quaternion.identity);
            }
        }
        //range.enabled = false;
        transform.position = orgPosition;
        Debug.Log("Drop Item");
        tower = null;
    }
}
