using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    // 지속시간
    public float duration;
    // 중간에 해당 버프를 해제해야 하는 경우 대비
    public bool doBuff = true;

    public virtual void OnActive(Enemy target)
    {


    } 

    public virtual void OnDeactive(Enemy target)
    {

    }

    public virtual bool OnDuration(Enemy target)
    {
        // 외부에서 강제로 꺼버리면 OnDeactive가 호출이 안되기 때문에
        // 매니저가 false받으면 OnDeactive을 호출해 코루틴으로 끄기
        return doBuff;
    }
    public void TurnOff()
    {
        doBuff = false;
    }

}
