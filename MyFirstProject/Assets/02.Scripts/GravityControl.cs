using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    Rigidbody _rg;
    float _gravityNormal = 9.81f;
    public float _gravityScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        _rg.mass = 100;
    }

    // Update is called once per frame
    // 중력값을 움직인다.
    void Update()
    {
        Vector3 vInput = Input.acceleration;     // 핸드폰의 자이로스코프의 값을 받아오는 것
        float gx = Input.GetAxis("Horizontal"); // -1~1
        float gy = Input.GetAxis("Vertical");
        Vector3 g = new Vector3(gx, -1, gy);
        g.Normalize();

        Physics.gravity = g * _gravityNormal * _gravityScale;
        /*Debug.Log(Physics.gravity);*/
    
    
    
    
    
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject + "와 충돌했다.");
    }

}
