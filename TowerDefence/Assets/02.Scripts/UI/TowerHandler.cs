using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHandler : MonoBehaviour
{
    public static TowerHandler instance;
    public GameObject previewTower;

    public bool isSelected
    {
        get
        {
            return selectedTowerInfo != null ? true : false;
        }
    }
    public TowerInfo selectedTowerInfo;

    // 미리보기 타워들을 가져와서 소환하는 코드
    public void SetUp(TowerInfo towerInfo)
    {
        selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);
        Debug.Log($"{selectedTowerInfo.name}");
        
        if (previewTower != null)
            Destroy(previewTower);
        previewTower = Instantiate(PreviewTowerAssets.GetPreviewTower(selectedTowerInfo.type),transform);
        // 미리보기 타워들을 가져와서 소환하는 코드
        // 일반 타워들도 소환하는 스크립트 추가

    }

    public void Clear()
    {
        selectedTowerInfo = null;
        gameObject.SetActive(false);
        if (previewTower != null)
            Destroy(previewTower);
    }

    public void SendFar()
    {
        transform.position = new Vector3(5000f, 5000f, 5000f);
    }

    private void Awake()
    {
        if (instance == null)
            Destroy(instance);      // 오류 : instance자리에 this가 있었다. 
        instance = this;
        gameObject.SetActive(false);
    }
}
