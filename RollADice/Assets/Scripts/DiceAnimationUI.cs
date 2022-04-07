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
    public delegate void AnimationFinishedEvent();

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("DiceVectorDark");
    }

    // coroutine 서로가 서로를 호출하는 방식 
    // 좋은 이유 : 스레드
    // 프로그램의 최소단위 : 프로세스, 그 프로세스를 이루고 있는 최소 단위를 스레드라고 한다.
    // 다른 스레드에서 돌리는 것처럼 보이는 것. 
    public IEnumerator E_DiceAnimation(int diceValue, DicePlayManager manager, AnimationFinishedEvent finishEvent)
    {
        float elapsedTime = 0;
        while (elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;
            int tmpIdx = Random.Range(0, sprites.Length);
            diceAnimationImage.sprite = sprites[tmpIdx];
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
