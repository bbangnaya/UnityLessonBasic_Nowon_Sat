using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public TowerInfo info;
    public LayerMask enemyLayer;
    public float detectRange;       // 공격반경

    public Transform rotatePoint;
    public Transform target;

    protected Transform tr;
    // 자식 클래스만 

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    protected virtual void Update()     // 머신건 타워 상속, 오버로드를 위해 가상함수로 바꿈.
    {
        // 에너미 타게팅(단일 타게팅)
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);
        if (cols.Length > 0)
        {
            // 타게킹할 때 우선 순위는 어떻게 잡을 것인가 = 골인지점과 가까운 놈
            // waypoint의 마지막 좌표정보를 가져오자.
            cols.OrderBy(x => (x.transform.position - WayPoints.instance.GetLastWayPoint().position).magnitude);
            // 오름차순 정렬. 여기서 가까운 놈은 0번째 배열값을 가져온다.
            target = cols[0].transform;
            rotatePoint.LookAt(target);

        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

}