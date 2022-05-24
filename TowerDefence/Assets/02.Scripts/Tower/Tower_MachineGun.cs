using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_MachineGun : Tower
{
    public float damage;
    public float reloadTime;
    private float reloadTimer;


    // Ÿ���� ���� �ƴҶ� ������Ʈ�Լ��� ����
    // Ÿ���� ����ߴµ� Ÿ������ ������Ʈ�� �ִ�. 
    // ���� ������Ʈ �Լ��� �����ε��Ѵ�.(Ÿ�� ��ũ��Ʈ�� ������Ʈ�Լ��� �����Լ��� �ٲٱ�)
    protected override void Update()
    {
        base.Update();
        // ������
        if(reloadTimer < 0)
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
        // target�� ü���� damage��ŭ ����
        target.GetComponent<Enemy>().hp -= damage;

    }


}
