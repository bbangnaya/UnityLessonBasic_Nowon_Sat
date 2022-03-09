using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // 필드의 인스펙터창 노출 설정
    // public : 외부 클래스 접근 O, 인스텍터창 노출 O
    // private : 외부 클래스 접근 X, 인스펙터창 노출 X
    // [HideInInspector] public : 외부 클래스 접근 O 인스펙터창 노출 X
    // [SerializeField] : 외부 클래스 접근 X 인스펙터 창 노출 O

    // this 키워드
    // 객체 자신을 반환하는 키워드(클래스 아님, cube 클래스 타입의 객체 반환)

    public int a = 3;
    public Transform tr;       // transform 클래스 tr 선언
    Vector3 move;               // 3차원 이동을 위해 unity엔진을 위한 Vector3 구조체 move 선언

    private void Awake()
    {
        Debug.Log(this);            // 출력 : Cube (Cube)
        Debug.Log(this.gameObject); // Cube (UnityEngine.GameObject)
        Debug.Log(gameObject);      // Cube (UnityEngine.GameObject)

        tr = this.gameObject.GetComponent<Transform>();
        tr = gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;     // 
    }

    // Start is called before the first frame update
    void Start()        // 초기화단계
    {

        /*tr.position = Vector3.zero; */           // tr의 자식클래스 position에 접근해 원점으로 초기화
        // tr.position = new Vector3(0,0,0); 과 동일
        tr.position = new Vector3(0, 0.5f, 0);
        /*transform.position = Vector3.zero;                                  // 부모클래스로 참조하는 것이므로 MonoBehaviour 참조
        GetComponent<Transform>().position = Vector3.zero;                  // 다단계
        gameObject.GetComponent<Transform>().position = Vector3.zero;       // 다단계
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;  // 다단계*/


    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");      // h에 축 Horizontal에 접근
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h = {h}, v ={v}");              // 입력값 출력
        move = new Vector3(h, 0, v);        // h와 v가 입력할 수 있는 move라는 vector3 클래스 인스턴스화  
        // 여기까지만 입력하면 w,a,s,d를 입력시 h와 v의 값이 실시간으로 바뀐다.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // position 변경시에는 
        // position의 프레임 시간당 변화량을 더해주어야 한다. 
        // 위치 변화량(속도) = 거리 / 시간
        // 프레임 시간당 변화량(프레임 단위 속도) = 위치변화량 / 프레임 시간
        // 위치변화량 = 프레임 시간당 위치 변화량 * 프레임 시간 
        // Time.deltaTime은 프레임 시간당 위치 변화량

        // 실시간으로 움직이는 모습
        /*tr.position += Vector3.right * Time.deltaTime;*/
        // 방향키로 이동하는 코드
        tr.position += move * Time.fixedDeltaTime;
    }
}
