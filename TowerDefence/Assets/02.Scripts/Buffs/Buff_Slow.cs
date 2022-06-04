using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buff_Slow : Buff
{
    public float slowPercent;
    private EnemyMovement enemyMovement;
    private float enemySpeedOrigin;

    public override void OnActive(Enemy target)
    {
        base.OnActive(target);
        enemyMovement = target.GetComponent<EnemyMovement>();
        enemySpeedOrigin = enemyMovement.moveSpeed;

        float tmpSpeed = enemySpeedOrigin * (1f - slowPercent / 100.0f);
        if (enemyMovement.moveSpeed > tmpSpeed)
            enemyMovement.moveSpeed = tmpSpeed;
    }

    public override void OnDeactive(Enemy target)
    {
        base.OnDeactive(target);
        // 버프적용중인 에너미(target)가 파괴됐을 때 감안해서 코드짜기
        if (target != null)
            enemyMovement.moveSpeed = enemySpeedOrigin;
    }

    public override bool OnDuration(Enemy target)
    {
        return target == null ? false : true;
        /*// 파괴되면 널 체크
        if (target == null)
        {
            doBuff = false;
        }
        return doBuff;*/
    }
}
