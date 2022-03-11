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
    // �߷°��� �����δ�.
    void Update()
    {
        Vector3 vInput = Input.acceleration;     // �ڵ����� ���̷ν������� ���� �޾ƿ��� ��
        float gx = Input.GetAxis("Horizontal"); // -1~1
        float gy = Input.GetAxis("Vertical");
        Vector3 g = new Vector3(gx, -1, gy);
        g.Normalize();

        Physics.gravity = g * _gravityNormal * _gravityScale;
        /*Debug.Log(Physics.gravity);*/
    
    
    
    
    
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject + "�� �浹�ߴ�.");
    }

}
