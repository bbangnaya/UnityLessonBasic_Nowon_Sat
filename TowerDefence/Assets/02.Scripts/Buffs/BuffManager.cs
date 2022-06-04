using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;

    public void ActiveBuff(Enemy enemy, Buff buff)
    {
        // 코루틴을 퍼블릭으로 한다는 건 외부에서 호출한다는 뜻.
        // A B 
    }
    private IEnumerator E_ActiveBuff(Enemy enemy, Buff buff)
    {
        buff.OnActive(enemy);
        bool doBuff = true;
        float timeMark = Time.time;

        while (doBuff & Time.time - timeMark < buff.duration)// 버프 지속시간이 끝날때 까지 돌리기
        {
            doBuff = buff.OnDuration(enemy);
            yield return null;
        }
        buff.OnDeactive(enemy);
    }


    private void Awake()
    {
        if (instance == null)
            Destroy(instance);
        instance = this;
    }




}
