using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������� ������ ������ ����
/// </summary>
[System.Serializable]
public class StageInfo
{
    public int stage;               // ���° ������������ ���� ��������
    public EnemySpawner.SpawnElement[] enemiesElements;     // �迭 ���� ������
}
