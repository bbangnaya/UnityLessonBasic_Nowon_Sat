using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 키보드 화살표 왼쪽, 오른쪽 방향키로 X축 움직임
    // 키보드 화살표 위쪽, 아래쪽 방향키로 z축 움직임

    public Transform tr;
    Vector3 move;           // 키보드 입력을 받을 변수
    public float speed = 1f;            // public 이라 inspector에서 수정해야 한다. 

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");      // h에 축 Horizontal에 접근
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v).normalized;
    }

    private void FixedUpdate()
    {
        transform.Translate(move * speed * Time.fixedDeltaTime);
        
    }

}
