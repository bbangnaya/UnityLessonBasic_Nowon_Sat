using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Ű���� ȭ��ǥ ����, ������ ����Ű�� X�� ������
    // Ű���� ȭ��ǥ ����, �Ʒ��� ����Ű�� z�� ������

    public Transform tr;
    Vector3 move;           // Ű���� �Է��� ���� ����
    public float speed = 1f;            // public �̶� inspector���� �����ؾ� �Ѵ�. 

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");      // h�� �� Horizontal�� ����
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v).normalized;
    }

    private void FixedUpdate()
    {
        transform.Translate(move * speed * Time.fixedDeltaTime);
        
    }

}
