using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;
    private void Awake()
    {
        instance = this;
    }

    public Image diceAnimationImage; // 하지만 이미지를 그대로 받으면 문제가 있다.
    /*public List<Sprite> diceAnimationSprites = new List<Sprite>();*/
    public float diceAnimationTime;
    private Sprite[] sprites;
    public delegate void AnimationFinishedEvent(int diceValue); // 여기가 오타였음

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("DiceVectorDark");
        // LoadAll : Resources라는 폴더를 검색해 (파일명)에 있는 <> 타입의 파일을 불러온다.
        // DiceVectorDark 라는 이미지에 있는 모든 sprite(30)을 읽어온다.
    }

    // coroutine 서로가 서로를 호출하는 방식 
    // 좋은 이유 : 스레드
    // 프로그램의 최소단위 : 프로세스, 그 프로세스를 이루고 있는 최소 단위를 스레드라고 한다.
    // 다른 스레드에서 돌리는 것처럼 보이는 것. 
    // 애니메이션 코루틴

    // DicePlayManager가 호출할 수 있게 public을 붙혀준다.
    public IEnumerator E_DiceAnimation(int diceValue, DicePlayManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;      // 시간경과
        while (elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;  // 시간 쪼개기
            int tmpIdx = Random.Range(0, sprites.Length);   // sprites.Length(=30)개의 그림중 랜덤 순서
            diceAnimationImage.sprite = sprites[tmpIdx];    // 랜덤인덱스 역할을 tmpIdx이 수행
            // 업데이트 프레임 갱신 요청. 안그러면 게임 다운.
            yield return new WaitForSeconds(diceAnimationTime / 10);
        }
        diceAnimationImage.sprite = sprites[diceValue - 1];


        if (finishEvent != null)
            finishEvent(diceValue);

        manager.animationCoroutine = null;

    }
    // coroutine - 메인스레드에 공간을 할당받아서 쓴다.
    // 멀티 스레드 - 비동기 함수 - 가비지컬렉터와 관련 



}
