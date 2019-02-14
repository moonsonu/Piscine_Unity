using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler
{
    public GameObject tower;
    public gameManager gm;
    public towerScript t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("begindrag");
        GameObject dragged = Instantiate(tower, transform.position, Quaternion.identity);
        dragged.transform.position = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ondrag");

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("enddrag");

        transform.position = (Vector3)eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ondrop");
        RectTransform item = tower.transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(item, Input.mousePosition))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.transform.tag == "empty")
            {
                gm.playerEnergy -= t.energy;
                Instantiate(t, hit.collider.gameObject.transform.position, Quaternion.identity);
            }
            Debug.Log("Drop Item");
        }
    }
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    tower.transform.position = transform.position;
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    tower.transform.position += (Vector3)eventData.delta;
    //}
    //public void OnDrop(PointerEventData data)
    //{
    //    GameObject fromItem = data.pointerDrag;
    //    if (data.pointerDrag == null) return;

    //}
}
