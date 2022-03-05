using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Cube cube;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Sphere called {cube.a}");



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
