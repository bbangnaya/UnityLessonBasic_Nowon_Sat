using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // 마우스 클릭시 색변화
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

/*    public TowerInfo GetTowerInfo()
    {
        return towerBuilt.info;
    }*/


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


    private void OnMouseDown()
    {
        // 타워를 선택했는지 여부 && towerBuilt = 건설여부, null 체크 
        if (TowerHandler.instance.isSelected &&
            towerBuilt == null)
        {
            TowerInfo info = TowerHandler.instance.selectedTowerInfo;
            if (TowerAssets.TryGetTowerPrefab(info.type, info.upgradeLevel, out GameObject towerPrefab))
            {// 프리펩 가져오는데 성공하면?
                // 방1 ) 노드에 종속시키고 싶다
                // GameObject go = Instantiate(towerPrefab, transform);
                // go.transform.Translate(Vector3.up * towerOffsetY);

                // 방2
                BuildTower(towerPrefab);
                TowerHandler.instance.Clear();
            }
            else        // 타워 가져오는데 실패. 이런건 예외처리. 개발시 주의해야 할 부분.
            {
                throw new System.Exception("타워 프리팹을 가져오는데 실패함. 타워 타입과 레벨을 확인해주세요.");
            }
        }
        else if (TowerHandler.instance.isSelected == false &&
                towerBuilt != null)
        { 
            TowerUI.instance.SetUp(towerBuilt.transform.position, this);
        }                       
    }

    public void BuildTower(GameObject towerPrefab)
    {
        towerBuilt = Instantiate(towerPrefab,
                                        transform.position + Vector3.up * towerOffsetY,
                                        Quaternion.identity,
                                        transform).GetComponent<Tower>();
    }

    public void DestroyTower()
    {
        Destroy(towerBuilt.gameObject);
        towerBuilt = null;
    }

    private void OnMouseExit()
    {
        TowerHandler.instance.SendFar();
        rend.material.color = originalColor;
    }
}
