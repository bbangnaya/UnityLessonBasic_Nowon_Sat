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
            1 << other.gameObject.layer == groundLayer) // 1 << 은 레이어 마스크 타입(비트연산)을 맞추기 위해서이다.
        {
            isOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // if(other.gameObject.layer == LayerMask.NameToLayer("Ground")) 로 쓸수도 있다. 
        if (isOn &&
            1 << other.gameObject.layer == groundLayer) // 1을 15번 왼쪽으로 밀어야 15번쨰 비트 플래그와 동일해진다.
                                                        // 이해와 연습이 많이 필요한 코드
        {
            isOn = false;
        }
    }

}
