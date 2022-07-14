using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;

    // ������Ƽ��� ���䶧���� C#������ private���Դ� _�� ���� ���δ�.


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

        // ��ġ ����
        transform.position = position + Vector3.up * _offsetY;

        //���׷��̵� ��ư ����
        if(TowerAssets.TryGetTowerPrefab(_node.towerInfo.type, _node.towerInfo.upgradeLevel + 1, out GameObject towerPrefab))
        {
            int upgradePrice = towerPrefab.GetComponent<Tower>().info.buildPrice;
            // ���巹�̵� �������� ������ �ؽ�Ʈ ������, ��ȣ�ۿ� �Ұ����ϰ� ��.
            if(upgradePrice > LevelManager.instance.money)
            {
                upgradePriceText.color = Color.red;
                // ��ȣ�ۿ� �Ұ�
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
        else  // �������µ� ����, �� ���̻� ���� �Ұ�
        {
            upgradeButton.SetActive(false);
        }

        // �ȱ� ��ư
        sellPriceText.text = _node.towerInfo.sellPrice.ToString();

        gameObject.SetActive(true);

    }

    public void Clear()
    {// ��� �ʱ�ȭ
        _node = null;
        upgradePriceText.text = "";
        sellPriceText.text = "";
        gameObject.SetActive(false);

    }


}