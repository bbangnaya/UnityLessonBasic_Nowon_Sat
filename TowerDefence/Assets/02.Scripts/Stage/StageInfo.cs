using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스테이지별 정보를 가지고 있음
/// </summary>
[System.Serializable]
public class StageInfo
{
    public int stage;               // 몇번째 스테이지인지 정보 가져오기
    public EnemySpawner.SpawnElement[] enemiesElements;     // 배열 정보 가져옴
}