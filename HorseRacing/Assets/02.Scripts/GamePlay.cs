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
    // �ν��Ͻ��� ���ٸ� �ϸ� �����÷����� ��� ��ü�� ���� ����

    public List<GameObject> players = new List<GameObject>();   // �÷��̾� ����Ʈ, 5������ �����´�.
    private List<Transform> finishedPlayers = new List<Transform>();    // ����� ����Ʈ
    // goal�� ���� transform(��ġ����)�� �����´�.
    public List<Transform> platforms = new List<Transform>();   // �ܻ� ����Ʈ
    
    private float playerStartZPos;
    private int totalPlayers;
    public Transform goal;
    public bool onPlay = false;        // ���� ��ư


    // Start is called before the first frame update
    void Start()
    {
        totalPlayers = players.Count;
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
        /*for(int i = 0; i < players.Count; i++)*/         // �⺻��� : F9�� �����
        for(int i = players.Count-1 ; i >=0 ; i--)         // for���� ū�ʿ��� ����������
        {
            PlayerMove playerMove = players[i].GetComponent<PlayerMove>();
            if(playerMove.distance > goal.position.z - playerStartZPos) // ��Ȯ��
            {
                playerMove.doMove = false;
                // ��� ����Ʈ�� �߰�
                finishedPlayers.Add(players[i].transform);  // List Ÿ���� �ٸ��� ������ transform�� ������. players[i] 
                players.Remove(players[i]);     // i��° ����Ʈ�� ������ ����ڴ�.


            }
        }
    }
    // ������ �������� ���� Ȯ�� �Լ�
    void CheckGameIsFinished()
    {
        if(finishedPlayers.Count >= totalPlayers)
        {
            onPlay = false;
            // �ܻ� �ø���, �ܻ� ��ǥ ����Ʈ �����
            for(int i = 0; i < platforms.Count; i++)
            {
                finishedPlayers[i].position = platforms[i].Find("PlayerPoint").position
                    /*+ new Vector3(0,finishedPlayers[i].lossyScale.y,0)*/;    // GetChild(0) 0��° �ڽ��� ����
                // find() ���ڿ��� �޴´�. 

            }

        }
    } 
    public void PlayGame()
    {
        onPlay = true;
        playerStartZPos = players[0].transform.position.z;
        foreach (var sub in players)
        {
            // item = gameObject, player�� plyer move �� �����;� domove�� ���� �ִ�. 
            PlayerMove playerMove = sub.GetComponent<PlayerMove>();     // player�� plyer move�� ����
            if (playerMove != null)        // Ŭ���ϸ� 
            {
                playerMove.doMove = true; // player�� plyer move�� domove�� true�� �ٲ��ش�. 
            }
        }
    }
}