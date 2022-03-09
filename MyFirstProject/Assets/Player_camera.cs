using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera : MonoBehaviour
{
    public Transform target;
    private Transform tr;
    Vector3 move;

    private void Awake()
    {
        /*tr = transform;*/
    }


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        /*tr.position = new Vector3(0, 1.5f, -2);
        tr.rotation = Quaternion.Euler(25, 0, 0);*/
    }

    // Update is called once per frame
    void Update()
    {


    }
    void LateUpdate()
    {

    }
}
