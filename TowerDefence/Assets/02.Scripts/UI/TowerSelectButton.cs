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
            // Ŭ���ϸ鼭 ���� �����°� �ƴ϶� �Ǽ��Ҷ� ���� ������ �ϰ�
            // Ŭ���� ����� �� �� �־�� �Ѵ�.
        }
        else
        {
            // ���� �����ϴٴ� �˾�â ����
            Debug.Log("���� �����մϴ�.");
            // �Ǽ� ���ϰ� ���� �ڵ�

        }
    }



}
