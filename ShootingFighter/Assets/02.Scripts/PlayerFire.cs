using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;         // Gameobject��  bulletPrefab�� ���� �� �ִ�.
    // �߻� ��ġ �ʿ�
    public Transform firepoint;         // firepoint�� ���� �ִ´�.(��ġ���� ������)
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
            // ���������� ������ ���ο� ���ӿ�����Ʈ�� �����ϴ� ��ɾ�
            // ���� Ÿ���� ���� ������Ʈ�̾�� �Ѵ�.
            Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            // rotation : Ÿ���� Quaternion(�����), ���Ϸ�(eulerangles)
            // identity : ȸ���� 0��
            fireTimer = fireTimeGap;

        }
        else 
            fireTimer -= Time.deltaTime;
    }

}
