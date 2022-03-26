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
 