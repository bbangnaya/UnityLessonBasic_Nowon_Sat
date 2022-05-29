using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectButton : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;

    public void OnClick()
    {
        if(towerInfo.buildPrice <= LevelManager.instance.money)
        {
            TowerHandler.instance.SetUp(towerInfo);
            // LevelManager.instance.money -= towerInfo.buildPrice;
            // 클릭하면서 돈이 나가는게 아니라 건설할때 돈이 나가야 하고
            // 클릭을 취소할 수 도 있어야 한다.
        }
        else
        {
            // 돈이 부족하다는 팝업창 띄우기
            Debug.Log("돈이 부족합니다.");
            // 건설 못하게 막는 코드

        }
    }



}
