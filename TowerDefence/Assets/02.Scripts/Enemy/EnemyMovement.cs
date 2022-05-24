using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float posTolerance = 0.1f;
    private Transform tr;
    private int currentPointIndex = 0;
    private Transform nextWayPoint; // out으로 쓴 매개변수 호출
    // 적 생성시 위치 선정
    private float originPosY;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        originPosY = tr.position.y;
    }

    private void Start()
    {
        /*WayPoints.TryGetNextWayPoint(-1, out nextWayPoint);*/
        nextWayPoint = WayPoints.instance.GetFirstWayPoint();
        // 클래스가 아닌 인스턴스로 접근
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(nextWayPoint.position.x,
            originPosY,
            nextWayPoint.position.z);       // y축은 고정. 계속 움직이도록 하는 코드
        Vector3 dir = (targetPos - tr.position).normalized; // 방향벡터

        // 타겟위치에 도착했는지 체크
        if(Vector3.Distance(tr.position, targetPos) < posTolerance)     // 둘 사이 간격을 구해주는 함수
        {
            // 다음 타겟위치 받아옴
            if (WayPoints.instance.TryGetNextWayPoint(currentPointIndex, out nextWayPoint)) // 받아오는데 성공
            {
                currentPointIndex++;
                tr.LookAt(nextWayPoint);        // 방향 전환. 다음 포인트 위치를 바라보도록 함.
            }
            // 마지막 타겟에 도착
            else    // 다음 위치 정보 없음
            {
                OnReachedToEnd();       // 끝났다고 알리는 함수 호출
            }
        }

        tr.Translate(dir * moveSpeed * Time.fixedDeltaTime, Space.World);

    }

    private void OnReachedToEnd()
    {
        gameObject.SetActive(false);
    }

}
