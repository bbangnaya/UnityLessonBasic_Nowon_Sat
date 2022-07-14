using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isOn;
    [SerializeField] private LayerMask groundLayer;

    private void OnTriggerEnter(Collider other)
    {
        if(isOn == false &&
            1 << other.gameObject.layer == groundLayer) // 1 << �� ���̾� ����ũ Ÿ��(��Ʈ����)�� ���߱� ���ؼ��̴�.
        {
            isOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) �� ������ �ִ�. 
        if (isOn &&
            1 << other.gameObject.layer == groundLayer) // 1�� 15�� �������� �о�� 15���� ��Ʈ �÷��׿� ����������.
                                                        // ���ؿ� ������ ���� �ʿ��� �ڵ�
        {
            isOn = false;
        }
    }

}
