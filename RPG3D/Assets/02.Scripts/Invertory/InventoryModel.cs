using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    private static InventoryModel _instance;
    public static InventoryModel instance
    {
        get
        {
            if (_instance == null)
                _instance = new InventoryModel();
            return _instance;
        }
    }

    private List<InventoryItemData> _itemsData;

    public InventoryModel()
    {
        _itemsData = new List<InventoryItemData>();
    }

    public void AddItemData(Item item)
    {
        InventoryItemData oldData = _itemsData.Find(x => x.itemType == item.type &&
                                                         x.itemTag == item.tag);

        if (oldData.Equals(default(InventoryItemData)))
        {
            _itemsData.Add(new InventoryItemData()
            {
                itemType = item.type,
                itemTag = item.tag,
                num = item.num,
            });
        }
        else
        {
            _itemsData.Add(new InventoryItemData()
            {
                itemType = item.type,
                itemTag = item.tag,
                num = item.num + oldData.num,
            });
            _itemsData.Remove(oldData);
        }
    }

    public void RemoveItemData(Item item)
    {
        InventoryItemData oldData = _itemsData.Find(x => x.itemType == item.type &&
                                                         x.itemTag == item.tag);

        if (oldData.Equals(default(InventoryItemData)))
        {
            throw new System.Exception("�������� ���µ� ������� �õ��� ����");
        }
        else
        {
            int newNum = oldData.num - item.num;
            if (newNum < 0)
            {
                throw new System.Exception("�����ϴ� ������ �������� �� ���� ������� �õ���");
            }
            else if (newNum > 0)
            {
                _itemsData.Add(new InventoryItemData()
                {
                    itemType = item.type,
                    itemTag = item.tag,
                    num = oldData.num - item.num,
                });
            }

            _itemsData.Remove(oldData);
        }
    }
    private void DebugAllItemData()
    {
        foreach (InventoryItemData item in _itemData)
        {
            Debug.Log($"Inventory")
        }
    }

}