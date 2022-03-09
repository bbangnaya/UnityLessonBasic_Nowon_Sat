using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // �ʵ��� �ν�����â ���� ����
    // public : �ܺ� Ŭ���� ���� O, �ν�����â ���� O
    // private : �ܺ� Ŭ���� ���� X, �ν�����â ���� X
    // [HideInInspector] public : �ܺ� Ŭ���� ���� O �ν�����â ���� X
    // [SerializeField] : �ܺ� Ŭ���� ���� X �ν����� â ���� O

    // this Ű����
    // ��ü �ڽ��� ��ȯ�ϴ� Ű����(Ŭ���� �ƴ�, cube Ŭ���� Ÿ���� ��ü ��ȯ)

    public int a = 3;
    public Transform tr;       // transform Ŭ���� tr ����
    Vector3 move;               // 3���� �̵��� ���� unity������ ���� Vector3 ����ü move ����

    private void Awake()
    {
        Debug.Log(this);            // ��� : Cube (Cube)
        Debug.Log(this.gameObject); // Cube (UnityEngine.GameObject)
        Debug.Log(gameObject);      // Cube (UnityEngine.GameObject)

        tr = this.gameObject.GetComponent<Transform>();
        tr = gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;     // 
    }

    // Start is called before the first frame update
    void Start()        // �ʱ�ȭ�ܰ�
    {

        /*tr.position = Vector3.zero; */           // tr�� �ڽ�Ŭ���� position�� ������ �������� �ʱ�ȭ
        // tr.position = new Vector3(0,0,0); �� ����
        tr.position = new Vector3(0, 0.5f, 0);
        /*transform.position = Vector3.zero;                                  // �θ�Ŭ������ �����ϴ� ���̹Ƿ� MonoBehaviour ����
        GetComponent<Transform>().position = Vector3.zero;                  // �ٴܰ�
        gameObject.GetComponent<Transform>().position = Vector3.zero;       // �ٴܰ�
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;  // �ٴܰ�*/


    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");      // h�� �� Horizontal�� ����
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h = {h}, v ={v}");              // �Է°� ���
        move = new Vector3(h, 0, v);        // h�� v�� �Է��� �� �ִ� move��� vector3 Ŭ���� �ν��Ͻ�ȭ  
        // ��������� �Է��ϸ� w,a,s,d�� �Է½� h�� v�� ���� �ǽð����� �ٲ��.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // position ����ÿ��� 
        // position�� ������ �ð��� ��ȭ���� �����־�� �Ѵ�. 
        // ��ġ ��ȭ��(�ӵ�) = �Ÿ� / �ð�
        // ������ �ð��� ��ȭ��(������ ���� �ӵ�) = ��ġ��ȭ�� / ������ �ð�
        // ��ġ��ȭ�� = ������ �ð��� ��ġ ��ȭ�� * ������ �ð� 
        // Time.deltaTime�� ������ �ð��� ��ġ ��ȭ��

        // �ǽð����� �����̴� ���
        /*tr.position += Vector3.right * Time.deltaTime;*/
        // ����Ű�� �̵��ϴ� �ڵ�
        tr.position += move * Time.fixedDeltaTime;
    }
}
