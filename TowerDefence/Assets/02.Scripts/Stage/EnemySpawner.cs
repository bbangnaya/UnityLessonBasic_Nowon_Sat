using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float startDelay = 1f;
    [HideInInspector] public int currentLevel;
    [HideInInspector] public int currentStage;      // 현재 스테이지 정보
    [System.Serializable]   // 클래스에 있는 멤버들을 Serialize 하겠다.

    // 이너 클래스
    public class SpawnElement
    {
        public GameObject prefab;
        public int num;
        public float delay;
    }
    [SerializeField] private SpawnElement[][] spawnElements;
    private float[][] timers;
    private int[][] counts;

    public void Spawn()
    {
        if(currentStage < spawnElements.Length) // 다음 스테이지 여부
        {
            StartCoroutine(E_Spawn());
        }
    }

    private void Awake()
    {   // 초기화
        // 현재 레벨에 대한 모든 스테이지 정보 가져옴
        StageInfo[] tmpStageInfos = LevelInfoAssets.GetAllStageInfo(currentLevel);
        // 소환해야하는 에너미 배열의 스테이지 크기 할당
        spawnElements = new SpawnElement[tmpStageInfos.Length][];

        // 소환해야하는 스테이지별 에너미 목록 할당
        for (int i = 0; i < tmpStageInfos.Length; i++)
        {
            spawnElements[i] = tmpStageInfos[i].enemiesElements;
        }

        // 동적 할당
        timers = new float[spawnElements.Length][]; // 이차배열 생성
        counts = new int[spawnElements.Length][];

        for(int i = 0; i < spawnElements.Length; i++)
        {
            timers[i] = new float[spawnElements[i].Length];
            counts[i] = new int[spawnElements[i].Length];

            for(int j = 0; j < spawnElements[i].Length; j++)
            {
                timers[i][j] = spawnElements[i][j].delay;
                counts[i][j] = spawnElements[i][j].num;
            }
        }
    }
    private IEnumerator E_Spawn()
    {
        int tmpStage = currentStage;
        currentStage++;
        yield return new WaitForSeconds(startDelay);

        bool isDone = false;
        while(isDone == false)
        {
            isDone = true;

            for (int i = 0; i < spawnElements[tmpStage].Length; i++)
            {
                // 소환할 것이 남아있는지 체크
                if (counts[tmpStage][i] > 0)
                {
                    isDone = false;
                    // 소환 딜레이 체크
                    if (timers[tmpStage][i] < 0)
                    {
                        Instantiate(spawnElements[tmpStage][i].prefab,
                                    WayPoints.instance.GetFirstWayPoint().position,
                                    Quaternion.identity);
                        Debug.Log($"{spawnElements[tmpStage][i].prefab.name}"); // 소환했다고 디버그는 찍히는데 소환이 안됨.
                        counts[tmpStage][i]--;
                        timers[tmpStage][i] = spawnElements[tmpStage][i].delay;
                    }
                    else
                        timers[tmpStage][i] -= Time.deltaTime;
                }
            }
            yield return null;
        }

        
    }

}
