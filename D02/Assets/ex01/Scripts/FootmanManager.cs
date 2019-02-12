using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmanManager : MonoBehaviour
{
    public List<Footman> availableFM;
    public GameObject selectedCharacter;
    public Footman footman;

    void Start()
    {
        availableFM = new List<Footman>();
        footman = GetComponent<Footman>();
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.CompareTag("Footman"))
            {
                if (availableFM.Count > 0 && Input.GetKey(KeyCode.LeftControl))
                {
                    availableFM.Add(hit.collider.gameObject.GetComponent<Footman>());
                }
                else if (availableFM.Count > 0)
                {
                    for (int i = 0; i < availableFM.Count; i++)
                    {
                        availableFM[i].isClicked = false;
                    }
                    availableFM.Clear();
                }
                availableFM.Add(hit.collider.gameObject.GetComponent<Footman>());
            }

            else if (hit.collider.CompareTag("Map"))
            {
                Vector3 mapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mapPosition.z = 0f;
                if (availableFM.Count > 0)
                {
                    for (int i = 0; i < availableFM.Count; i++)
                    {
                        availableFM[i].target = mapPosition;
                        availableFM[i].isClicked = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < availableFM.Count; i++)
            {
                availableFM[i].isClicked = false;
            }
            availableFM.Clear();
        }
    }
}
