using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 dir = Vector3.back;
    public float speed = 1f;
    Transform tr;
    private void Awake() =>
        tr = GetComponent<Transform>();     // ����¥�� �Լ��� �߰�ȣ ���� => �� �����ϰ� ǥ���� �����ϴ�. 


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }
}
