using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Vector3 rangeCenter;
    public Vector3 rangeSize;

    public float spwanTimeGap = 0.3f;
    private float spawnTimer;

    private void Update()
    {
        Vector3 spawnPos = new Vector3(rangeCenter.x + Random.Range(-rangeSize.x / 2, rangeSize.x / 2),
                                       rangeCenter.y + Random.Range(-rangeSize.y / 2, rangeSize.y / 2),
                                       rangeCenter.z + Random.Range(-rangeSize.z / 2, rangeSize.z / 2));
        if (spawnTimer < 0) 
        { 
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
            spawnTimer = spwanTimeGap; 
        }
        else
            spawnTimer -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;       // new Color(); µµ µÈ´Ù.
        Gizmos.DrawCube(rangeCenter, rangeSize);
    }


}
