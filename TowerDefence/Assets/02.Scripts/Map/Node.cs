using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // ���콺 Ŭ���� ����ȭ
    public float towerOffsetY;
    private Tower towerBuilt;
    private Renderer rend;
    private Color originalColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    public TowerInfo towerInfo
    {
        get { return towerBuilt.info; }
    }

    // �Ǽ�
    public void BuildTower(GameObject towerPrefab)
    {
        towerBuilt = Instantiate(towerPrefab,
                                 transform.position + Vector3.up * towerOffsetY,
                                 Quaternion.identity,
                                 transform).GetComponent<Tower>();
        LevelManager.instance.money -= towerInfo.buildPrice;
    }

    public void DestroyTower()
    {
        Destroy(towerBuilt.gameObject);
        towerBuilt = null;
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (TowerHandler.instance.isSelected)
        {
            TowerHandler.instance.transform.position = transform.position + Vector3.up * towerOffsetY;

            if (towerBuilt == null)
            {
                rend.material.color = buildAvailableColor;
            }
            else
            {
                rend.material.color = buildNotAvailableColor;
            }
        }
    }

    // ���⼭ ����(01:05:00)
    private void OnMouseDown()
    {
        // Ÿ���� �����ߴ��� ���� && towerBuilt = �Ǽ�����, null üũ 
        if (TowerHandler.instance.isSelected &&
            towerBuilt == null)
        {
            TowerInfo info = TowerHandler.instance.selectedTowerInfo;
            if (TowerAssets.TryGetTowerPrefab(info.type, info.upgradeLevel, out GameObject towerPrefab))
            {// ������ �������µ� �����ϸ�?
                // ��1 ) ��忡 ���ӽ�Ű�� �ʹ�
                // GameObject go = Instantiate(towerPrefab, transform);
                // go.transform.Translate(Vector3.up * towerOffsetY);

                // ��2
                BuildTower(towerPrefab);
                TowerHandler.instance.Clear();
            }
            else        // Ÿ�� �������µ� ����. �̷��� ����ó��. ���߽� �����ؾ� �� �κ�.
            {
                throw new System.Exception("Ÿ�� �������� �������µ� ������. Ÿ�� Ÿ�԰� ������ Ȯ�����ּ���.");
            }
        }
        else if (TowerHandler.instance.isSelected == false &&
                towerBuilt != null)
        { 
            TowerUI.instance.SetUp(towerBuilt.transform.position, this);
        }                       
    }



    private void OnMouseExit()
    {
        TowerHandler.instance.SendFar();
        rend.material.color = originalColor;
    }
}
