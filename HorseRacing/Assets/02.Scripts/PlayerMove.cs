using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float distance;
    public Vector3 dir = Vector3.forward;
    public float minSpeed;          // ������ �����ӵ������� �Է��Ҽ� �ְ� �ٲ��ش�.
    public float maxSpeed;          // ������ �ְ�ӵ������� �Է��Ҽ� �ְ� �ٲ��ش�.
    public bool doMove;             // �޸��� ���� ��ư ���� ����

    Vector3 move;                   // ���������� ���� ����


    private void Awake()
    {
        tr = GetComponent<Transform>();     // gameobject�� Transform�� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    /*private void Update()
    {
        if (doMove)
            Move();
    }*/
    private void FixedUpdate()
    {
        if (doMove)
            Move();

    }

    // �޸��� �Լ�
    private void Move()
    {
        // ����Ƽ���� �����ϴ� �����Լ�
        float moveSpeed = Random.Range(minSpeed, maxSpeed);     // �ִ�, �ּ� �ӷ� ���� �������� moveSpeed ����
        move = dir * moveSpeed * Time.fixedDeltaTime;        // ������ �Ÿ�
        tr.Translate(move);                     // Translate : ��ġ ����
        distance += move.z;             // �Ÿ� ǥ��. move�� ���� �����ش�.
    }


    /*private void Move()
    {
        // ����Ƽ���� �����ϴ� �����Լ�
        float moveSpeed = Random.Range(minSpeed, maxSpeed);     // �ִ�, �ּ� �ӷ� ���� �������� moveSpeed ����
        move = dir * moveSpeed * Time.deltaTime;        // ������ �Ÿ�
        tr.Translate(move);                     // Translate : ��ġ ����
        distance += move.magnitude;             // �Ÿ� ǥ��. move�� ���� �����ش�.
    }*/



}
