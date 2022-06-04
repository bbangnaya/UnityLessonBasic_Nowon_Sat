using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public TowerInfo info;
    public LayerMask enemyLayer;
    public float detectRange;       // ���ݹݰ�

    public Transform rotatePoint;
    public Transform target;

    protected Transform tr;
    // �ڽ� Ŭ������ 

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    protected virtual void Update()     // �ӽŰ� Ÿ�� ���, �����ε带 ���� �����Լ��� �ٲ�.
    {
        // ���ʹ� Ÿ����(���� Ÿ����)
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);
        if (cols.Length > 0)
        {
            // Ÿ��ŷ�� �� �켱 ������ ��� ���� ���ΰ� = ���������� ����� ��
            // waypoint�� ������ ��ǥ������ ��������.
            cols.OrderBy(x => (x.transform.position - WayPoints.instance.GetLastWayPoint().position).magnitude);
            // �������� ����. ���⼭ ����� ���� 0��° �迭���� �����´�.
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