using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciiFiWarrior : MonoBehaviour
{
    // �ʵ��� �ν�����â ���� ����
    // public : �ܺ� Ŭ���� ���� O, �ν�����â ���� O
    // private : �ܺ� Ŭ���� ���� X, �ν�����â ���� X
    // [HideInInspector] public : �ܺ� Ŭ���� ���� O �ν�����â ���� X
    // [SerializeField] : �ܺ� Ŭ���� ���� X �ν����� â ���� O

    // this Ű����
    // ��ü �ڽ��� ��ȯ�ϴ� Ű����(Ŭ���� �ƴ�, cube Ŭ���� Ÿ���� ��ü ��ȯ)

    public int a = 3;
    private Transform tr;
    public float moveSpeed;

    Vector3 move;


    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);

        tr = this.gameObject.GetComponent<Transform>();
        tr = gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;





    }

    // Start is called before the first frame update
    void Start()
    {

        tr.position = Vector3.zero;
        transform.position = Vector3.zero;                                  // �θ�Ŭ������ �����ϴ� ���̹Ƿ� MonoBehaviour ����
        GetComponent<Transform>().position = Vector3.zero;                  // �ٴܰ�
        gameObject.GetComponent<Transform>().position = Vector3.zero;       // �ٴܰ�
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;  // �ٴܰ�


    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h = {h}, v ={v}");
        move = new Vector3(h, 0, v);

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
        /*tr.position += Vector3.forward * Time.deltaTime;*/

        tr.position += move * moveSpeed * Time.fixedDeltaTime;


    }
}
