using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    //싱글톤
    public static DicePlayManager instance; // 어웨이크에서 초기화

    private int currentTileIndex;       // 현재 칸 인덱스    
    private int _diceNum;       // 남은 주사위 총 개수
    // 다른 객체에 직접 접근을 꺼린다. 
    // 멤버변수와 멤버함수의 중간 형태 = 프로퍼티
    public int diceNum{
        set{            // 쓰기용
            if(value >= 0)      // 남은 주사위 개수>0 이면
            {
                _diceNum = value;
                diceText.text = _diceNum.ToString();    // 화면에 보이는 UI 텍스트 업데이트
                // 수정할때마다 수정함수를 호출하기 어려워서 
            }
        }
        get // 읽기용
        {
            return _diceNum;
        }
    }
    public Text diceText;       // 남은 주사위 갯수 텍스트UI
    public int diceNumInit;     // 주사위 초기값

    public Text goldenDiceNumText;
    private int _goldenDiceNum;
    public int goldenDiceNum
    {
        set
        {
            if (value >= 0)
            {
                _goldenDiceNum = value;
                goldenDiceNumText.text = _goldenDiceNum.ToString();
            }
        }
        get
        {
            return _goldenDiceNum;
        }

    }
    public Text starScoreText;
    private int _starScore; // 샛별 총 점수
    public int starScore        // txt 넣는 곳
    {
        set
        {
            if (starScore >= 0)
            {
                _starScore = value;
                starScoreText.text = _starScore.ToString();
            }
        }
        get
        {
            return _starScore;
        }
    }
    /*public int direction = 1; // 1: forward, -1 : backward*/
    
    private int _direction;
    public int direction
    {
        set
        {
            _direction = value;
            if(_direction > 0)
                inversePanel.SetActive(false);
            else
                inversePanel.SetActive(true);

        }
        get { return _direction; }
    }
    public GameObject inversePanel;


    public int goldenDiceNumInit;
    public List<Transform> mapTiles;
    public Coroutine animationCoroutine = null;


    private void Awake()        // 현재 남은 주사위 갯수를 초기화
    {
        instance = this;        // 싱글톤
        diceNum = diceNumInit;
        goldenDiceNumInit = goldenDiceNum;
        starScore = 0;

    }

    // 버튼 누르면 주사위 굴리기
    public void RollADice()
    {
        if (diceNum < 1) return;        // 주사위가 남아있을 때만

        if (animationCoroutine != null) return;     // 주사위 돌아갈 땐 버튼 자체를 못누르게 한다.

        diceNum--;
        int diceValue = Random.Range(1, 7);     // 랜덤
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
        /*MovePlayer(diceValue);*/
        
        // 애니메이션 진행중일땐 주사위 못던지도록
    }

    public void RollAGoldenDice(int diceValue)      // 선택, 1. 버튼 6개 만들어서 하기
    {
        if (goldenDiceNum < 1) return;
        if (animationCoroutine != null) return;

        goldenDiceNum--;
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
        /*MovePlayer(diceValue);*/
    }


    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileIndex;
        currentTileIndex += diceValue * direction;

        CheckPlayerPassedStarTile(previousTileIndex, currentTileIndex);

        if (currentTileIndex >= mapTiles.Count) // 전체 인덱스(한바퀴)보다 크면
            currentTileIndex -= mapTiles.Count; // 빼라
        
        Debug.Log($"{direction}");
        Player.instance.Move(GetTilePosition(currentTileIndex));
        
        
        direction = 1;

        mapTiles[currentTileIndex].GetComponent<TileInfo>().TileEvent();
        // (맵 타일[현재 인덱스] =) Tile 오브젝트에 접근해서 TileInfo 클래스의 TileEvent 함수 호출


    }

    private void CheckPlayerPassedStarTile(int previousIndex, int currentIndex){
        /*TileInfo_Star tmpStarTile = null;*/
        for (int i=previousIndex +1; i <= currentIndex; i++)
        {
            int tmpIndex = i;
            if (tmpIndex >= mapTiles.Count)
                tmpIndex -= mapTiles.Count;

            /*bool isPassed = mapTiles[tmpIndex].TryGetComponent(out TileInfo_Star tmpStarTile);
            if (isPassed)
                starScore += tmpStarTile.starValue;*/
            // 그냥 isPassed를 정의하지 않고 if조건에 넣어버리면 코드를 짧게 할 수도 있다. 

            if (mapTiles[tmpIndex].TryGetComponent(out TileInfo_Star tmpStarTile))
                starScore += tmpStarTile.starValue;
        }


    }

    // 타일 위치 계산하는 함수
    private Vector3 GetTilePosition(int tileIndex)
    {

        return mapTiles[tileIndex].position;
    }
}