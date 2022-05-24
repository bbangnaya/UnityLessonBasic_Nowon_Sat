using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_Level", menuName = "Scriptable Object/Create LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public int level;
    public List<StageInfo> stageInfos = new List<StageInfo>();
    // StageInfo Ŭ���� �� �ش� ����� �ν����� â�� �����ؼ� ���� ����
}