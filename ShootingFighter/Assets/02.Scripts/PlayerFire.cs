using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;         // Gameobject로  bulletPrefab을 넣을 수 있다.
    // 발사 위치 필요
    public Transform firepoint;         // firepoint를 집어 넣는다.(위치정보 가져옴)
    public float fireTimeGap = 0.01f;
    private float fireTimer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            fireTimer = fireTimeGap;
        }

        if (fireTimer < 0 && Input.GetKey(KeyCode.Space)) 
        { 
            // 오리지날을 넣으면 새로운 게임오브젝트를 생성하는 명령어
            // 원본 타입이 게임 오브젝트이어야 한다.
            Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            // rotation : 타입이 Quaternion(사원수), 오일러(eulerangles)
            // identity : 회전각 0도
            fireTimer = fireTimeGap;

        }
        else 
            fireTimer -= Time.deltaTime;
    }

}
