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

    // �̸����� Ÿ������ �����ͼ� ��ȯ�ϴ� �ڵ�
    public void SetUp(TowerInfo towerInfo)
    {
        selectedTowerInfo = towerInfo;
        gameObject.SetActive(true);
        Debug.Log($"{selectedTowerInfo.name}");
        
        if (previewTower != null)
            Destroy(previewTower);
        previewTower = Instantiate(PreviewTowerAssets.GetPreviewTower(selectedTowerInfo.type),transform);
        // �̸����� Ÿ������ �����ͼ� ��ȯ�ϴ� �ڵ�
        // �Ϲ� Ÿ���鵵 ��ȯ�ϴ� ��ũ��Ʈ �߰�

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
            Destroy(instance);      // ���� : instance�ڸ��� this�� �־���. 
        instance = this;
        gameObject.SetActive(false);
    }
}
