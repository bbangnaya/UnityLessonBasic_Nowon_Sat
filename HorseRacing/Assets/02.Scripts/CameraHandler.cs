using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    private int targetIndex = 0;        // targetIndex를 하나씩 증가시켜서 카메라 전환
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
    // 탭을 누를때마다 카메라 이동
    void Update()
    {
        if (GamePlay.instance.onPlay)           // static이 있어야 다른 클래스에 있는 변수에 접근이 가능하다.GamePlay.onPlay
                                                //또는 
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
        tr.position = players[targetIndex].position + offset;            // 무조건 update에서 input함수를 돌려야 한다. fixed는 안된다. 
    }
    // offset주기

}