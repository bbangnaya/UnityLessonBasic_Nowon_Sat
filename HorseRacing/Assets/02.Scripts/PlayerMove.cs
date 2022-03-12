using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float distance;
    public Vector3 dir = Vector3.forward;
    public float minSpeed;          // 말마다 최저속도스탯을 입력할수 있게 바꿔준다.
    public float maxSpeed;          // 말마다 최고속도스탯을 입력할수 있게 바꿔준다.
    public bool doMove;             // 달리기 시작 버튼 같은 느낌

    Vector3 move;                   // 물리연산을 위한 선언


    private void Awake()
    {
        tr = GetComponent<Transform>();     // gameobject의 Transform에 접근
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

    // 달리는 함수
    private void Move()
    {
        // 유니티에서 제공하는 랜덤함수
        float moveSpeed = Random.Range(minSpeed, maxSpeed);     // 최대, 최소 속력 사이 랜덤으로 moveSpeed 조절
        move = dir * moveSpeed * Time.fixedDeltaTime;        // 움직일 거리
        tr.Translate(move);                     // Translate : 위치 변경
        distance += move.z;             // 거리 표시. move의 값을 더해준다.
    }


    /*private void Move()
    {
        // 유니티에서 제공하는 랜덤함수
        float moveSpeed = Random.Range(minSpeed, maxSpeed);     // 최대, 최소 속력 사이 랜덤으로 moveSpeed 조절
        move = dir * moveSpeed * Time.deltaTime;        // 움직일 거리
        tr.Translate(move);                     // Translate : 위치 변경
        distance += move.magnitude;             // 거리 표시. move의 값을 더해준다.
    }*/



}
