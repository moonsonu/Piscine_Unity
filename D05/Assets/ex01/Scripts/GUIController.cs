using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public Rect position = new Rect(200, 15, 150, 25);
    public string text = "Hello World";
    public GUISkin skin = null;

    private void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(position, text);
    }
}
