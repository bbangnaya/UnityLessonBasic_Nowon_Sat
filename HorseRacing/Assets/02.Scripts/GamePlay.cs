using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    static public GamePlay instance;
    private void Awake()
    {
        instance = this;
    }
    // 인스턴스에 접근만 하면 게임플레이의 모든 객체에 접근 가능

    public List<GameObject> players = new List<GameObject>();   // 플레이어 리스트, 5마리를 가져온다.
    private List<Transform> finishedPlayers = new List<Transform>();    // 등수별 리스트
    // goal에 대한 transform(위치정보)를 가져온다.
    public List<Transform> platforms = new List<Transform>();   // 단상 리스트
    
    private float playerStartZPos;
    private int totalPlayers;
    public Transform goal;
    public bool onPlay = false;        // 시작 버튼


    // Start is called before the first frame update
    void Start()
    {
        totalPlayers = players.Count;       //
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlay)
        {
            CheckPlayerReachedToGoalAndStopMove();
            CheckGameIsFinished();
        }
    }
    void CheckPlayerReachedToGoalAndStopMove()
    {
        /*for(int i = 0; i < players.Count; i++)*/         // 기본상식 : F9는 디버그
        /*for(int i = players.Count-1 ; i >=0 ; i--)         // for문이 큰쪽에서 작은쪽으로
        {
            PlayerMove playerMove = players[i].GetComponent<PlayerMove>();
            if(playerMove.distance > goal.position.z - playerStartZPos) // 재확인
            {
                playerMove.doMove = false;
                // 등수 리스트에 추가
                finishedPlayers.Add(players[i].transform);  // List 타입이 다르기 때문에 transform을 붙힌다. players[i] 
                players.Remove(players[i]);     // i번째 리스트의 내용을 지우겠다.


            }
        }*/
        for (int i = 0; i < players.Count; i++)
        {
            PlayerMove playerMove = players[i].GetComponent<PlayerMove>();
            if (playerMove.distance > goal.position.z - playerStartZPos) // 재확인
            {
                playerMove.doMove = false;
                // 등수 리스트에 추가
                finishedPlayers.Add(players[i].transform);  // List 타입이 다르기 때문에 transform을 붙힌다. players[i] 
                players.Remove(players[i]);     // i번째 리스트의 내용을 지우겠다.


            }
        }
       

    }
    // 게임이 끝났는지 여부 확인 함수
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count >= totalPlayers)
        {
            onPlay = false;
            // 단상에 올리기, 단상 좌표 리스트 만들기
            for(int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].Find("PlayerPoint").position
                    /*+ new Vector3(0,finishedPlayers[i].lossyScale.y,0)*/;    // GetChild(0) 0번째 자식의 정보
                // find() 문자열로 받는다. 

            }

        }
    } 
    public void PlayGame()
    {
        onPlay = true;
        playerStartZPos = players[0].transform.position.z;
        foreach (var sub in players)
        {
            // item = gameObject, player의 plyer move 를 가져와야 domove를 쓸수 있다. 
            PlayerMove playerMove = sub.GetComponent<PlayerMove>();     // player의 plyer move에 접근
            if (playerMove != null)        // 클릭하면 
            {
                playerMove.doMove = true; // player의 plyer move의 domove를 true로 바꿔준다. 
            }
        }
    }
}