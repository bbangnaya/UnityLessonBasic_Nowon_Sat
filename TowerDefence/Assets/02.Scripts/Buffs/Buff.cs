using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    // ���ӽð�
    public float duration;
    // �߰��� �ش� ������ �����ؾ� �ϴ� ��� ���
    public bool doBuff = true;

    public virtual void OnActive(Enemy target)
    {


    } 

    public virtual void OnDeactive(Enemy target)
    {

    }

    public virtual bool OnDuration(Enemy target)
    {
        // �ܺο��� ������ �������� OnDeactive�� ȣ���� �ȵǱ� ������
        // �Ŵ����� false������ OnDeactive�� ȣ���� �ڷ�ƾ���� ����
        return doBuff;
    }
    public void TurnOff()
    {
        doBuff = false;
    }

}
