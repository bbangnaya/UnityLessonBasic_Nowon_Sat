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
    private TowerInfo selectedTowerInfo;

    public void SetUp(TowerInfo towerInfo)
    {
        selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);
        if (previewTower != null)
            Destroy(previewTower);
        previewTower = Instantiate(PreviewTowerAssets.GetPreviewTower(selectedTowerInfo.type),transform);

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
