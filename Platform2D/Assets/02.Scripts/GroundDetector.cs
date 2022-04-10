using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isDetected;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private Vector2 size;       // 박스 감지할 크기
    private Vector2 center;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;        // 감지할 범위의 사이즈
    }

    private void Update(){
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;
        isDetected = Physics2D.OverlapBox(center, size, 0, groundLayer);
    }

    private void OnDrawGizmos()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        size.x = col.size.x / 2;
        size.y = 0.005f;
        center.x = rb.position.x + col.offset.x;
        center.y = rb.position.y + col.offset.y - col.size.y / 2 - size.y;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(center.x,center.y,0),
            new Vector3(size.x,size.y,0));
    }

}
  