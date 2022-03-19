using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir = Vector3.forward;
    public float speed = 5f;
    Transform tr;
    private void Awake() =>   
        tr = GetComponent<Transform>();     // ����¥�� �Լ��� �߰�ȣ ���� => �� �����ϰ� ǥ���� �����ϴ�. 


    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.Translate(dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��밡 enemy�϶� 
        GameObject go = other.gameObject;
        if (go == null) return;
        {

        }
        // ���̾� üũ
        if (go.layer == LayerMask.NameToLayer("Enemy")) // ���̾ enemy�̸�
        {

            go.GetComponent<Enemy>().DoDestroyEffect(); // �ܺ� Ŭ���� ����. ����¥��.
            Destroy(go);        // go�� �ı�
            Destroy(gameObject);
        }
        
        
    }
}
