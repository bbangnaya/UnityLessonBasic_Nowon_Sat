using System;
using UnityEngine;

public class TileInfo_Inverse : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log($"index of this tile : {index}, Player will move inverse once");
        DicePlayManager.instance.direction = -1;


    }

}
