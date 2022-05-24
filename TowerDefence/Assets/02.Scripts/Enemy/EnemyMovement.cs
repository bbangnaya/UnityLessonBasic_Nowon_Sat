using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float posTolerance = 0.1f;
    private Transform tr;
    private int currentPointIndex = 0;
    private Transform nextWayPoint; // out���� �� �Ű����� ȣ��
    // �� ������ ��ġ ����
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
        // Ŭ������ �ƴ� �ν��Ͻ��� ����
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(nextWayPoint.position.x,
            originPosY,
            nextWayPoint.position.z);       // y���� ����. ��� �����̵��� �ϴ� �ڵ�
        Vector3 dir = (targetPos - tr.position).normalized; // ���⺤��

        // Ÿ����ġ�� �����ߴ��� üũ
        if(Vector3.Distance(tr.position, targetPos) < posTolerance)     // �� ���� ������ �����ִ� �Լ�
        {
            // ���� Ÿ����ġ �޾ƿ�
            if (WayPoints.instance.TryGetNextWayPoint(currentPointIndex, out nextWayPoint)) // �޾ƿ��µ� ����
            {
                currentPointIndex++;
                tr.LookAt(nextWayPoint);        // ���� ��ȯ. ���� ����Ʈ ��ġ�� �ٶ󺸵��� ��.
            }
            // ������ Ÿ�ٿ� ����
            else    // ���� ��ġ ���� ����
            {
                OnReachedToEnd();       // �����ٰ� �˸��� �Լ� ȣ��
            }
        }

        tr.Translate(dir * moveSpeed * Time.fixedDeltaTime, Space.World);

    }

    private void OnReachedToEnd()
    {
        gameObject.SetActive(false);
    }

}
