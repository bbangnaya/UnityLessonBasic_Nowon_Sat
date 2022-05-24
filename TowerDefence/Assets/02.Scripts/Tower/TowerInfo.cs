using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data_Tower", menuName = "ScriptableObject/Create TowerInfo")]
public class TowerInfo : ScriptableObject
{
    public TowerType type;
    public int upgradeLevel;
    public int buildPrice;
    public int sellPrice;
    public Sprite icon;     // �̹��� �߰�
}


public enum TowerType
{
    MachineGun,
    RocketLauncher,
    Laser,
}