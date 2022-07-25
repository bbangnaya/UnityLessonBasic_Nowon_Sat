using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Spend,
    ETC
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType type;
    public string tag;              //
    public string description;      // 아이템 설명
    public int num;                 // 아이템 갯수
    public Sprite icon;             // 아이템 아이콘


    public Item(Item copy)  // 아이템 정보 복사해서 인벤토리 모델에 넣기 용도
    {
        tag = copy.tag;
        description = copy.description;
        num = copy.num;
        icon = copy.icon;
    }

}
