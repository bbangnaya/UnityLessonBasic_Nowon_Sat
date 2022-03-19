using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 dir = Vector3.back;
    public float speed = 1f;
    Transform tr;
    private void Awake() =>
        tr = GetComponent<Transform>();     // 한줄짜리 함수는 중괄호 없이 => 로 간단하게 표현이 가능하다. 


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }
}
