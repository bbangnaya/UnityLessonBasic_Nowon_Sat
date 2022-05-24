using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_Level", menuName = "Scriptable Object/Create LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public int level;
    public List<StageInfo> stageInfos = new List<StageInfo>();
    // StageInfo 클래스 내 해당 멤버를 인스펙터 창에 노출해서 조정 가능
}
