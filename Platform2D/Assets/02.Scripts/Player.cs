using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private PlayerController controller;

    [SerializeField] private PlayerUI ui;
    public float hpMax = 1000;
    public bool invisiable;
    private float _hp;
    public float hp
    {
        set
        {
            // hp°¡ ±ð¿´À»¶§
            if (_hp > value)
            {
                if (invisiable)
                    return;
                Invoke("InvisiableOff", 1f);
            }
            if (value > 0 && value < hpMax)
            {
                controller.ChangePlayerState(PlayerController.PlayerState.Hurt);
            }
            else if (value <= 0)
            {
                controller.ChangePlayerState(PlayerController.PlayerState.Die);
                value = 0;
            }

            _hp = value;
            if(PlayerUI.instance != null)
                PlayerUI.instance.SetHPBar(_hp / hpMax);
        }
        get
        {
            return _hp;
        }

    }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        hp = hpMax;
    }

    private void Start()
    {
        hp = hpMax;
    }

    void InvisiableOff()
    {
        invisiable = false;
    }

}
