using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir = Vector3.forward;
    public float speed = 5f;
    Transform tr;
    public int damage;
    private void Awake() =>   
        tr = GetComponent<Transform>();     // 한줄짜리 함수는 중괄호 없이 => 로 간단하게 표현이 가능하다. 


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대가 enemy일때 
        GameObject go = other.gameObject;
        if (go == null) return;
        {

        }
        // 레이어 체크
        if (go.layer == LayerMask.NameToLayer("Enemy")) // 레이어가 enemy이면
        {

            go.GetComponent<Enemy>().hp -= damage;
                /*.DoDestroyEffect(); // 외부 클래스 참조. 한줄짜리.
            Destroy(go);        // go를 파괴*/
            Destroy(gameObject);
        }
        
        
    }
}
