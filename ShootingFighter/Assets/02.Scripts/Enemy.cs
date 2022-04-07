using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        */
    /*collsion.gameObject.GetComponent<Player>().Hurt();
        Destroy(gameObject);*/
    /*
        if(collision.gameObject == null)
        {
            Debug.Log(collision.gameObject.name);
        }*/
    /*
        Debug.Log($"collieded! {collision.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"triggerd! {other.gameObject.name}");
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }*/

    public GameObject destroyEffect;
    public LayerMask targetLayer;
    public int damage;
    public int score;
    public int hpMax;

    private void Awake()
    {
        hp = hpMax;
    }

    // 멤버변수는 private 키워드로 정보은닉을 실천하고 접근 제한자가 public 인 멤버 함수를 통해
    // 멤버 변수의 값을 반환하는 형식으로 객체를 캡슐화 라고 한다.
    // 정보은식을 위해 private 키워드를 썼지만 이에 접근하기가 번거로워졌다.
    // 클래스 내부 멤버 변수의 값을 가져오거나 설정하기 위해 여러 개의 멤버 함수를 작성하는 것은 비효율적이다.
    // 따라서 C#에서는 Property라는 문법이 제공된다.

    // 기존에는 private로 선언한 변수를 가져오기 위해선 get, set 메소드를 구현했어야 했다.
    // C# 프로퍼티는 간단하고 유연성 있게 전용 필드의 값을 읽거나 쓰는 메커니즘을 제공합니다.
    // public 멤버 변수처럼 접근 할 수 있지만 실은 접근자라는 특수 메서드입니다.
    // 이를 통해 데이터에 쉽게 액세스할 수 있으며 안정성과 유연성의 수준을 올리는데 도움이 됩니다.
    //    출처: https://itmining.tistory.com/34 [IT 마이닝]

    // 프로퍼티 특징
    // 1. 프로퍼티를 사용하면 클래스가 구현 또는 코드를 숨기는 동시에 값을 가져오고 설정하는 방법을 공개적으로 노출할 수 있습니다.
    // 2. get 속성 접근자는 속성 값을 반환하고, set 접근자는 새 값을 할당하는데 사용합니다.
    // 3. set 접근자의 value 키워드는 set 접근자가 할당하는 값을 정의하는데 사용합니다.
    // 4. set 접근자만을 구현하면 쓰기 전용, get 접근자만을 구현하면 읽기 전용입니다.
    // 출처: https://itmining.tistory.com/34 [IT 마이닝]


    private int _hp;       // 읽기만 가능, 멤버hp
    public int hp           // 수정
    {
        set
        {
            if (value > 0)
                _hp = value;
            else
            {
                _hp = 0;
                Player.instance.score += score;
                Destroy(gameObject);
                DoDestroyEffect();
            }
            _hp = value;
            hpSlider.value = (float)_hp / hpMax;
        }
        get
        {
            return _hp;
        }
    }


    public Slider hpSlider;
    /*private void OnDestroy()
    {
        if(Player.instance !=null)
            Player.instance.score += score;
    }===> Bullet으로 옮겨짐*/
    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position, Quaternion.identity);
        Destroy(go,3);
    }

    // 충돌시 체력 깎기
    /*private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<Player>().hp -= damage;
            Destroy(gameObject);
        }
    }*/
    // Player에 접근이 쉬워진다.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.instance.hp -= damage;
            Destroy(gameObject);
        }
    }

}
 