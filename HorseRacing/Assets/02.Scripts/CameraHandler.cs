using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    private int targetIndex = 0;        // targetIndex�� �ϳ��� �������Ѽ� ī�޶� ��ȯ
    private Vector3 offset = new Vector3(0, 2, -4);

    private void Awake()
    {
        tr = transform;
    }

    private void Start()
    {
        foreach (var item in GamePlay.instance.players)
        {
            players.Add(item.transform);
        }
    }

    // Update is called once per frame
    // ���� ���������� ī�޶� �̵�
    void Update()
    {
        if (GamePlay.instance.onPlay)           // static�� �־�� �ٸ� Ŭ������ �ִ� ������ ������ �����ϴ�.GamePlay.onPlay
                                                //�Ǵ� 
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchTarget();
            }
        }
    }

    private void FixedUpdate()
    {
        Followtarget();
    }

    private void SwitchTarget()
    {
        targetIndex++;
        if(targetIndex >= players.Count)
            targetIndex = 0;
    }

    private void Followtarget()
    {
        tr.position = players[targetIndex].position + offset;            // ������ update���� input�Լ��� ������ �Ѵ�. fixed�� �ȵȴ�. 
    }
    // offset�ֱ�

}