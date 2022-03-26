using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlayManager : MonoBehaviour
{
    // [2]
    private int currentTileIndex;

    public Text diceText;
    private int _diceNum;
    public int diceNum
    {
        set
        {
            if(value >= 0)
            {
                _diceNum = value;
                diceText.text = _diceNum.ToString();
            }
        }
        get
        {
            return _diceNum;
        }

    }


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
    private int _starScoreNum;
    public int starscore
    {
        set
        {
            if (starScore >= 0)
            {
                _starScoreNum = value;
                starScoreText.text = _starScoreNum.ToString();
            }
        }
        get
        {
            return starScore;
        }
    }

    public int diceNumInit;
    public int goldenDiceNumInit;
    public int starScore;

    public List<Transform> mapTiles;

    private void Awake()
    {
        diceNum = diceNumInit;
        goldenDiceNumInit = goldenDiceNum;
    }

    // 버튼 누르면 주사위 굴리기
    public void RollADice()
    {
        if (diceNum < 1) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        MovePlayer(diceValue);
    }
    

    private void MovePlayer(int diceValue)
    {

        currentTileIndex += diceValue;

        if (currentTileIndex >= mapTiles.Count)
            currentTileIndex -= mapTiles.Count;

        Player.instance.Move(GetTilePosition(currentTileIndex));

    }
    // 타일 위치 계산하는 함수
    private Vector3 GetTilePosition(int tileIndex)
    {

        return mapTiles[tileIndex].position;
    }
}