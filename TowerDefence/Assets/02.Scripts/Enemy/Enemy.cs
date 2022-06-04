using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float _hp;
    public float hp
    {
        set
        {
            if (value < 0)
                value = 0;

            _hp = value;
            hpBar.value = _hp / hpMax;
            if (_hp <= 0)
            {
                GameObject go = Instantiate(dieEffect.gameObject, transform.position, Quaternion.identity);
                // transform.position, Quaternion.identity 위치 지정. 안쓰면 가운데에 효과 생성
                Destroy(go, dieEffect.main.duration + dieEffect.main.startLifetime.constantMax);
                // dieEffect 자체를 지우는게 아닌 Instantiate한 걸 게임 오브젝트 go로 받아서 go를 삭제
                Destroy(gameObject);
            }



        }
        get
        {
            return _hp;     // 언더바 꼭 확인하기
        }
    }
    public float hpMax;
    [SerializeField] private Slider hpBar;
    [SerializeField] private ParticleSystem dieEffect;

    private void Awake()
    {
        hp = hpMax;
    }
}
