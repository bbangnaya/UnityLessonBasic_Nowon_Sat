using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public static WayPoints instance;
    private Transform[] points;


    public Transform GetFirstWayPoint()
    {
        return points[0];
    }
    /// <summary>
    /// 마지막 포인트 가져오는 함수
    /// </summary>
    public Transform GetLastWayPoint()
    {
        return points[points.Length - 1];
    }
    /// <summary>
    /// 다음 포인트를 가져오는 함수
    /// </summary>
    /// <param name="currentPointIndex"> 현재 포인트 인덱스 </param>
    /// <param name="nextPoint"> 반환할 다음 포인트 Transform </param>
    /// <returns> 다음포인트 가져오는데 성공 : true 실패 : false  </returns>

    public bool TryGetNextWayPoint(int currentPointIndex, out Transform nextPoint)
    {
        nextPoint = null;

        if(currentPointIndex < points.Length - 1)
        {
            nextPoint = points[currentPointIndex + 1];
            return true;
        }
        return false;
    }

    private void Awake()
    {
        if(instance != null)        // 인스턴스 초기화
            Destroy(instance);
        instance = this;
        // Waypoints 의 자식 개수만큼 배열 생성 코드
        points = new Transform[transform.childCount];
        // 생성한 배열에 Waypoints의 transform 정보를 넣는다. 
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);
    }
} 