using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUI : MonoBehaviour
{
    public Texture _img;


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 25), "æ»≥Á«œººø‰");
        GUI.Box(new Rect(400, 0, 100, 130), _img);
        GUI.Button(new Rect(0, 200, 300, 25), "Click Me!");

    }
}
