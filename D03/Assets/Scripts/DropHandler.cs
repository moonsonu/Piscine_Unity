using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform item = transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(item, Input.mousePosition))
        {
            Debug.Log("Drop Item");
        }
    }
}
