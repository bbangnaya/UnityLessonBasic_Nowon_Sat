using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Laser : Tower
{
    public float damage;
    public float reloadTime;
    public float reloadTimer;

    protected override void Update()
    {
        base.Update();
        // 재장전
        if (reloadTimer < 0)
        {
            if (target != null)
            {
                Attack();
                reloadTimer = reloadTime;
            }
        }
        else
        {
            reloadTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        // target의 체력을 damage만큼 깎음
        target.GetComponent<Enemy>().hp -= damage;

    }
}
