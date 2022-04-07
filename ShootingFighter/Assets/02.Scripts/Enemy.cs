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

    // ��������� private Ű����� ���������� ��õ�ϰ� ���� �����ڰ� public �� ��� �Լ��� ����
    // ��� ������ ���� ��ȯ�ϴ� �������� ��ü�� ĸ��ȭ ��� �Ѵ�.
    // ���������� ���� private Ű���带 ������ �̿� �����ϱⰡ ���ŷο�����.
    // Ŭ���� ���� ��� ������ ���� �������ų� �����ϱ� ���� ���� ���� ��� �Լ��� �ۼ��ϴ� ���� ��ȿ�����̴�.
    // ���� C#������ Property��� ������ �����ȴ�.

    // �������� private�� ������ ������ �������� ���ؼ� get, set �޼ҵ带 �����߾�� �ߴ�.
    // C# ������Ƽ�� �����ϰ� ������ �ְ� ���� �ʵ��� ���� �аų� ���� ��Ŀ������ �����մϴ�.
    // public ��� ����ó�� ���� �� �� ������ ���� �����ڶ�� Ư�� �޼����Դϴ�.
    // �̸� ���� �����Ϳ� ���� �׼����� �� ������ �������� �������� ������ �ø��µ� ������ �˴ϴ�.
    //    ��ó: https://itmining.tistory.com/34 [IT ���̴�]

    // ������Ƽ Ư¡
    // 1. ������Ƽ�� ����ϸ� Ŭ������ ���� �Ǵ� �ڵ带 ����� ���ÿ� ���� �������� �����ϴ� ����� ���������� ������ �� �ֽ��ϴ�.
    // 2. get �Ӽ� �����ڴ� �Ӽ� ���� ��ȯ�ϰ�, set �����ڴ� �� ���� �Ҵ��ϴµ� ����մϴ�.
    // 3. set �������� value Ű����� set �����ڰ� �Ҵ��ϴ� ���� �����ϴµ� ����մϴ�.
    // 4. set �����ڸ��� �����ϸ� ���� ����, get �����ڸ��� �����ϸ� �б� �����Դϴ�.
    // ��ó: https://itmining.tistory.com/34 [IT ���̴�]


    private int _hp;       // �б⸸ ����, ���hp
    public int hp           // ����
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
    }===> Bullet���� �Ű���*/
    public void DoDestroyEffect()
    {
        GameObject go = Instantiate(destroyEffect,transform.position, Quaternion.identity);
        Destroy(go,3);
    }

    // �浹�� ü�� ���
    /*private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<Player>().hp -= damage;
            Destroy(gameObject);
        }
    }*/
    // Player�� ������ ��������.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.instance.hp -= damage;
            Destroy(gameObject);
        }
    }

}
 