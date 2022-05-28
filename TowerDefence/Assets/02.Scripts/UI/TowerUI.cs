using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;

    // 프로퍼티라는 개념때문에 C#에서는 private에게는 _를 많이 붙인다.


    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private Text upgradePriceText;
    [SerializeField] private Text sellPriceText;

    private Node _node;
    private float _offsetY = 1f;
    private Color _textColorOrigin;

    public void Upgrade()
    {

            if (TowerAssets.TryGetTowerPrefab(_node.towerInfo.type,
                _node.towerInfo.upgradeLevel + 1,
                out GameObject towerPrefab))
            {
                _node.DestroyTower();
                _node.BuildTower(towerPrefab);
                LevelManager.instance.money -= towerPrefab.GetComponent<Tower>().info.buildPrice;
            }
        Clear();
    }

    public void Sell()
    {
        LevelManager.instance.money += _node.towerInfo.sellPrice;
        _node.DestroyTower();
        Clear();

    }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;

        _textColorOrigin = upgradePriceText.color;
        Clear();
    }

    public void SetUp(Vector3 position, Node node)
    {
        _node = node;

        // 위치 세팅
        transform.position = position + Vector3.up * _offsetY;

        //업그레이드 버튼 세팅
        if(TowerAssets.TryGetTowerPrefab(_node.towerInfo.type, _node.towerInfo.upgradeLevel + 1, out GameObject towerPrefab))
        {
            int upgradePrice = towerPrefab.GetComponent<Tower>().info.buildPrice;
            // 업드레이드 가능하지 않으면 텍스트 빨갛게, 상호작용 불가능하게 함.
            if(upgradePrice > LevelManager.instance.money)
            {
                upgradePriceText.color = Color.red;
                // 상호작용 불가
                upgradeButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                upgradePriceText.color = _textColorOrigin;
                upgradeButton.GetComponent<Button>().interactable = true;
            }

            upgradePriceText.text = upgradePrice.ToString();
            upgradeButton.SetActive(true);
            
        }
        else  // 가져오는데 실패, 즉 더이상 업글 불가
        {
            upgradeButton.SetActive(false);
        }

        // 팔기 버튼
        sellPriceText.text = _node.towerInfo.sellPrice.ToString();

        gameObject.SetActive(false);

    }

    public void Clear()
    {// 노드 초기화
        _node = null;
        upgradePriceText.text = "";
        sellPriceText.text = "";
        gameObject.SetActive(false);

    }


}
