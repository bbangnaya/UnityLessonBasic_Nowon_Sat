using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyController controller;

    [SerializeField] private EnemyUI ui;
    public float hpMax = 100;

    private float _hp;
    public float hp
    {
        set 
        {
            if (value > 0 && value < hpMax)
            {
                controller.ChangeEnemyState(EnemyState.Hurt);
            }
            else if(value <= 0)
            {
                controller.ChangeEnemyState(EnemyState.Die);
                value = 0;
            }

            _hp = value;
            ui.SetHPBar(_hp / hpMax);

        }
        get 
        { 
            return _hp;
        }

    }

    public float damage = 20f;
    public Vector2 KnockbackForce;
    public float KnockbackTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Player>().hp -= damage;

            collision.gameObject.GetComponent<PlayerController>().Knockback(new Vector2(KnockbackForce.x*controller.direction, KnockbackForce.y)
                ,KnockbackTime);
        }
    }


    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        hp = hpMax;
    }
}
