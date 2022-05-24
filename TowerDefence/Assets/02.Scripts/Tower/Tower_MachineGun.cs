using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_MachineGun : Tower
{
    public float damage;
    public float reloadTime;
    private float reloadTimer;


    // 타켓이 널이 아닐때 업데이트함수로 어택
    // 타워를 상속했는데 타워에서 업데이트가 있다. 
    // 따라서 업데이트 함수를 오버로드한다.(타워 스크립트도 업데이트함수를 가상함수로 바꾸기)
    protected override void Update()
    {
        base.Update();
        // 재장전
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
        // target의 체력을 damage만큼 깎음
        target.GetComponent<Enemy>().hp -= damage;

    }


}
