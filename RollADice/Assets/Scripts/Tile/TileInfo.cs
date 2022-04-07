using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int index;

    public virtual void TileEvent() // 오버라이드
    {
        Debug.Log($"Index of this Tile : {index}");
    }
}